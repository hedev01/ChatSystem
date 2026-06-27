using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.Common;
using ChatSystem.Domain.Interfaces;

namespace ChatSystem.Application.Features.Users.GetUsers
{
    public class GetUsersUseCase : IGetUsersUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUsersUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<List<GetUsersResponse>>> GetUsersAsync(Guid userId)
        {
            var result = await _userRepository.GetUsers(userId);

            if (result == null || !result.Any())
                return Result<List<GetUsersResponse>>.Failure("Users Not Found");

            var response = result.Select(user => new GetUsersResponse(
                user.UserId,
                user.FirstName,
                user.LastName,
                user.Email
            )).ToList();

            return Result<List<GetUsersResponse>>.Success(response);
        }
    }
}
