using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using TodoListAPI.Models;
using TodoListAPI.Services;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            // 取得目前使用者ID
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return _service.GetAll(currentUserId);
        }

        [HttpPost]
        [Authorize]
        public BaseModel Post(string description)
        {
            // 取得當前使用者 ID
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            return _service.Add(description, currentUserId);
        }
        [HttpPut]
        public BaseModel Put(TodoItemAPIModel model)
        {
            //取得當前使用者Id
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            //驗證TodoList是否屬於當前User
            if(model.UserId != currentUserId)
            {
                return new BaseModel
                {
                    RtnCode = 0,
                    RtnMsg = "沒有權限修改"
                };
            }

            return _service.Update(model);
        }

        [HttpDelete]
        public BaseModel Delete(int id)
        {
            //取得當前使用者Id
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return _service.Delete(id, currentUserId);
        }

    }
}
