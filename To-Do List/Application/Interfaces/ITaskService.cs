using To_Do_List.Domain.Entities;

namespace To_Do_List.Application.Interfaces {
    public interface ITaskService {

        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<TaskItem?> GetTaskByIdAsync(int id);
        Task<TaskItem> CreateTaskAsync(TaskItem item);
        Task UpdateTaskAsync(TaskItem item);
        Task DeleteTaskAsync(int id);
    }
}
