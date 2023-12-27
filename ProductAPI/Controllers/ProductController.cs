//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using ProductAPI.Features.EFCore.Command;
//using ProductAPI.Features.EFCore.Queries;
//using ProductAPI.Features.Products;
//using ProductAPI.Features.Products.Commands;
//using ProductAPI.Models;
//using ProductAPI.Services;
//namespace ProductAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductController : ControllerBase
//    {
//        private readonly IMediator _mediator;
//        public ProductController(IMediator mediator) => _mediator = mediator;
//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            return Ok(await _mediator.Send(new GetAllQuery()));
//        }
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            return Ok(await _mediator.Send(new GetByIdQuery { Id = id }));
//        }
//        [HttpPost]
//        public async Task<IActionResult> Create(CreateProductCommand command)
//        {
//            return Ok(await _mediator.Send(command));
//        }
//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(int id, UpdateCommand command)
//        {
//            command.ProductId = id;
//            return Ok(await _mediator.Send(command));
//        }
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            return Ok(await _mediator.Send(new DeleteByIdCommand { Id = id }));
//        }
//    }
//}