using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using To_Do_List.Application.Interfaces;
using To_Do_List.Domain.Entities;

namespace To_Do_List.Presentation.Controllers   {

    [Authorize]
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase   {

        private readonly ITaskService _taskService;
        private readonly ILogger<TasksController> _logger;

        public TasksController(ITaskService taskService, ILogger<TasksController> logger) {
            _taskService = taskService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks() {
            try 
            {
                return Ok(await _taskService.GetAllTasksAsync());
            } 
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error while fetching tasks.");
                return StatusCode(500, "An error occurred while fetching tasks.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id) {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null) {
                return NotFound();
            }
            return task;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task) {
            try 
            {
                var newTask = await _taskService.CreateTaskAsync(task);
                return CreatedAtAction(nameof(GetTask), new { id = newTask.Id }, newTask);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error while creating task.");
                return StatusCode(500, "An error occurred while creating the task.");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskItem task) {
            if (id != task.Id) return BadRequest();
            await _taskService.UpdateTaskAsync(task);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id) {
            await _taskService.DeleteTaskAsync(id);
            
            return NoContent();
        }
    }
}
