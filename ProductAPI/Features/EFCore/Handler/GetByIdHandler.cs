using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Features.EFCore.Queries;
using ProductAPI.Features.Products;
using ProductAPI.Models;

namespace ProductAPI.Features.EFCore.Handler
{
    public class GetProductByIdHandler : IRequestHandler<GetByIdQuery, Product>
    {
        private DBContextClass context;
        public GetProductByIdHandler(DBContextClass context)
        {
            this.context = context;
        }
        public async Task<Product> Handle(GetByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await context.Products.Where(a => a.ProductId == query.Id).FirstOrDefaultAsync();
            return product;
        }
    }
}
