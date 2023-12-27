using MediatR;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Features.Products
{
    public record AddNewProductCommand(Product product) : IRequest<ResponseModel>;
}
