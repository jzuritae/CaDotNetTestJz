using CaTestJz.Application.Common.Interfaces.Authentication;
using CaTestJz.Application.Common.Interfaces.Persistence;
using CaTestJz.Infrastructure.Authentication;
using CaTestJz.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CaTestJz.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            // https://www.c-sharpcorner.com/article/understanding-addtransient-vs-addscoped-vs-addsingleton-in-asp-net-core/

            // With a transient service,
            // a new instance is provided every time an instance is requested
            // whether it is in the scope of same http request
            // or across different http requests.

            // With a scoped service
            // we get the same instance within the scope
            // of a given http request but a new instance across different http requests.

            // With Singleton service,
            // there is only a single instance.
            // An instance is created, when service is first requested and
            // that single instance single instance will be used by all subsequent
            // http request throughout the application.


            // Adds the IOptions interface where we can require the jwtsettings:
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
