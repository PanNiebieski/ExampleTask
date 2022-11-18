using Example.Application.Contracts;
using Example.Application.CQRS.Developers.Command.DeleteDeveloper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.CQRS.Developers.Command.UpdateDeveloper
{
    public class UpdateDeveloperCommandHandler
                 :
        IRequestHandler<UpdateDeveloperCommand,
            UpdateDeveloperCommandResponse>
    {
        private readonly IDeveloperRepository _repository;

        public UpdateDeveloperCommandHandler(IDeveloperRepository Repository)
        {
            _repository = Repository;
        }


        public async Task<UpdateDeveloperCommandResponse> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
        {
            if (request.Developer == null)
                return new UpdateDeveloperCommandResponse() { Success = false };

            await _repository.UpdateAsync(request.Developer);

            return new UpdateDeveloperCommandResponse(true);
        }
    }
}
