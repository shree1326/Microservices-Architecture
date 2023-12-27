using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Features.EFCore.Queries
{
    public record GetAllQuery(int PageNumber, int PageSize, string order) : IRequest<IEnumerable<Product>>
    {
        
    }
}
