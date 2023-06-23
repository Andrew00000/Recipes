using Recepies.Application.Repositories;
using Recepies.Application.Services;
using Recepies.Infrastructure.Repository;
using Recepies.Infrastructure.Service;

namespace Recepies.Infrastructure
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IRecepiRepository, RecepiRepository>();
            services.AddSingleton<IRecepiService, RecipeService>();
            return services;
        }
    }
}
