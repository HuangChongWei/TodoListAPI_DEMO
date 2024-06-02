using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Models;
using TodoListAPI.Services;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {
        private readonly LoginService _service;
        private readonly Services.AuthenticationService _authenticationService;

        public LoginApiController(LoginService service, Services.AuthenticationService authenticationService)
        {
            _service = service;
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto model)
        {
            // 驗證使用者帳號密碼
            var result = _service.Login(model.Email, model.Password);
            if (!result.IsSuccess)
            {
                return Ok(new BaseModel() { RtnCode = result.RtnCode, RtnMsg = result.RtnMsg });
            }

            // 產生 JWT token
            var token = _authenticationService.GenerateJwtToken(result);

            return Ok(new { Token = token });
        }
    }
}
