using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TodoList.Dtos;
using TodoList.Models;

namespace TodoList.Controllers
{
    public interface IControllerTodoItem
    {
        ActionResult <IEnumerable<TodoItem>> GetAllTodoItems();
        ActionResult <TodoItem> GetTodoItemById(int id);
        ActionResult <TodoItem> CreateTodoItem(TodoItemCreateDto todoItem);
        ActionResult UpdateTodoItem(int id, TodoItemUpdateDto todoItem);
        ActionResult DeleteTodoItem(int id);
        ActionResult PartialCommandUpdate(int id, JsonPatchDocument<TodoItemUpdateDto> pathDoc);
    }
}