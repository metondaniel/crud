using Crud.Domain.Models;
using Crud.Domain.Queries;
using Crud.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain.Handlers
{
    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, List<Person>>
    {
        private readonly ApplicationDbContext _context;

        public GetPersonsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Persons.ToListAsync();
        }
    }
}
