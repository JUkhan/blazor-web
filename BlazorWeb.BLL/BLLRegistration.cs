
using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR.Extensions.FluentValidation.AspNetCore;
using MediatR;
using BlazorWeb.Shared;

namespace BlazorWeb.BLL
{
  public static class BLLRegistration
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddAutoMapper(Assembly.GetExecutingAssembly());
      services.AddFluentValidation(new[] { typeof(BLLRegistration).Assembly });
      services.AddMediatR(typeof(BLLRegistration).Assembly);
      return services;
    }

  }
}

