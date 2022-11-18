using Example.Application.Contracts;
using Example.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.CQRS.Developers.Command.AddDeveloper
{
    public class AddDeveloperCommandHandler
                :
        IRequestHandler<AddDeveloperCommand,
            AddDeveloperCommandResponse>
    {

        private readonly IDeveloperRepository _repository;

        public AddDeveloperCommandHandler(IDeveloperRepository Repository)
        {
            _repository = Repository;
        }

        public async Task<AddDeveloperCommandResponse> Handle
            (AddDeveloperCommand request, CancellationToken cancellationToken)
        {
            Developer d = new Developer();

            d.Name = request.Name;
            d.Status = request.Status;

            var id = await _repository.AddAsync(d);

            return new AddDeveloperCommandResponse(id);
        }
    }
}
