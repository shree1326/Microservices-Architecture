using MediatR;
using UserAPI.Data;
using UserAPI.Features.EFCore.Command;
using UserAPI.Features.Users.Commands;

namespace UserAPI.Features.EFCore.Handler
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, int>
    {
        private DbContextClass context;
        public UpdateHandler(DbContextClass context)
        {
            this.context = context;
        }
        public async Task<int> Handle(UpdateCommand command, CancellationToken cancellationToken)
        {
            var user = context.Users.Where(a => a.UserId == command.UserId).FirstOrDefault();

            if (user == null)
            {
                return default;
            }
            else
            {
                user.UserName = command.UserName;
                user.Address = command.Address;
               
                await context.SaveChangesAsync();
                return user.UserId;
            }
        }
    }
}
