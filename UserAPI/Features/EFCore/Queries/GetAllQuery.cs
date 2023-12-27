using MediatR;
using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Features.EFCore.Queries
{
    public record GetAllQuery(int PageNumber, int PageSize, string order) : IRequest<IEnumerable<User>>
    {
        
    }
}
