using To_Do_List.Application.Interfaces;
using To_Do_List.Domain.Entities;
using To_Do_List.Infrastructure.Repositories;

namespace To_Do_List.Application.Services {
    public class TaskService : ITaskService {

        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository) {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync() {
            return await _taskRepository.GetAllAsync();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id) {
            return await _taskRepository.GetByIdAsync(id);
        }

        public async Task<TaskItem> CreateTaskAsync(TaskItem task) {
            return await _taskRepository.AddAsync(task);
        }

        public async Task UpdateTaskAsync(TaskItem task) {
            await _taskRepository.UpdateAsync(task);
        }

        public async Task DeleteTaskAsync(int id) {
            await _taskRepository.DeleteAsync(id);
        }
    }
}
