using Example.Application.CQRS.Developers.Command.DeleteDeveloper;
using Example.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.CQRS.Developers.Command.UpdateDeveloper
{
    public class UpdateDeveloperCommand : IRequest<UpdateDeveloperCommandResponse>
    {

        public Developer Developer { get; set; }
    }
}
