using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoListAPI.Models;
using TodoListAPI.Services;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListApiController : ControllerBase
    {
        private readonly TodoListService _service;

        public TodoListApiController(TodoListService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<TodoItemAPIModel> Get()
        {
            return _service.GetAll();
        }

        [HttpPost]
        public BaseModel Post(string description)
        {
            return _service.Add(description);
        }
        [HttpPut]
        public BaseModel Put(TodoItemAPIModel model)
        {
            return _service.Update(model);
        }

        [HttpDelete]
        public BaseModel Delete(int id)
        {
            return _service.Delete(id);
        }

    }
}
