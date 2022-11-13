using Microsoft.EntityFrameworkCore;
using PizzeriaShared.Models;

namespace Pizzeria.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Ingredient>? Ingredients { get; set; }
    }
}
