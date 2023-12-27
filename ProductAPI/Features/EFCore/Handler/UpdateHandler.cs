using MediatR;
using ProductAPI.Data;
using ProductAPI.Features.EFCore.Command;
using ProductAPI.Features.Products.Commands;

namespace ProductAPI.Features.EFCore.Handler
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, int>
    {
        private DBContextClass context;
        public UpdateHandler(DBContextClass context)
        {
            this.context = context;
        }
        public async Task<int> Handle(UpdateCommand command, CancellationToken cancellationToken)
        {
            var product = context.Products.Where(a => a.ProductId == command.ProductId).FirstOrDefault();

            if (product == null)
            {
                return default;
            }
            else
            {
                product.ProductName = command.ProductName;
                product.ProductDescription = command.ProductDescription;
                product.ProductPrice = command.ProductPrice;
                product.ProductStock = command.ProductStock;
                await context.SaveChangesAsync();
                return product.ProductId;
            }
        }
    }
}
