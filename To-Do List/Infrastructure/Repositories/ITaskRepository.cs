using To_Do_List.Domain.Entities;

namespace To_Do_List.Infrastructure.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(int id);
        Task<TaskItem> AddAsync(TaskItem item);
        Task UpdateAsync(TaskItem item);
        Task DeleteAsync(int id);
    }
}
