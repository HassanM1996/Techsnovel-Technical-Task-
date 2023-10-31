using Microsoft.Extensions.DependencyInjection;
using TechsnovelTechnicalTask.Application.Interfaces.FacadPatterns;
using TechsnovelTechnicalTask.Infrastructure.FacadPattern;

namespace TechsnovelTechnicalTask.Infrastructure
{
    public static class DependencyInjection

    {
        public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services)
        {
            services.AddScoped<IProductFacad, ProductFacad>();
            services.AddScoped<ICategoryFacad, CategoryFacad>();
            services.AddScoped<IAuthenticationFacad, AuthenticationFacad>();
            

            return services;
        }
    }
}
