using System;
using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Data
{
    public class MockTodoItemRepo : ITodoItemRepo
    {
        public void CreateTodoItem(TodoItem todoItem)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTodoItem(TodoItem todoItem)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllItems()
        {
            return new List<TodoItem>{
                new TodoItem{
                Id=1,
                Title="Create mock",
                Description="Create a mock to test the basic commands",
                DT_Creation=DateTime.Now,
                DT_DeadLine=DateTime.Now.AddHours(5)},
                new TodoItem{
                Id=1,
                Title="Create Controller",
                Description="Create a Controller to test the basic verbs",
                DT_Creation=DateTime.Now,
                DT_DeadLine=DateTime.Now.AddHours(5)
                },
                new TodoItem{
                Id=1,
                Title="Import nuget files",
                Description="Import nuget files to add the rest of the stuff needed",
                DT_Creation=DateTime.Now,
                DT_DeadLine=DateTime.Now.AddHours(5)
                }
            };
        }

        public TodoItem GetTodoItemById(int id)
        {
            return new TodoItem(){
                Id=1,
                Title="Create mock",
                Description="Create a mock to test the basic commands",
                DT_Creation=DateTime.Now,
                DT_DeadLine=DateTime.Now.AddHours(5)
            };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateTodoItem(TodoItem todoItem)
        {
            throw new System.NotImplementedException();
        }
    }
}