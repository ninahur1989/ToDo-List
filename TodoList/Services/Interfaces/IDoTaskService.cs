using TodoList.Models;

namespace TodoList.Services.Interfaces
{
    public interface IDoTaskService
    {
        public Task<List<ToDoTask>> GetAllAsync();
        public Task<bool> AddAsync(string description);
        public Task<bool> ArchiveAsync(int id);
        public Task<bool> EditStatusAsync(int id);
    }
}
