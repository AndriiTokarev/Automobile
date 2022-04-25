using System;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MediatR;

namespace API.Application.Handlers.Cars
{
    public class Create
    {
        public class Command : IRequest<Unit>
        {
            public Car Car { get; set; }
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
                var car = request.Car;
                car.Id = new Guid();
                await _context.AddAsync(request.Car);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}