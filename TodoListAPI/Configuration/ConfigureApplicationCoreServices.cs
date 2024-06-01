using Microsoft.Extensions.DependencyInjection;
using TodoListAPI.Repositories;

namespace TodoListAPI.Configuration
{
    public static class ConfigureApplicationCoreServices
    {
        public static IServiceCollection AddApplicationCoreService(this IServiceCollection services)
        {
            services.AddScoped(typeof(DapperRepositories));
            services.AddScoped(typeof(TodoListService));
            return services;
        }
    }
}
