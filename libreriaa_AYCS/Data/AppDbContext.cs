using libreriaa_AYCS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace libreriaa_AYCS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {



        }


        public DbSet<Book> Books { get; set; }


    }
}
