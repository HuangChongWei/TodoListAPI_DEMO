using Microsoft.Extensions.DependencyInjection;
using TodoListAPI.Repositories;
using TodoListAPI.Services;

namespace TodoListAPI.Configuration
{
    public static class ConfigureApplicationCoreServices
    {
        public static IServiceCollection AddApplicationCoreService(this IServiceCollection services)
        {
            services.AddScoped(typeof(DapperRepositories));
            services.AddScoped(typeof(TodoListService));
            services.AddScoped(typeof(LoginService));
            services.AddScoped(typeof(AuthenticationService));
            return services;
        }
    }
}
