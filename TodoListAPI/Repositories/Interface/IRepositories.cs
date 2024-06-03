using System.Collections.Generic;
using TodoListAPI.Entities;

namespace TodoListAPI.Repositories.Interface
{
    public interface IRepositories
    {
        void Add(string decription, int userId);
        void Delete(int id, int userId);
        IEnumerable<TodoItem> GetTodoItem(int userId);
        User GetUser(string email);
        void Update(TodoItem model);
    }
}