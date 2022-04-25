using System;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MediatR;

namespace API.Application.Handlers.Clients
{
    public class Create
    {
        public class Command : IRequest<Unit>
        {
            public Client Client { get; set; }
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var client = request.Client;
                client.Id = new Guid();
                await _context.AddAsync(request.Client);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}