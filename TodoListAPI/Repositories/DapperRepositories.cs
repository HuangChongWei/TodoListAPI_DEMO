using System.Collections.Generic;
using System.Data;
using TodoListAPI.Entities;

namespace TodoListAPI.Repositories
{
    public class DapperRepositories
    {
        private readonly IDbConnection _cnn;

        public DapperRepositories(IDbConnection cnn)
        {
            _cnn = cnn;
        }

        public void Add(string decription)
        {
            var query = "INSERT INTO TodoItem(Description) VALUES(@Description) ";
            var param = new { Description = decription };
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

        public void Delete(int id)
        {
            var query = "DELETE TodoItem WHERE Id =@Id";
            var param = new { Id = id };
            _conn.Execute(query, param);
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _conn.Query<TodoItem>("SELECT * FROM TodoItem");
        }
    }
}
