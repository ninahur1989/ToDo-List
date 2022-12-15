using BulletinBoard.Data;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;
using TodoList.Services.Interfaces;

namespace TodoList.Services
{
    public class DoTaskService : IDoTaskService
    {
        private readonly AppDbContext _context;

        public DoTaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoTask>> GetAllAsync()
        {
            return await _context.ToDoTasks.Where(x => x.Id != null).ToListAsync();
        }

        public async Task<bool> ArchiveAsync(int id)
        {
            var task = await _context.ToDoTasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task != null)
            {
                if (task.Actuality == Data.Enums.TaskActuality.Archived)
                {
                    task.Actuality = Data.Enums.TaskActuality.InProgres;
                }
                else
                {
                    task.Actuality = Data.Enums.TaskActuality.Archived;
                }

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> EditStatusAsync(int id)
        {
            var task = await _context.ToDoTasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task != null)
            {
                if (task.Status == Data.Enums.TaskStatus.None)
                {
                    task.Status = Data.Enums.TaskStatus.Completed;
                }
                else
                {
                    task.Status = Data.Enums.TaskStatus.None;
                }

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> AddAsync(string description)
        {
            try
            {
                ToDoTask task = new ToDoTask();
                task.Description = description;
                task.Status = Data.Enums.TaskStatus.None;
                task.Actuality = Data.Enums.TaskActuality.InProgres;
                await _context.AddAsync(task);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
