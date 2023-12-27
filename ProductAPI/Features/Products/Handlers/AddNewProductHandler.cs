using MediatR;
using ProductAPI.Data;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Features.Products
{
    public class AddNewProductHandler: IRequestHandler<AddNewProductCommand, ResponseModel>
    {
            private readonly IProductService _db;

            public AddNewProductHandler(IProductService db) => _db = db;
            public async Task<ResponseModel> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
            {
                ResponseModel response = new();
            try
            {
                var response1 = await _db.AddProduct(request.product);
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
            //await _db.AddProduct(request.product);
            //return Unit.Value;
        }
        
    }
}
