using GroceryManagement.Application.Abstractions.IRepositories;
using GroceryManagement.Application.IServices;
using GroceryManagement.Application.Services;
using GroceryManagement.Infrastructure.Persistance;
using GroceryManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GroceryManagement.Infrastructure
{
    public static class DependensyInjectio
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection service, IConfiguration con)
        {
            service.AddDbContext<GroceryManagementDbContext>(oops =>
            {
                oops.UseNpgsql(con.GetConnectionString("Postgress"));
            });

            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IOrderRepository,OrderRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            return service;
        }

    }
}
