using MediatR;

namespace UserAPI.Features.EFCore.Command
{
    public class DeleteByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
