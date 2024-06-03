using System.Collections.Generic;
using TodoListAPI.Models;

namespace TodoListAPI.Services
{
    public interface ITodoListService
    {
        BaseModel Add(string decription, int userId);
        BaseModel Delete(int id, int userId);
        IEnumerable<TodoItemAPIModel> GetAll(int userId);
        BaseModel Update(TodoItemAPIModel item);
    }
}