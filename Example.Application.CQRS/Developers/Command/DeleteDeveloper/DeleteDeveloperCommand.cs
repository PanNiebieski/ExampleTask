using Example.Application.CQRS.Developers.Command.AddDeveloper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.CQRS.Developers.Command.DeleteDeveloper
{
    public class DeleteDeveloperCommand : IRequest<DeleteDeveloperCommandResponse>
    {
        public int DeveloperId { get; set; }
    }
}
