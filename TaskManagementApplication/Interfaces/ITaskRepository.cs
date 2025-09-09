
using TaskManagementApplication.Dtos;
using TaskManagementDomain.Entities;

namespace TaskManagementApplication.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(int id);
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(int id);


        // NEW: Filter/Search method
        Task<IEnumerable<TaskItem>> GetFilteredAsync(TaskFilterDto filter);
    }
}
