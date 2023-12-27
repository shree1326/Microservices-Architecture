using MediatR;
using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Features.EFCore.Command;
using UserAPI.Data;

namespace UserAPI.Features.EFCore.Handler
{
    public class DeleteByIdHandler : IRequestHandler<DeleteByIdCommand, int>
    {
        private DbContextClass context;
        public DeleteByIdHandler(DbContextClass context)
        {
            this.context = context;
        }
        public async Task<int> Handle(DeleteByIdCommand command, CancellationToken cancellationToken)
        {
            var user = await context.Users.Where(a => a.UserId == command.Id).FirstOrDefaultAsync();
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return user.UserId;
        }
    }
}
