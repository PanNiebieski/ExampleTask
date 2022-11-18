using Example.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.CQRS.Developers.Queries.GetAllDevelopers
{
    public class GetAllDevelopersQueryResponse
    {
        public GetAllDevelopersQueryResponse(IReadOnlyList<Developer> result)
        {
            Result = result;
        }

        public IReadOnlyList<Developer> Result { get; }
    }
}
