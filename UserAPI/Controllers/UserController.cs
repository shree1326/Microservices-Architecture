//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using UserAPI.Features.EFCore.Command;
//using UserAPI.Features.EFCore.Queries;
//using UserAPI.Features.Users;
//using UserAPI.Features.Users.Commands;
//using UserAPI.Models;
//using UserAPI.Services;
//namespace UserAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IMediator _mediator;
//        public UserController(IMediator mediator) => _mediator = mediator;
//        [HttpGet]
//        public async Task<IActionResult> GetAll(int PageNumber, int PageSize, string order)
//        {
//            return Ok(await _mediator.Send(new GetAllQuery(PageNumber, PageSize, order)));
//        }
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            return Ok(await _mediator.Send(new GetByIdQuery { Id = id }));
//        }
//        [HttpPost]
//        public async Task<IActionResult> Create(CreateUserCommand command)
//        {
//            return Ok(await _mediator.Send(command));
//        }
//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(int id, UpdateCommand command)
//        {
//            command.UserId = id;
//            return Ok(await _mediator.Send(command));
//        }
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            return Ok(await _mediator.Send(new DeleteByIdCommand { Id = id }));
//        }
//    }
//}