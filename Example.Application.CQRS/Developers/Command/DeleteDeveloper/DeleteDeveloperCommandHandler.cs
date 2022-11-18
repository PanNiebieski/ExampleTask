using Example.Application.Contracts;
using Example.Application.CQRS.Developers.Command.AddDeveloper;
using Example.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.CQRS.Developers.Command.DeleteDeveloper
{
    public class DeleteDeveloperCommandHandler
               :
        IRequestHandler<DeleteDeveloperCommand,
            DeleteDeveloperCommandResponse>
    {

        private readonly IDeveloperRepository _repository;

        public DeleteDeveloperCommandHandler(IDeveloperRepository Repository)
        {
            _repository = Repository;
        }

        public async Task<DeleteDeveloperCommandResponse> Handle
            (DeleteDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developerid = new DeveloperId(request.DeveloperId);

            await _repository.DeleteAsync(developerid);

            return new DeleteDeveloperCommandResponse();
        }
    }
}
