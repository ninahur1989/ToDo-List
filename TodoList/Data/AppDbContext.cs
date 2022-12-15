using Microsoft.EntityFrameworkCore;
using TodoList.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace BulletinBoard.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<ToDoTask> ToDoTasks { get; set; }
    }
}
