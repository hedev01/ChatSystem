using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSystem.Application.Interfaces
{
    public interface IFileStorage
    {
        Task<string> Upload(
            Stream stream,
            string fileName,
            string path,
            CancellationToken cancellationToken);
    }
}
