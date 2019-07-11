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
        public static T Resolve<T>(this IServiceProvider provider)
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            foreach(var type in assembly.DefinedTypes)
            {
                if (type.ImplementedInterfaces.Contains(typeof(T)))
                    return (T)ActivatorUtilities.CreateInstance(provider, type.AsType());
            }

            return default(T);
        }

        public static IServiceCollection RegisterAllServices(this IServiceCollection services)
        {
            services.AddScoped<IDispatcher, Dispatcher>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
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