using Microsoft.EntityFrameworkCore;
using MobileStore.DataModels;

namespace MobileStore.Data
{
    public class AppDbContent : DbContext
    {
        public DbSet<Product> MobileProduct { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<ProductImage> Image { get; set; }
        public AppDbContent(DbContextOptions<AppDbContent> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Manufacture Model Building
            modelBuilder.Entity<Manufacturer>()
                .HasKey(man => man.ManufaturerID);

            modelBuilder.Entity<Manufacturer>()
                .Property(t => t.ManufaturerID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Manufacturer>()
                .HasMany<Product>(man => man.Products)
                .WithOne(mob => mob.Manufacturer);

            // MobileProduct Model Building
            modelBuilder.Entity<Product>()
                .HasKey(mob => mob.MobileProductID);

            modelBuilder.Entity<Product>()
                .Property(mob => mob.MobileProductID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>()
                .HasMany<ProductImage>(mob => mob.Images)
                .WithOne(img => img.Product);

            modelBuilder.Entity<Product>()
                .HasOne<Manufacturer>(mob => mob.Manufacturer);
            modelBuilder.Entity<Product>()
                .Property(mob => mob.VideoUrl)
                .HasDefaultValue("");

            //Content Model Building
            modelBuilder.Entity<ProductImage>().HasKey(im => im.ImageID);
            modelBuilder.Entity<ProductImage>()
                .HasOne<Product>(im => im.Product)
                .WithMany(mob => mob.Images);
        }


    }
}
