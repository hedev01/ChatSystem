using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.Common;
using ChatSystem.Application.Interfaces;
using ChatSystem.Domain.Interfaces;

namespace ChatSystem.Application.Features.Users.UploadAvatar
{
    public class UploadAvatarUseCase : IUploadAvatarUseCase
    {
        private readonly IUserRepository _repository;
        private readonly IFileStorage _storage;

        public UploadAvatarUseCase(
            IUserRepository repository,
            IFileStorage storage)
        {
            _repository = repository;
            _storage = storage;
        }
        public async Task<Result<string>> ExecuteAsync(Guid userId, Stream stream, string fileName, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUser(userId);
            if (user == null) return Result<string>.Failure("User Not Found");
            var avatarUrl = await _storage.Upload(
                stream,
                fileName,
                "avatars",
                cancellationToken);

            user.UpdateAvatar(avatarUrl);

            await _repository.UpdateAsync(user);
            return Result<string>.Success(avatarUrl);
        }
    }
}
