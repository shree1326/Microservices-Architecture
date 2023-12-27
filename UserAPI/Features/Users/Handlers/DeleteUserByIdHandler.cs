using MediatR;
using UserAPI.Data;
using UserAPI.Exceptions;
using UserAPI.Features.Users.Commands;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Features.Users
{
    public class DeleteUserByIdQueryHandler : IRequestHandler<DeleteUserByIdCommand, ResponseModel>
    {
        private readonly IUserService _db;

        public DeleteUserByIdQueryHandler(IUserService db) => _db = db;
        public async Task<ResponseModel>Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            ResponseModel response = new();
            try
            {
                var response1 = await _db.DeleteUser(request.Id);
                response.IsSuccess = true;
                if (response.IsSuccess = true)
                {
                    response.Message = ResponseMessages.DeletedRecord;
                }
                if (response1==1)
                {
                    response.Response = ResponseMessages.Success;
                }
                if (response1 == 0)
                {
                    throw new NotFoundException($"Product ID {request.Id} not found.");
                }
                //response.Response = response1;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"{ResponseMessages.ExceptionOccured}{ex.Message}";
                return response;
            }
            //var userbyid = _db.DeleteUser(request.Id);
            //return userbyid;
        }
    }
}
