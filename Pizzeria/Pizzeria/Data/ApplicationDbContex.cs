using Microsoft.EntityFrameworkCore;

namespace Pizzeria.Data
{
    public class ApplicationDbContex : DbContext
    {
        public ApplicationDbContex(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Ingredient>? Ingredients { get; set; }
    }
}
