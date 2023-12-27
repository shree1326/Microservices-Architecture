using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Features.Products
{
    public record GetProductsQuery(int PageNumber, int PageSize, string order) : IRequest<ResponseModel>;
          
    
}
