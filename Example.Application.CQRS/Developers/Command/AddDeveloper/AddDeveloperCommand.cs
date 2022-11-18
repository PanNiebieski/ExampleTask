using Example.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.CQRS.Developers.Command.AddDeveloper
{
    public class AddDeveloperCommand : IRequest<AddDeveloperCommandResponse>
    {
        public DeveloperStatus Status { get; set; }

        public string Name { get; set; }
    }
}
