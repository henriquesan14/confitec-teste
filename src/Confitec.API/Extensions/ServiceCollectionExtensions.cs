using Confitec.Core.Repositories;
using Confitec.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.API.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
