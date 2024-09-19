using Crud.Domain.Commands;
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
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeletePersonCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeletePersonCommand command, CancellationToken cancellationToken)
        {
            var person = await _dbContext.Persons.FirstOrDefaultAsync(p => p.Id == command.Id, cancellationToken);

            if (person == null)
                return false;

            _dbContext.Persons.Remove(person);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
