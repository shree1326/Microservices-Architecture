using MediatR;
using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Features.Users.Commands
{
    public class DeleteUserByIdCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }
        public DeleteUserByIdCommand(int id)
        {
            Id = id;
        }

    }
}
