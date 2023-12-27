using MediatR;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Features.Products.Commands
{
    public class DeleteProductByIdCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }
        public DeleteProductByIdCommand(int id)
        {
            Id = id;
        }

    }
}
