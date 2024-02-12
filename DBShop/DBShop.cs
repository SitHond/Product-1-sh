using DBShop.Models;
using Microsoft.EntityFrameworkCore;

namespace DBShop
{
    public class DBshop : DbContext
    {
        public DbSet<Users> users { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<PP> pp { get; set; }
        public DbSet<ItemList> itemLists { get; set; }
        public DbSet<UserToItem> userToItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=DBShop;User Id=postgres;Password=qwerty");
        }
    }
}
