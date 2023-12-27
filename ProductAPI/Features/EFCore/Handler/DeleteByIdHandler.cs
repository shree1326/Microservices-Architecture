using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Features.EFCore.Command;

namespace ProductAPI.Features.EFCore.Handler
{
    public class DeleteByIdHandler : IRequestHandler<DeleteByIdCommand, int>
    {
        private DBContextClass context;
        public DeleteByIdHandler(DBContextClass context)
        {
            this.context = context;
        }
        public async Task<int> Handle(DeleteByIdCommand command, CancellationToken cancellationToken)
        {
            var product = await context.Products.Where(a => a.ProductId == command.Id).FirstOrDefaultAsync();
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return product.ProductId;
        }
    }
}
