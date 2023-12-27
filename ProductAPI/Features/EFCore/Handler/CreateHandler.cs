using MediatR;
using ProductAPI.Data;
using ProductAPI.Features.EFCore.Command;
using ProductAPI.Models;

namespace ProductAPI.Features.EFCore.Handler
{
    public class CreateHandler : IRequestHandler<CreateProductCommand, int>
    {
        private DBContextClass context;
        public CreateHandler(DBContextClass context)
        {
            this.context = context;
        }
        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product();
            product.ProductName = command.ProductName;
            product.ProductDescription = command.ProductDescription;
            product.ProductPrice = command.ProductPrice;
            product.ProductStock = command.ProductStock;

            context.Products.Add(product);
            await context.SaveChangesAsync();
            return product.ProductId;
        }
    }
}
