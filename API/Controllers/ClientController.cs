using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Application.Handlers.Clients;
using API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers 
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/client/list")]
        public async Task<ActionResult<List<Client>>> List()
        {
            return await _mediator.Send(new List.Query());
        }
        [HttpPost("/client/create")]
        public async Task<ActionResult<Unit>> Create(Client client)
        {
            return await _mediator.Send(new Create.Command {Client = client});
        }
        [HttpDelete("/client/delete")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await _mediator.Send(new Delete.Command {Id = id});
        }
    }
}