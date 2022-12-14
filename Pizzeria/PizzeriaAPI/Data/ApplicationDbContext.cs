using Microsoft.EntityFrameworkCore;
using PizzeriaShared.Models;
using System.Collections.Generic;

namespace PizzeriaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ingredient>? Ingredients { get; set; }
        public DbSet<Pizza>? Pizzas { get; set; }
        public DbSet<Order>? Orders { get; set; }
    }
}
