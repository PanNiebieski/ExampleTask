using Example.Application.Contracts;
using Example.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.CQRS.Developers.Queries.GetAllDevelopers
{
    public class GetAllDevelopersQueryHandler
                :
        IRequestHandler<GetAllDevelopersQuery,
            GetAllDevelopersQueryResponse>
    {
        private readonly IDeveloperRepository _repository;

        public GetAllDevelopersQueryHandler(IDeveloperRepository Repository)
        {
            _repository = Repository;
        }


        public async Task<GetAllDevelopersQueryResponse> Handle(GetAllDevelopersQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetCollectionAsync();

            if (request.Filter == FilterDeveloperStatus.All)
            {
                return new GetAllDevelopersQueryResponse(result);
            }
            else if (request.Filter == FilterDeveloperStatus.New)
            {
                result = result.Where(k => k.Status == DeveloperStatus.New).ToList();
                return new GetAllDevelopersQueryResponse(result);
            }
            else if (request.Filter == FilterDeveloperStatus.Accepted)
            {
                result = result.Where(k => k.Status == DeveloperStatus.Accepted).ToList();
                return new GetAllDevelopersQueryResponse(result);
            }
            else if (request.Filter == FilterDeveloperStatus.Rejected)
            {
                result = result.Where(k => k.Status == DeveloperStatus.Rejected).ToList();
                return new GetAllDevelopersQueryResponse(result);
            }
            else
            {
                return new GetAllDevelopersQueryResponse(new List<Developer>());
            }




        }
    }
}
