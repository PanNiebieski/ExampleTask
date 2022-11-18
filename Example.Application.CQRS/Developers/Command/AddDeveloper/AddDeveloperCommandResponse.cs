using Example.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.CQRS.Developers.Command.AddDeveloper
{
    public class AddDeveloperCommandResponse
    {
        public AddDeveloperCommandResponse(DeveloperId id)
        {
            Id = id;
            Success = true;
            ValidationErrors = new List<string>();
        }

        public DeveloperId Id { get; }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
