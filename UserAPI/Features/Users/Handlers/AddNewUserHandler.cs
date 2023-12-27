using MediatR;
using UserAPI.Data;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Features.Users
{
    public class AddNewUserHandler : IRequestHandler<AddNewUserCommand, ResponseModel>
    {
            private readonly IUserService _db;

            public AddNewUserHandler(IUserService db) => _db = db;
            public async Task<ResponseModel> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
            {
                ResponseModel response = new();
                try
                {
                    var response1 = await _db.AddUser(request.user);
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
            //await _db.AddUser(request.user);
            //return Unit.Value;
        }
        
    }
}
