using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain.Commands
{
    public class DeletePersonCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
