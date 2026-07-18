using ChatSystem.Application.Common;
using ChatSystem.Application.Features.Users.GetUsers;
using ChatSystem.Application.Features.Users.Login;
using ChatSystem.Application.Features.Users.Register;
using ChatSystem.Application.Features.Users.UploadAvatar;
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
        private readonly IUploadAvatarUseCase _uploadAvatarUseCase;

        public UserController(IRegisterUseCase registerUseCase, ILoginUseCase loginUseCase, IGetUsersUseCase getUsersUseCase , IUploadAvatarUseCase uploadAvatarUseCase)
        {
            _registerUseCase = registerUseCase;
            _loginUseCase = loginUseCase;
            _getUsersUseCase = getUsersUseCase;
            _uploadAvatarUseCase = uploadAvatarUseCase;
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

        [HttpPost("avatar")]
        public async Task<IActionResult> UploadAvatar(
            [FromForm] IFormFile file,
            [FromForm] Guid userId,
            CancellationToken cancellationToken)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new
                {
                    message = "File is required"
                });
            }

            await using var stream = file.OpenReadStream();


            var result = await _uploadAvatarUseCase.ExecuteAsync(
                userId,
                stream,
                file.FileName,
                cancellationToken);


            if (!result.IsSuccess)
            {
                return BadRequest(new
                {
                    message = result.ErrorMessage
                });
            }


            return Ok(new
            {
                avatarUrl = result.Data
            });
        }

    }
}
