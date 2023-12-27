using MediatR;

namespace UserAPI.Features.EFCore.Command
{
    public class UpdateCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
    }
}
