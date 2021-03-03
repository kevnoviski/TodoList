using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Dtos;
using TodoList.Models;

namespace TodoList.Controllers
{    
    [Route("api/todolist")]
    [ApiController]
    public class ControllerTodoList : ControllerBase, IControllerTodoItem
    {
        private readonly ITodoItemRepo _repository;
        private readonly IMapper _mapper;

        public ControllerTodoList(ITodoItemRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //POST api/todolist/
        [HttpPost]
        public ActionResult<TodoItem> CreateTodoItem(TodoItemCreateDto todoItemCreateDto)
        {
            //matches the create model to the official table model
            var todoItemModel = _mapper.Map<TodoItem>(todoItemCreateDto);
            //adds the 'merged' model to context
            _repository.CreateTodoItem(todoItemModel);
            //saves it
            _repository.SaveChanges();

            //converts an officil model to a read dto model
            var todoItemReadDto = _mapper.Map<TodoItemReadDto>(todoItemModel);
            /*
                CreatedAtRoute - Parameters

                routeName String

                The name of the route to use for generating the URL. [ nameof(GetTodoItemById) ]

                routeValues Object

                The route data to use for generating the URL. [ new {Id = todoItemReadDto.Id} ]

                content Object

                The content value to format in the entity body. [ todoItemReadDto ]

            */
            Debug.Print(todoItemModel.ToString());
            return CreatedAtRoute(nameof(GetTodoItemById), new {Id = todoItemReadDto.Id},todoItemReadDto);
        }

        //DELETE api/todolist/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTodoItem(int id)
        {
            var todoItem = _repository.GetTodoItemById(id);
            if(todoItem != null)
            {
                _repository.DeleteTodoItem(todoItem);
                _repository.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        //GET api/todolist/
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAllTodoItems()
        {
            var todoList= _repository.GetAllItems();
            if(todoList == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<TodoItemReadDto>>(todoList));
        }

        //GET api/todolist/{id}
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItemById(int id)
        {
            var todoItem = _repository.GetTodoItemById(id);
            if(todoItem != null)
            {
                return Ok(_mapper.Map<TodoItemReadDto>(todoItem));
            }
            return NotFound();
        }

        //PATCH api/todolist/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<TodoItemUpdateDto> pathDoc)
        {
             /*
            [
                {
                    "op": "replace", //replace is the operation, there are other types
                    "path": "/howto", //path is the attribute thats gonna be updated
                    "value" :"new field value" // value is the new attribute's content
                }
            ]

            */
            //get the object by the id passed in the url
            var todoItemModelFromRepo = _repository.GetTodoItemById(id);
            if(todoItemModelFromRepo == null)
            {
                return NotFound();
            }
            //maps the object from the database into a TodoItemUpdateDto model
            var todoItemToPatch = _mapper.Map<TodoItemUpdateDto>(todoItemModelFromRepo);
            //attempts to merge the patch with the original object
            pathDoc.ApplyTo(todoItemToPatch,ModelState);

            //return validation error if fails to merge
            if(!TryValidateModel(todoItemToPatch))
            {
                return ValidationProblem(ModelState);
            }

            //apply the change to the filtered object
            _mapper.Map(todoItemToPatch, todoItemModelFromRepo);

            //calls update(but it does do anything since there is no implementation of the method update)
            _repository.UpdateTodoItem(todoItemModelFromRepo);

            //commits the object merged with the changes [todoItemModelFromRepo]
            _repository.SaveChanges();

            return NoContent();

        }

        //PUT api/todolist/{id}
        [HttpPut("{id:int}")]
        public ActionResult UpdateTodoItem(int id, TodoItemUpdateDto todoItemUpdateDto)
        {
            // gets the object in the oficial model from database
            var todoItemModelFromRepo = _repository.GetTodoItemById(id);
            if(todoItemModelFromRepo == null)
            {
                return NotFound();
            }
            //merge where new -> replaces current
            _mapper.Map(todoItemUpdateDto,todoItemModelFromRepo);

            //calls update(but it does do anything since there is no implementation of the method update)
            _repository.UpdateTodoItem(todoItemModelFromRepo);

            //commits the object merged with the changes [todoItemModelFromRepo]
            _repository.SaveChanges();

            return NoContent();
        }
    }
}