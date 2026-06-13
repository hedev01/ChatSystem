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

        public UserController(IRegisterUseCase registerUseCase)
        {
            _registerUseCase = registerUseCase;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var validator = new RegisterValidator();

            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid) return BadRequest(validatorResult.Errors);

            var result = await _registerUseCase.Register(request);
            return Ok(result);
        }

    }
}
