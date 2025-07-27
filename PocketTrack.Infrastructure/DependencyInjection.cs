using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PocketTrack.Application.Interfaces;
using PocketTrack.Domain.Interfaces;
using PocketTrack.Infrastructure.Persistence;
using PocketTrack.Infrastructure.Persistence.Repositories;

namespace PocketTrack.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMySQLDb(configuration)
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddMySQLDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Expense Types
            services.AddScoped<IExpenseTypeRepository, ExpenseTypeRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            
            return services;
        }
    }
}
