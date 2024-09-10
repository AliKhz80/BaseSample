
using Domain.Interfaces;
using Domain.Interfaces.BusinessIRepositories;
using Infrustructure.BusinessRepositories;
using Infrustructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrustructure;
public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrustructorLayer(this IServiceCollection services , IConfiguration configuration)
    {
        services
            .RegisterDBContext(configuration)
            .RegisterRepositories();


        return services;
    }

    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseSampleUnitOfWork), typeof(BaseSampleUnitOfWork));
        services.AddScoped(typeof(ISampleModelRepository), typeof(SampleModelRepository));

        return services;
    }

    private static IServiceCollection RegisterDBContext(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<BaseProjectDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("BaseSample")));

        return services;
    }

   
}