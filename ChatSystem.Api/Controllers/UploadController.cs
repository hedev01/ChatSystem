using ChatSystem.Application.Features.Upload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IUploadUsecase _usecase;

        public UploadController(IUploadUsecase usecase)
        {
            _usecase = usecase;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromForm] Guid userId , CancellationToken cancellationToken)
        {
            if (file.Length == 0)
            {
                return BadRequest(new
                {
                    message = "File is required"
                });
            }

            await using var stream = file.OpenReadStream();


            var result = await _usecase.ExecuteAsync(
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
                url = result.Data
            });
        }
    }
}
