using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.CQRS.Developers.Command.UpdateDeveloper
{
    public class UpdateDeveloperCommandResponse
    {
        public UpdateDeveloperCommandResponse()
        {
            Success = true;

        }

        public UpdateDeveloperCommandResponse(bool s)
        {
            Success = s;

        }

        public bool Success { get; set; }

        public string Error { get; set; }
    }
}
