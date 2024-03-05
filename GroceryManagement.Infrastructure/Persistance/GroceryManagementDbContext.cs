using GroceryManagement.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Infrastructure.Persistance
{
    public class GroceryManagementDbContext : DbContext
    {
        public GroceryManagementDbContext(DbContextOptions<GroceryManagementDbContext> options) : base(options)

        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
