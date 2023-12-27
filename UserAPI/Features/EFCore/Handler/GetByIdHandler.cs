using MediatR;
using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Features.EFCore.Queries;
using UserAPI.Features.Users;
using UserAPI.Models;

namespace UserAPI.Features.EFCore.Handler
{
    public class GetUserByIdHandler : IRequestHandler<GetByIdQuery, User>
    {
        private DbContextClass context;
        public GetUserByIdHandler(DbContextClass context)
        {
            this.context = context;
        }
        public async Task<User> Handle(GetByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await context.Users.Where(a => a.UserId == query.Id).FirstOrDefaultAsync();
            return user;
        }
    }
}
