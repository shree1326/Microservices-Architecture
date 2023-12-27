using MediatR;
using UserAPI.Data;
using UserAPI.Models;
using UserAPI.Models;

namespace UserAPI.Features.Users
{
    //public record GetProductByIdQuery(int Id) : IRequest<Product>;
    public class GetUserByIdQuery : IRequest<ResponseModel>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

    }


}
