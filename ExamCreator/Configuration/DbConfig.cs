using E.Entities.Entities;
using E.Infrast.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExamCreator.Configuration
{
    public static class DbConfig
    {
        public static IServiceCollection DbConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("defaultConnection"))
            );

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
            return services;
        }
    }
}
