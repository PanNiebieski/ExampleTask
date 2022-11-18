using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.CQRS
{
    public static partial class AppInstaller
    {
        public static IServiceCollection AddLiteSmallConferenceCQRS
            (this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
