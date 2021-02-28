using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{    
    [Route("api/todolist")]
    [ApiController]
    public class ControllerTodoList : ControllerBase, IControllerTodoItem
    {
        private readonly ITodoItemRepo _repository;

        public ControllerTodoList(ITodoItemRepo repository)
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
            return Ok(_repository.GetAllItems());
        }

        //GET api/todolist/{id}
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItemById(int id)
        {
            var todoItem = _repository.GetTodoItemById(id);
            if(todoItem != null)
            {
                return Ok(todoItem);
            }
            return NotFound();
        }

        //PUT api/todolist/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTodoItem(int id, TodoItem todoItem)
        {
            throw new System.NotImplementedException();
        }
    }
}