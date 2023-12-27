using MediatR;
using UserAPI.Data;
using UserAPI.Features.EFCore.Command;
using UserAPI.Models;

namespace UserAPI.Features.EFCore.Handler
{
    public class CreateHandler : IRequestHandler<CreateUserCommand, int>
    {
        private DbContextClass context;
        public CreateHandler(DbContextClass context)
        {
            this.context = context;
        }
        public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User();
            user.UserName = command.UserName;
            user.Address = command.Address;

            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user.UserId;
        }
    }
}
