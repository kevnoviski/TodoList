using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Data
{
    public interface ITodoItemRepo
    {
        bool SaveChanges();
        IEnumerable<TodoItem> GetAllItems();
        TodoItem GetTodoItemById(int id);
        void CreateTodoItem(TodoItem todoItem);
        void UpdateTodoItem(TodoItem todoItem);
        void DeleteTodoItem(TodoItem todoItem);
    }
}