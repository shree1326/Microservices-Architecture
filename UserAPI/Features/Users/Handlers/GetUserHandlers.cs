using MediatR;
using Microsoft.EntityFrameworkCore;
using Ocelot.Responses;
using UserAPI.Data;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Features.Users
{

    public class GetUserHandler : IRequestHandler<GetUserQuery, ResponseModel>
    {
        private readonly IUserService _db;

        public GetUserHandler(IUserService db) => _db = db;

        public async Task<ResponseModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            ResponseModel response = new();
            try
            {
               var response1 = await _db.GetUserList(request.PageNumber, request.PageSize, request.order);
                response.IsSuccess = true;
                response.Message = ResponseMessages.RecordFound;
                response.Response = response1;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"{ResponseMessages.ExceptionOccured}{ex.Message}";
                return response;
            }
            // await _db.GetUserList(request.PageNumber, request.PageSize, request.order );

        }
        
    }
}
