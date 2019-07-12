using System;
using System.Linq;
using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Pumox.Services.Companies.Commands.CreateCompany;
using Pumox.Services.Companies.Commands.DeleteCompany;
using Pumox.Services.Companies.Commands.UpdateCompany;
using Pumox.Services.Dispatchers;

namespace Pumox.Services
{
    public static class Extensions
    {
        public static dynamic Resolve(this IServiceProvider provider, Type classType)
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            foreach(var type in assembly.DefinedTypes)
            {
                if (type.ImplementedInterfaces.Contains(classType))
                    return ActivatorUtilities.CreateInstance(provider, type.AsType());
            }

            return null;
        }

        public static IServiceCollection RegisterAllServices(this IServiceCollection services)
        {
            services.AddScoped<IDispatcher, Dispatcher>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            return services;
        }

        public static IServiceCollection RegisterAllValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateCompanyCommand>, CreateCompanyValidator>();
            services.AddTransient<IValidator<UpdateCompanyCommand>, UpdateCompanyValidator>();
            services.AddTransient<IValidator<DeleteCompanyCommand>, DeleteCompanyValidator>();
            return services;
        }
    }
}