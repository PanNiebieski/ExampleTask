using Example.Application.CQRS.Developers.Command.AddDeveloper;
using Example.Application.CQRS.Developers.Command.DeleteDeveloper;
using Example.Application.CQRS.Developers.Command.UpdateDeveloper;
using Example.Application.CQRS.Developers.Queries.GetAllDevelopers;
using Example.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleDeveloperApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<DeveloperController> _logger;
        public DeveloperController(ILogger<DeveloperController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("all/{filter}", Name = "getalldevelopers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<Developer>>> GetAllDevelopers(int filter)
        {
            _logger.LogInformation("GetAllDevelopers at {DT}",
                DateTime.UtcNow.ToLongTimeString());

            GetAllDevelopersQuery getAllDevelopersQuery = new GetAllDevelopersQuery()
            { Filter = (FilterDeveloperStatus)filter };

            var result = await _mediator.Send(getAllDevelopersQuery);

            if (result.Result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result.Result);

        }

        [HttpPost("updated", Name = "updateddevelopers")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<int>> Updated([FromBody] Developer developer)
        {
            _logger.LogInformation("updateddevelopers at {DT}",
                DateTime.UtcNow.ToLongTimeString());

            UpdateDeveloperCommand updateDeveloperCommand = new UpdateDeveloperCommand();
            updateDeveloperCommand.Developer = developer;

            var result = await _mediator.Send(updateDeveloperCommand);

            if (result.Success)
                return NoContent();
            else
                return BadRequest();

        }

        [HttpPost("Add", Name = "adddevelopers")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> Add([FromBody] AddDeveloperCommand command)
        {
            _logger.LogInformation("adddevelopers at {DT}",
                DateTime.UtcNow.ToLongTimeString());

            if (command == null)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.Id);
        }

        [HttpDelete("Delete", Name = "deletedevelopers")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<int>> Delete([FromBody] int id)
        {
            _logger.LogInformation("deletedevelopers at {DT}",
                DateTime.UtcNow.ToLongTimeString());

            DeleteDeveloperCommand deleteDeveloper = new DeleteDeveloperCommand()
            { DeveloperId = id };

            var result = await _mediator.Send(deleteDeveloper);

            return NoContent();

        }
    }
}