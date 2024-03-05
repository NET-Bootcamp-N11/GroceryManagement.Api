using GroceryManagement.Application.IServices;
using GroceryManagement.Application.Services;
using GroceryManagement.Application.Services.AuthServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Application
{
    public static class AppDepedencyInjection
    {
        public static IServiceCollection AddAPPlication(this IServiceCollection service)
        {
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IAuthService, AuthService>();

            return service;
        }
    }
}
