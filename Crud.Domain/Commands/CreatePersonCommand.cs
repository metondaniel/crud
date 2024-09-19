using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Crud.Domain.Commands
{
    public class CreatePersonCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
