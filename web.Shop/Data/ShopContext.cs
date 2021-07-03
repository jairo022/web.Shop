using Microsoft.EntityFrameworkCore;
using web.Shop.Models;

namespace web.Shop.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Category>(entity =>
                {
                    entity.HasKey(e => e.Id);


                    entity.Property(e => e.Id).HasColumnName("Id");

                    entity.Property(e => e.Name)
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(15);

                    entity.Property(e => e.Description)
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasMaxLength(200);
                });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);




                entity.Property(e => e.Id).HasColumnName("Id");


                entity.Property(e => e.CategoryId).HasColumnName("CategoryId");




                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(40);


                entity.Property(e => e.SupplierId).HasColumnName("SupplierId");


                entity.Property(e => e.Price)
                    .HasColumnName("Price")
                    .HasColumnType("money");


                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");


                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Suppliers");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Id);


                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("Address")
                    .HasMaxLength(60);


                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("CompanyName")
                    .HasMaxLength(40);


                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasColumnName("ContactName")
                    .HasMaxLength(30);


                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("Phone")
                    .HasMaxLength(24);



            });
        } 
    }
}
