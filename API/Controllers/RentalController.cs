using System.Threading.Tasks;
using API.Application.Handlers.Rentals;
using API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/rental/create")]
        public async Task<ActionResult<Unit>> Create(Rental rental)
        {
            return await _mediator.Send(new Create.Command {Rental = rental});
        }
    }
}