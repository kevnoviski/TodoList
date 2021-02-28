using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public interface IControllerTodoItem
    {
        ActionResult <IEnumerable<TodoItem>> GetAllTodoItems();
        ActionResult <TodoItem> GetTodoItemById(int id);
        ActionResult <TodoItem> CreateTodoItem(TodoItem todoItem);
        ActionResult UpdateTodoItem(int id, TodoItem todoItem);
        ActionResult DeleteTodoItem(int id);
        //ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> pathDoc);
    }
}