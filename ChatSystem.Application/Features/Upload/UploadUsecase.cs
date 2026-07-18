using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.Common;
using ChatSystem.Application.Interfaces;
using ChatSystem.Domain.Interfaces;
using Microsoft.Identity.Client.Extensions.Msal;

namespace ChatSystem.Application.Features.Upload
{
    public class UploadUsecase : IUploadUsecase
    {
        private readonly IFileStorage _storage;
        private readonly IUserRepository _repository;

        public UploadUsecase(IFileStorage storage, IUserRepository repository)
        {
            _storage = storage;
            _repository = repository;
        }
        public async Task<Result<string>> ExecuteAsync(Guid userId, Stream stream, string fileName, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUser(userId);
            if (user == null) return Result<string>.Failure("User Not Found");
            var url = await _storage.Upload(
                stream,
                fileName,
                "media",
                cancellationToken);

            

            return Result<string>.Success(url);
        }
    }
}
