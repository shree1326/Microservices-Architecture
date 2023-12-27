using MediatR;
using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Features.EFCore.Command
{
    public class CreateUserCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        
    }
}
