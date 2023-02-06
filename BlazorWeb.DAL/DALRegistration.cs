using System;
using BlazorWeb.DAL.Persistence;
using BlazorWeb.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWeb.DAL
{
	public static class DALRegistration
	{
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("OrderingConnectionString"));
            });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IWindowRepository, WindowRepository>();
            services.AddScoped<IElementRepository, ElementRepository>();

            return services;
        }
    }
}

