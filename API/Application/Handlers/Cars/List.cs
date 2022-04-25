using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Handlers.Cars
{
    public class List 
    {
        public class Query : IRequest<List<Car>> {}
        public class Handler : IRequestHandler<Query, List<Car>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Car>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Cars.ToListAsync();
            }
        }
    }
}