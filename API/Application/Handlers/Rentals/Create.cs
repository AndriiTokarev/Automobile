using System;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MediatR;

namespace API.Application.Handlers.Rentals
{
    public class Create
    {
        public class Command : IRequest<Unit>
        {
            public Rental Rental { get; set; }
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
                var rental = request.Rental;
                rental.Id = new Guid();
                await _context.AddAsync(request.Rental);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}