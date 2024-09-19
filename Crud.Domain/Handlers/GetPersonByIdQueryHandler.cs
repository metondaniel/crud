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
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person>
    {
        private readonly ApplicationDbContext _context;

        public GetPersonByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Persons.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        }
    }
}
