using Microsoft.EntityFrameworkCore;
using RESTfulApi.Models;

namespace RESTfulApi.Data
{
    public class HerosDbContext : DbContext
    {
        public HerosDbContext(DbContextOptions<HerosDbContext> opts):base(opts)
        {

        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
