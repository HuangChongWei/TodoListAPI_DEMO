using AutoMapper;
using TodoListAPI.Entities;
using TodoListAPI.Models;

namespace TodoListAPI.Mappings
{
    public class TodoListProfile : Profile
    {
        public TodoListProfile()
        {
            CreateMap<TodoItem, TodoItemAPIModel>();
            CreateMap<TodoItemAPIModel, TodoItem>();
        }
    }
}
