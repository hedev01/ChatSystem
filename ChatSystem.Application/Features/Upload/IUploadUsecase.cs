using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.Common;

namespace ChatSystem.Application.Features.Upload
{
    public interface IUploadUsecase
    {
        Task<Result<string>> ExecuteAsync(Guid userId,
            Stream stream,
            string fileName,
            CancellationToken cancellationToken);
    }
}
