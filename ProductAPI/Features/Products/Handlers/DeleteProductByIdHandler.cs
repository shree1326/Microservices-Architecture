using MediatR;
using ProductAPI.Data;
using ProductAPI.Exceptions;
using ProductAPI.Features.Products.Commands;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Features.Products
{
    public class DeleteProductByIdQueryHandler : IRequestHandler<DeleteProductByIdCommand, ResponseModel>
    {
        private readonly IProductService _db;

        public DeleteProductByIdQueryHandler(IProductService db) => _db = db;
        public async Task<ResponseModel>Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            ResponseModel response = new();
            try
            {
                var response1 = await _db.DeleteProduct(request.Id);
                response.IsSuccess = true;
                if (response.IsSuccess = true)
                {
                    response.Message = ResponseMessages.DeletedRecord;
                }
                if (response1 == 1)
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
            //var productbyid = _db.DeleteProduct(request.Id);
            //return productbyid;
        }
    }
}
