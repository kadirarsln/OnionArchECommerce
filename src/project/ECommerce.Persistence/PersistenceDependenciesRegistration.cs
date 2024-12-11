using ECommerce.Persistence.Abstracts;
using ECommerce.Persistence.Concretes;
using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Persistence
{
    public static class PersistenceDependenciesRegistration
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlCon"));
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
