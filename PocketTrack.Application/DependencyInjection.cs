using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PocketTrack.Application.Events.Expenses;
using PocketTrack.Application.UseCases.Expense;
using PocketTrack.Application.UseCases.ExpenseType;

namespace PocketTrack.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddEvents()
                .AddUseCases();

            return services;
        }

        private static IServiceCollection AddEvents(this IServiceCollection services)
        {
            // Events
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ExpenseCreatedHandler).Assembly);
            });

            return services;
        }

        private static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            // Expense Types
            services.AddScoped<GetAllExpenseTypesUseCase>();

            // Expense
            services.AddScoped<AddExpenseUseCase>();
            services.AddScoped<GetAllExpenseUseCase>();

            return services;
        }
    }
}
