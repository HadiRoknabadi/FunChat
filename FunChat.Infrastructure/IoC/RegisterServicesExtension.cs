using Microsoft.Extensions.DependencyInjection;

namespace FunChat.Infrastructure.IoC
{
    public static class RegisterServicesExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
