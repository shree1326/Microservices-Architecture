using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Features.Products;
using ProductAPI.Features.Products.Commands;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly JwtSettings jwtSettings;
        //public ProductsController (JwtSettings jwtSettings)
        //{
        //    this.jwtSettings = jwtSettings;
        //}

        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator) => _mediator = mediator;
       
        [HttpGet]
       // [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ResponseModel>> GetProductList([FromQuery] int PageNumber, int PageSize, string order)
        {
            ResponseModel response = new();
            try
            {
                var Product = await _mediator.Send(new GetProductsQuery(PageNumber, PageSize, order));
                return Ok(Product);
            }
            catch (Exception ex)
            {
                response.Message = ResponseMessages.ExceptionOccured + ex.Message;
                return BadRequest(response);
            }
            //var products = await _mediator.Send(new GetProductsQuery(PageNumber, PageSize, order));
            //return Ok(products);
        }
        [HttpGet("{id}")]
       // [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ResponseModel>> GetProductById([FromRoute] int id)
        {
            ResponseModel response = new();
            try
            {
                var product = await _mediator.Send(new GetProductByIdQuery(id));
                return Ok(product);
            }
            catch (Exception ex)
            {
                response.Message = ResponseMessages.ExceptionOccured + ex.Message;
                return BadRequest(response);
            }
            //var product = await _mediator.Send(new GetProductByIdQuery(id));
            // return product;
        }
        [HttpPost]
       // [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ResponseModel>> AddProduct([FromBody] Product product)
        {
            ResponseModel response = new();
            try
            {
                var product1 = await _mediator.Send(new AddNewProductCommand(product));
                return Ok(product1);
            }
            catch (Exception ex)
            {
                response.Message = ResponseMessages.ExceptionOccured + ex.Message;
                return BadRequest(response);
            }
            //await _mediator.Send(new AddNewProductCommand(product));
            //return StatusCode(200);
        }
        [HttpDelete("{id}")]
        //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ResponseModel>> Delete([FromRoute] int id)
        {
            ResponseModel response = new();
            try
            {
                var Product = await _mediator.Send(new DeleteProductByIdCommand(id));
                return Ok(Product);
            }
            catch (Exception ex)
            {
                response.Message = ResponseMessages.ExceptionOccured + ex.Message;
                return BadRequest(response);
            }
            //await _mediator.Send(new DeleteProductByIdCommand(ProductId));
            //return NoContent();
        }
        [HttpPut]
       // [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ResponseModel>> UpdateProduct([FromBody] Product product)
        {
            ResponseModel response = new();
            try
            {
                var Product1 = await _mediator.Send(new UpdateProductCommand(product));
                return Ok(Product1);
            }
            catch (Exception ex)
            {
                response.Message = ResponseMessages.ExceptionOccured + ex.Message;
                return BadRequest(response);
            }
            //await _mediator.Send(new UpdateProductCommand(product));
            //return StatusCode(200);
        }

        
        //    [HttpPost]
        //public IActionResult GetToken(UserLogins userLogins)
        //{
        //    try
        //    {
        //        var Token = new UserTokens();
        //        var Valid = logins.Any(x => x.ProductName.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));
        //        if (Valid)
        //        {
        //            var user = logins.FirstOrDefault(x => x.ProductName.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));
        //            Token = JwtHelpers.JwtHelpers.GenTokenkey(new UserTokens()
        //            {
        //                EmailId = user.ProductDescription,
        //                //GuidId = Guid.NewGuid(),
        //                UserName = user.ProductName,
        //                //Id = user.ProductId,
        //            }, jwtSettings);
        //        }
        //        else
        //        {
        //            return BadRequest($"wrong password");
        //        }
        //        return Ok(Token);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //[HttpGet]
        //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        //public IActionResult GetList()
        //{
        //    return Ok(logins);
        //}
        //[HttpGet]
        //public List<Product> GetProducts() => await _mediator.Send(new GetProductsQuery());
        //[HttpGet("{id}")]
        //public async Task<Product> GetProductById(int productId) => await _mediator.Send(new GetProductById.Query {  ProductId = productId });
        //[HttpPost]
        //public async Task<ActionResult> CreateProduct([FromBody] AddNewProduct.Command command)
        //{
        //    var createdProductId = await _mediator.Send(command);
        //    return CreatedAtAction(nameof(GetProductById), new {productId = createdProductId}, null);
        //}
        //    [HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteProduct(int ProductId)
        //{
        //    await _mediator.Send(new DeleteProduct.Command{ ProductId = ProductId  });
        //    return NoContent();
        //}
    }
}
