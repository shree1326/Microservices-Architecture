using MediatR;
using UserAPI.Features.Users;
using UserAPI.Models;

namespace UserAPI.Features.EFCore.Queries
{
    public class GetByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
        
    }
}
