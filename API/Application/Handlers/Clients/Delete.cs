using System;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using MediatR;

namespace API.Application.Handlers.Clients
{
    public class Delete 
    {
        public class Command : IRequest<Unit>
        {
            public Guid Id { get; set; }
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
                var client = await _context.Clients.FindAsync(request.Id);

                _context.Clients.Remove(client);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}