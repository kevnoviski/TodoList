using System.Collections.Generic;
using TodoList.Data;
using TodoList.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using TodoList.Dtos;

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
        public ActionResult<TodoItem> CreateTodoItem(TodoItemCreateDto todoItem)
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

        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<TodoItemUpdateDto> pathDoc)
        {
            throw new System.NotImplementedException();
        }

        //PUT api/todolist/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTodoItem(int id, TodoItemUpdateDto todoItem)
        {
            throw new System.NotImplementedException();
        }
    }
}