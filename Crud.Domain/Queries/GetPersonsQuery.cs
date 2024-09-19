﻿using Crud.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain.Queries
{
    public class GetPersonsQuery : IRequest<List<Person>>
    {
    }
}
