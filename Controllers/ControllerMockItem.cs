using System.Collections.Generic;
using TodoList.Data;
using TodoList.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;


namespace TodoList.Controllers
{
    [Route("api/todolistMock")]
    [ApiController]
    public class ControllerMockItem : ControllerBase, IControllerTodoItem
    {
        private readonly ITodoItemRepo _repository;

        public ControllerMockItem(ITodoItemRepo repository)
        {
            _repository = repository;
        }
        //POST api/todolist/
        [HttpPost]
        public ActionResult<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            throw new System.NotImplementedException();
        }
        //DELETE api/todolist/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTodoItem(int id)
        {
            throw new System.NotImplementedException();
        }

        //GET api/todolist/
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAllTodoItems()
        {
            var todoItens= _repository.GetAllItems();
            return Ok(todoItens);
        }

        //GET api/todolist/{id}
        [HttpGet("{id}", Name="GetTodoItemById")]
        public ActionResult<TodoItem> GetTodoItemById(int id)
        {
            throw new System.NotImplementedException();
        }

        //PUT api/todolist/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTodoItem(int id, TodoItem todoItem)
        {
            throw new System.NotImplementedException();
        }
    }
}