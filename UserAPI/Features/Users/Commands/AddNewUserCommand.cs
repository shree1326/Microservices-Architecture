using MediatR;
using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Features.Users
{
    public record AddNewUserCommand(User user) : IRequest<ResponseModel>;
}
