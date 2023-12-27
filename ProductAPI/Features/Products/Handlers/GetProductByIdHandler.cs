using MediatR;
using ProductAPI.Data;
using ProductAPI.Exceptions;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Features.Products
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ResponseModel>
    {
            private readonly IProductService _db;

            public GetProductByIdQueryHandler(IProductService db) => _db = db;
        public async Task<ResponseModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            ResponseModel response = new();
            try
            {
                var response1 = await _db.GetProductById(request.Id);
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
            //var productbyid = _db.GetProductById(request.Id);
            //return productbyid;
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
