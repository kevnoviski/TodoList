using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Data
{
    public class TodoListContext: DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> opt) : base(opt)
        {
            
        }
        public DbSet<TodoItem> TodoList { get; set; }
    }
}