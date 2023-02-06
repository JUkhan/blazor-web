using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWeb.Shared
{
	public static class SharedRegistration
	{
        public static IServiceCollection AddSharedModelServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(SharedRegistration).Assembly);
           
            return services;
        }
    }
}

