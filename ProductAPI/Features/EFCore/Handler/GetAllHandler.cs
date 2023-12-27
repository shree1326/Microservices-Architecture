using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Features.EFCore.Queries;
using ProductAPI.Models;

namespace ProductAPI.Features.EFCore.Handler
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, IEnumerable<Product>>
    {
        private DBContextClass context;
        public GetAllHandler(DBContextClass context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllQuery query, CancellationToken cancellationToken)
        {
            var productList = await context.Products.ToListAsync();
            return productList;
        }
    }
}
