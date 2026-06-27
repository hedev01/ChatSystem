using ChatSystem.Application.Common;
using ChatSystem.Application.Features.Users.GetUsers;
using ChatSystem.Application.Features.Users.Login;
using ChatSystem.Application.Features.Users.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRegisterUseCase _registerUseCase;
        private readonly ILoginUseCase _loginUseCase;
        private readonly IGetUsersUseCase _getUsersUseCase;

        public UserController(IRegisterUseCase registerUseCase, ILoginUseCase loginUseCase, IGetUsersUseCase getUsersUseCase)
        {
            _registerUseCase = registerUseCase;
            _loginUseCase = loginUseCase;
            _getUsersUseCase = getUsersUseCase;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var validator = new RegisterValidator();

            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
            {
                var errors = string.Join(" | ", validatorResult.Errors.Select(e => e.ErrorMessage));
                return Ok(
                    Result<RegisterResponse>
                        .Failure(errors));
            }

            var result = await _registerUseCase.Register(request);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var validtor = new LoginValidator();
            var validatorResult = await validtor.ValidateAsync(request);
            if (!validatorResult.IsValid)
            {
                var errors = string.Join(" | ", validatorResult.Errors.Select(e => e.ErrorMessage));
                return Ok(
                    Result<LoginResponse>
                        .Failure(errors));
            }

            var result = await _loginUseCase.Login(request);
            return Ok(result);

        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUserAsync(Guid userId)
        {
            var result = await _getUsersUseCase.GetUsersAsync(userId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }

    }
}
