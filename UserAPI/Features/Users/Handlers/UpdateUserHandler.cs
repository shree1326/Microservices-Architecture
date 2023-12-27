using MediatR;
using Ocelot.RequestId;
using UserAPI.Features.Users.Commands;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Features.Users.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResponseModel>
    {
        private IUserService _db;
        public UpdateUserHandler(IUserService db)
        {
            this._db = db;
        }
        public async Task<ResponseModel> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            ResponseModel response = new();
            try
            {
                var response1 = await _db.UpdateUser(command.user);
                response.IsSuccess = true;
                if (response.IsSuccess = true)
                {
                    response.Message = ResponseMessages.UpdatedRecord;
                }
                if (response1==1)
                {
                    response.Response = ResponseMessages.Success;
                }
               //response.Response = response1;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"{ResponseMessages.ExceptionOccured}{ex.Message}";
                return response;
            }

            //await _db.UpdateUser(command.user);
            //return Unit.Value;
        }
    }
}
