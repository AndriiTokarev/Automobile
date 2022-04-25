using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Application.Handlers.Cars;
using API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/car/list")]
        public async Task<ActionResult<List<Car>>> List()
        {
            return await _mediator.Send(new List.Query());
        }
        [HttpPost("/car/create")]
        public async Task<ActionResult<Unit>> Create(Car car)
        {
            return await _mediator.Send(new Create.Command{Car = car});
        }
        [HttpDelete("/car/delete")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await _mediator.Send(new Delete.Command {Id = id});
        }
    }
}