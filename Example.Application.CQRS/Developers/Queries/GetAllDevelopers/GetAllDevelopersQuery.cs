using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.CQRS.Developers.Queries.GetAllDevelopers
{
    public class GetAllDevelopersQuery :
        IRequest<GetAllDevelopersQueryResponse>
    {
        public FilterDeveloperStatus Filter { get; set; }
    }

    public enum FilterDeveloperStatus
    {
        All = 0,
        New = 1,
        Accepted = 2,
        Rejected = 3,
    }
}
