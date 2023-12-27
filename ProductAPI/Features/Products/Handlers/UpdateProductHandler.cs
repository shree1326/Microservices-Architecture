using MediatR;
using Ocelot.RequestId;
using ProductAPI.Features.Products.Commands;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Features.Products.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ResponseModel>
    {
        private IProductService _db;
        public UpdateProductHandler(IProductService db)
        {
            this._db = db;
        }
        public async Task<ResponseModel> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            ResponseModel response = new();
            try
            {
                var response1 = await _db.UpdateProduct(command.product);
                response.IsSuccess = true;
                if (response.IsSuccess = true)
                {
                    response.Message = ResponseMessages.UpdatedRecord;
                }
                if (response1 == 1)
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
            //await _db.UpdateProduct(command.product);
            //return Unit.Value;
        }
    }
}
