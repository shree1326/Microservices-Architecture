using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ocelot.Responses;
using UserAPI.Exceptions;
using UserAPI.Features.Users;
using UserAPI.Features.Users.Commands;
using UserAPI.Models;


namespace UserAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;
        private readonly IMediator _mediator;
        public UsersController(ILogger<UsersController> logger, IMediator mediator)
        {
            this.logger = logger;
            _mediator = mediator;
        }
        
        //public UsersController(IMediator mediator) => _mediator = mediator;

        [HttpGet] //Roles = UserRoles.Admin, 
       // [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ResponseModel>> GetUserList([FromQuery] int PageNumber, int PageSize, string order)
        {
            logger.LogDebug("Inside GetUserList endpoint");
            ResponseModel response = new();
            try
            {
                var user = await _mediator.Send(new GetUserQuery(PageNumber, PageSize, order));
                logger.LogDebug($"The response for the get User List is { JsonConvert.SerializeObject(user)}");
                return Ok(user);
            }
            catch (Exception ex)
            {
                response.Message = ResponseMessages.ExceptionOccured + ex.Message;
                logger.LogDebug($"The response for the Get User List is {JsonConvert.SerializeObject(response)}");
                return BadRequest(response);
            }
            //var user = await _mediator.Send(new GetUserQuery(PageNumber, PageSize, order));
            //return Ok(user);
        }
        [HttpGet("{id}")]
      //  [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ResponseModel>> GetUserById([FromRoute] int id)
        {
            logger.LogDebug("Inside GetUserById endpoint");
            ResponseModel response = new();
            try
            {
                var user = await _mediator.Send(new GetUserByIdQuery(id));
                logger.LogDebug($"The response for the Get User List by Id is {JsonConvert.SerializeObject(user)}");
                return Ok(user);
            }
            catch (Exception ex)
            {
                response.Message = ResponseMessages.ExceptionOccured + ex.Message;
                logger.LogDebug($"The response for the Get User List by Id is {JsonConvert.SerializeObject(response)}");
                return BadRequest(response);
            }
            //var user = await _mediator.Send(new GetUserByIdQuery(id));
            //return user;
        }
        [HttpPost]
       // [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ResponseModel>> AddUser([FromBody] User user)
        {
            logger.LogDebug("Inside AddUser endpoint");
            ResponseModel response = new();
            try
            {
                var user1 = await _mediator.Send(new AddNewUserCommand(user));
                logger.LogDebug($"The response for the Add User is {JsonConvert.SerializeObject(user1)}");
                return Ok(user1);
            }
            catch (Exception ex)
            {
                response.Message = ResponseMessages.ExceptionOccured + ex.Message;
                logger.LogDebug($"The response for the Add User is {JsonConvert.SerializeObject(response)}");
                return BadRequest(response);
            }
            //await _mediator.Send(new AddNewUserCommand(user));
            //return StatusCode(200);
        }
        [HttpDelete("{id}")]
       // [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ResponseModel>> Delete([FromRoute] int id)
        {
            logger.LogDebug("Inside Delete endpoint");
            ResponseModel response = new();
            try
            {
                var user = await _mediator.Send(new DeleteUserByIdCommand(id));
                logger.LogDebug($"The response for the Delete User List by Id is {JsonConvert.SerializeObject(user)}");
                return Ok(user);
            }
            catch (Exception ex)
            {
                response.Message = ResponseMessages.ExceptionOccured + ex.Message;
                logger.LogDebug($"The response for the Delete User List is {JsonConvert.SerializeObject(response)}");
                return BadRequest(response);
            }
            //await _mediator.Send(new DeleteUserByIdCommand(UserId));
            //return NoContent();
        }
        [HttpPut]
       // [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ResponseModel>> UpdateUser([FromBody] User user)
        {
            logger.LogDebug("Inside UpdateUser endpoint");
            ResponseModel response = new();
            try
            {
                var user1 = await _mediator.Send(new UpdateUserCommand(user));
                logger.LogDebug($"The response for the Update User is {JsonConvert.SerializeObject(user1)}");
                return Ok(user1);
            }
            catch (Exception ex)
            {
                response.Message = ResponseMessages.ExceptionOccured + ex.Message;
                logger.LogDebug($"The response for the Update User is {JsonConvert.SerializeObject(response)}");
                return BadRequest(response);
            }
            //await _mediator.Send(new UpdateUserCommand(user));
            //return StatusCode(200);
        }
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
