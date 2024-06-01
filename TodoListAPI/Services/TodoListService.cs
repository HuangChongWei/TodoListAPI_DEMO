using TodoListAPI.Repositories;

namespace TodoListAPI.Services
{
    public class TodoListService
    {
        private readonly DapperRepositories _repository;

        public TodoListService(DapperRepositories repository)
        {
            _repository = repository;
        }
    }
}
