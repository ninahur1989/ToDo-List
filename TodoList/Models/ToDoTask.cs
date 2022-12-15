using TodoList.Data.Enums;

namespace TodoList.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Data.Enums.TaskStatus Status { get; set; }
        public TaskActuality Actuality { get; set; }
    }
}
