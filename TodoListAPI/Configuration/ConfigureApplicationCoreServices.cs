using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.Extensions.DependencyInjection;
using TodoListAPI.Repositories;
using TodoListAPI.Repositories.Interface;
using TodoListAPI.Services;

namespace TodoListAPI.Configuration
{
    public static class ConfigureApplicationCoreServices
    {
        public static IServiceCollection AddApplicationCoreService(this IServiceCollection services)
        {
            services.AddScoped<IRepositories, DapperRepositories>();
            services.AddScoped<ITodoListService, TodoListService>();
            services.AddScoped(typeof(LoginService));
            services.AddScoped(typeof(AuthenticationService));
            return services;
        }
    }
}
