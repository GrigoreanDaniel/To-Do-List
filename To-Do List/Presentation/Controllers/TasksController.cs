using Microsoft.AspNetCore.Mvc;
using To_Do_List.Application.Interfaces;
using To_Do_List.Domain.Entities;

namespace To_Do_List.Presentation.Controllers   {

    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase   {

        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService) {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks() {
            return Ok(await _taskService.GetAllTasksAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id) {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null) {
                return NotFound();
            }
            return task;
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task) {
            var newTask = await _taskService.CreateTaskAsync(task);
            return CreatedAtAction(nameof(GetTask), new { id = newTask.Id }, newTask);
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
