using MediatR;

namespace ProductAPI.Features.EFCore.Command
{
    public class UpdateCommand : IRequest<int>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int ProductStock { get; set; }
    }
}
