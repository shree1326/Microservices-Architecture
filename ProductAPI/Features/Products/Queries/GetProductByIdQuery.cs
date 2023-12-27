using MediatR;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Features.Products
{
    //public record GetProductByIdQuery(int Id) : IRequest<Product>;
    public class GetProductByIdQuery : IRequest<ResponseModel>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }

    }


}
