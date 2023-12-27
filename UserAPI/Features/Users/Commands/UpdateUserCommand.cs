using MediatR;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Features.Users.Commands
{
    public record UpdateUserCommand(User user) : IRequest<ResponseModel>;
}
