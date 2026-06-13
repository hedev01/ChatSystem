using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSystem.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(string userName, Guid userId);
        string GenerateRefreshToken();
    }
}
