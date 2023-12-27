using MediatR;
using ProductAPI.Features.Products;
using ProductAPI.Models;

namespace ProductAPI.Features.EFCore.Queries
{
    public class GetByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        
    }
}
