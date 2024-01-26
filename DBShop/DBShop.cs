using DBShop.Models;
using Microsoft.EntityFrameworkCore;

namespace DBShop
{
    public class DBshop : DbContext
    {
        public DbSet<Users> users { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<PP> pp { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=DBShop_sh;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
