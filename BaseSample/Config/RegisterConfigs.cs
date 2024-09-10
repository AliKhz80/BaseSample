using Application;
using Application.Config;
using Application.Features.SampleModel;
using BaseSample.Middlewares;
using Domain.Interfaces;
using Domain.Interfaces.BusinessIRepositories;
using FluentValidation;
using Infrustructure;
using Infrustructure.BusinessRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace BaseSample.Config;

public static class RegisterConfigs
{
    public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureInfrustructorLayer(configuration)
            .ConfigureApplicationLayer()
            .RegisterMiddlewares();



        return services;
    }

    private static IServiceCollection RegisterMiddlewares(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }



}
