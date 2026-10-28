using Microsoft.EntityFrameworkCore;
using PruebaAPI.Modelos;

namespace PruebaAPI.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<CatalolgoColores> CatalogoColores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=zapateria.db");
        }
    }
}
