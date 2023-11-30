using CaTestJz.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CaTestJz.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // https://www.c-sharpcorner.com/article/understanding-addtransient-vs-addscoped-vs-addsingleton-in-asp-net-core/

            // With a transient service, a new instance is provided every time
            // an instance is requested whether it is in the scope of same http request
            // or across different http requests.

            // With a scoped service we get the same instance within the scope
            // of a given http request but a new instance across different http requests.

            // With Singleton service, there is only a single instance.
            // An instance is created, when service is first requested and
            // that single instance single instance will be used by all subsequent
            // http request throughout the application.

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }

    }
}
