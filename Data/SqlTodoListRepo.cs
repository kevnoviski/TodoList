using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.Models;

namespace TodoList.Data
{
    public class SqlTodoListRepo : ITodoItemRepo
    {
        private readonly TodoListContext _context;

        public SqlTodoListRepo(TodoListContext context )
        {
            _context = context;
        }
        public void CreateTodoItem(TodoItem todoItem)
        {
            if(todoItem == null)
            {
                throw new ArgumentNullException(nameof(todoItem));
            }
            _context.TodoList.Add(todoItem);
        }

        public void DeleteTodoItem(TodoItem todoItem)
        {
            if(todoItem == null)
            {
                throw new ArgumentNullException(nameof(todoItem));
            }
            _context.TodoList.Remove(todoItem);
        }

        public IEnumerable<TodoItem> GetAllItems()
        {
            return _context.TodoList.ToList();
        }

        public TodoItem GetTodoItemById(int id)
        {
            return _context.TodoList.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return(_context.SaveChanges() >= 0);
        }

        public void UpdateTodoItem(TodoItem todoItem)
        {
            //nothing
        }
    }
}