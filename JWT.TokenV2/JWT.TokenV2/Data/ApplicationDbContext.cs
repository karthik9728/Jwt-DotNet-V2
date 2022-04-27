using JWT.TokenV2.Model;
using Microsoft.EntityFrameworkCore;

namespace JWT.TokenV2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
