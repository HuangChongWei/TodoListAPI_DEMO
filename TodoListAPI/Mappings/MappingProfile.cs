using AutoMapper;
using TodoListAPI.Entities;
using TodoListAPI.Models;

namespace TodoListAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoItem, TodoItemAPIModel>();
            CreateMap<TodoItemAPIModel, TodoItem>();
            CreateMap<User, UserDto>();
        }
    }
}
