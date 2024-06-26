﻿using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TodoListAPI.Entities;
using TodoListAPI.Repositories.Interface;

namespace TodoListAPI.Repositories
{
    public class DapperRepositories : IRepositories
    {
        private readonly IDbConnection _conn;

        public DapperRepositories(IDbConnection conn)
        {
            _conn = conn;
        }

        public void Add(string decription, int userId)
        {
            var query = "INSERT INTO TodoItem(Description, UserId) VALUES(@Description, @UserId) ";
            var param = new { Description = decription, UserId = userId };
            _conn.Execute(query, param);
        }
        public void Update(TodoItem model)
        {
            var param = new
            {
                model.Id,
                model.Description,
                model.IsDone
            };
            _conn.Execute("dbo.SP_TodoList_U", param);
        }

        public void Delete(int id, int userId)
        {
            var query = "DELETE TodoItem WHERE Id =@Id AND UserId = @UserId";
            var param = new { Id = id, UserId = userId };
            _conn.Execute(query, param);
        }

        public IEnumerable<TodoItem> GetTodoItem(int userId)
        {
            var query = "SELECT * FROM TodoItem WHERE UserId = @UserId";
            var param = new { UserId = userId };
            return _conn.Query<TodoItem>(query, param);
        }

        public User GetUser(string email)
        {
            var query = "SELECT * FROM [User] WHERE Email = @Email";
            var param = new { Email = email };
            var result = _conn.Query<User>(query, param);
            return result.First();
        }
    }
}
