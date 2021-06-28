using E.Core.ArticleModule.IRepository;
using E.Core.ArticleModule.Services;
using E.Core.ExamFormModule.IRepository;
using E.Core.ExamFormModule.Services;
using E.Core.IdentityModule.Services;
using E.Core.IRepositories;
using E.Infrast.ArticleModule;
using E.Infrast.ExamFormModule;
using E.Infrast.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ExamCreator.Configuration
{
    public static class DIConfig
    {
        public static IServiceCollection DIConfigure(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWorks, UnitOfWorks>();

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IExamFormService, ExamFormService>();


            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IExamFormRepository, ExamFormRepository>();
            return services;
        }
    }
}
