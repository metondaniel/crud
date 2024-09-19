using Crud.Domain.Commands;
using Crud.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePersonCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePersonCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletePersonCommand deletePersonCommand = new DeletePersonCommand();
            deletePersonCommand.Id = id;
            var result = await _mediator.Send(deletePersonCommand);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetPersonByIdQuery { Id = id });
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetPersonsQuery());
            return result != null ? Ok(result) : NotFound();
        }
    }
}
