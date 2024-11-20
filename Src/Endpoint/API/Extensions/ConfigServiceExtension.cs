using Application.RepositoryContracts;
using Application.ServicesContracts;
using EF.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Repository.Orders;
using Repository.Products;
using Services.Services;

namespace API.Extensions
{
    public static class ConfigServiceExtension
    {
        public static void AddCustomDIContainer(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, ApplicationDbContext>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IProfitService, ProfitService>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
        }

        public static void AddCustomDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(@"Server=.;Database=MyAppDb;Trusted_Connection=True;", builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            });
        }

    }
}
