using AutoMapper;
using TodoList.Dtos;
using TodoList.Models;

namespace TodoList.Profiles
{
    public class TodoListProfile :Profile
    {
        public TodoListProfile()
        {
            //Source -> Target
            CreateMap<TodoItem,TodoItemReadDto>();
            CreateMap<TodoItemCreateDto,TodoItem>();
            CreateMap<TodoItemUpdateDto,TodoItem>();
            CreateMap<TodoItem,TodoItemUpdateDto>();   
        }
        
    }
}