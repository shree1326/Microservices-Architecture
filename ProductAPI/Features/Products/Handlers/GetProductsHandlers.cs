using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Features.Products
{

    public class GetProductsHandler : IRequestHandler<GetProductsQuery, ResponseModel>
    {
        private readonly IProductService _db;

        public GetProductsHandler(IProductService db) => _db = db;

        public async Task<ResponseModel> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            ResponseModel response = new();
            try
            {
                var response1 = await _db.GetProductList(request.PageNumber, request.PageSize, request.order);
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
        }
            //=> await _db.GetProductList(request.PageNumber, request.PageSize, request.order );
        
    }
}
