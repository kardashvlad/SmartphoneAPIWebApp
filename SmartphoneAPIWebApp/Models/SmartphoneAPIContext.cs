using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace SmartphoneAPIWebApp.Models
{
    public class SmartPhoneAPIContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Smartphone> Smartphones { get; set; }
        public virtual DbSet<Favorite> Favorite { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientCascade;
            }
        }

        public SmartPhoneAPIContext(DbContextOptions<SmartPhoneAPIContext> options)
        : base(options)
        {

        }
    }
}
