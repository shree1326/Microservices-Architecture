using MediatR;
using UserAPI.Data;
using UserAPI.Exceptions;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Features.Users
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResponseModel>
    {
            private readonly IUserService _db;

            public GetUserByIdQueryHandler(IUserService db) => _db = db;
       public async Task<ResponseModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            ResponseModel response = new();
            try
            {
                var response1 = await _db.GetUserById(request.Id);
                response.IsSuccess = true;
                response.Message = ResponseMessages.RecordFound;
                response.Response = response1;
                if (response1.Count() == 0)
                {
                    throw new NotFoundException($"Product ID {request.Id} not found.");
                }
                return response;
               
            }
            catch (Exception ex)
            {
                response.Message = $"{ResponseMessages.ExceptionOccured}{ex.Message}";
                return response;
            }
            //var userbyid = _db.GetUserById(request.Id);
            //return userbyid;
        }


        //public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
        // await _db.GetProductById(request.Id);

        //public async Task<IEnumerable<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        //{
        //    await _db.GetProductById(request.ProductId);

        //    return request;
        //}


    }
    
}
