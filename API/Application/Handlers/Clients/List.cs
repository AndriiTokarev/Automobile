using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Handlers.Clients
{
    public class List 
    {
        public class Query : IRequest<List<Client>> {}
        public class Handler : IRequestHandler<Query, List<Client>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Client>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Clients.ToListAsync();
            }
        }
    }
}