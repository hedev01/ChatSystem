using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace ChatSystem.Infrastructure.Storage
{
    public sealed class LocalFileStorage : IFileStorage
    {
        private readonly IWebHostEnvironment _environment;

        public LocalFileStorage(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<string> Upload(Stream stream, string fileName,string path, CancellationToken cancellationToken)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads", path);
            Directory.CreateDirectory(uploads);

            var extension = Path.GetExtension(fileName);

            var newName = $"{Guid.NewGuid()}{extension}";

            var fullPath = Path.Combine(uploads, newName);

            await using var file = File.Create(fullPath);

            await stream.CopyToAsync(file, cancellationToken);

            return $"/uploads/{path}/{newName}";
        }
    }
}
