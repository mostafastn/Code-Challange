using Application.RepositoryContracts;
using Application.ServicesContracts;
using EF.DatabaseContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Services.Services;
using System.ComponentModel.Design;
using System.Security.Claims;
using System.Security.Principal;

namespace API.Extensions
{
    public static class ConfigServiceExtension
    {
        public static void AddCustomDIContainer(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IProfitService, ProfitService>();
                        
            services.AddScoped<IOrderRepository, OrderRepository> ();
            services.AddScoped<IProductRepository, ProductRepository> ();

            services.AddScoped<IOrderService, OrderService > ();
            services.AddScoped<IProductService, ProductService> ();
        }

        public static void AddCustomDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            });
        }

    }
}
