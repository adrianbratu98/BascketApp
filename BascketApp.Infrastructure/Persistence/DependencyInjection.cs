using System;
using BascketApp.Application.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BascketApp.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BascketAppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("BascketAppDB")));
            services.AddTransient<IBascketAppDbContext, BascketAppDbContext>();
            return services;
        }
    }
}

