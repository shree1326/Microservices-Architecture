using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Features.EFCore.Queries;
using UserAPI.Models;

namespace UserAPI.Features.EFCore.Handler
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, IEnumerable<User>>
    {
        private DbContextClass context;
        public GetAllHandler(DbContextClass context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<User>> Handle(GetAllQuery query, CancellationToken cancellationToken)
        {
            var productList = await context.Users.ToListAsync();
            return productList;
        }
      
    }
}
