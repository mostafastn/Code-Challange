using Application.RepositoryContracts;
using Application.ServicesContracts;
using efdb;
using Microsoft.EntityFrameworkCore;
using Repository.Document;
using Services.Services;

namespace API.Extensions
{
    public static class ConfigServiceExtension
    {
        public static void AddCustomDIContainer(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, ApplicationDbContext>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IEntityRepository, EntityRepository>();

            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IEntityService, EntityService>();
        }

        public static void AddCustomDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }

    }
}
