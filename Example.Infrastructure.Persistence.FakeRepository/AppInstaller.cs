using Example.Application.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Infrastructure.Persistence.FakeRepository
{
    public static partial class AppInstaller
    {
        public static IServiceCollection
    AddFakeRepositoriesServices
    (this IServiceCollection services,
    IConfiguration configuration)
        {
            services.AddSingleton<IDeveloperRepository, FakeDeveloperRepository>();

            return services;
        }
    }
}