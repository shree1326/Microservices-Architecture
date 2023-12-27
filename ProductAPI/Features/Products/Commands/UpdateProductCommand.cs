using MediatR;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Features.Products.Commands
{
    public record UpdateProductCommand(Product product) : IRequest<ResponseModel>;
}
