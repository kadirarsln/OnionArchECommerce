﻿using ECommerce.Application.Features.Categories.Rules;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Login;
using Core.Application.Pipelines.Performance;
using Core.Application.Pipelines.Validation;
using FluentValidation;

namespace ECommerce.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServicesDependencies(this IServiceCollection services)
    {

        services.AddScoped<CategoryBusinessRules>();
        services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
        //services.AddScoped<LoggerServiceBase, FileLogger>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(con =>
        {
            con.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            con.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            con.AddOpenBehavior(typeof(PerformanceBehavior<,>));
            con.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            con.AddOpenBehavior(typeof(LoginBehavior<,>));
        });

        return services;
    }
}
