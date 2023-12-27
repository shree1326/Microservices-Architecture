using MediatR;
using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Features.Users
{
    public record GetUserQuery(int PageNumber, int PageSize, string order) : IRequest<ResponseModel>;
          
    
}
