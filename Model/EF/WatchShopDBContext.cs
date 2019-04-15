namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WatchShopDBContext : DbContext
    {
        public WatchShopDBContext()
            : base("name=WatchShopDBContext")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Trademark> Trademarks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Metatitle)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Trademarks)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Login)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Discount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Metatitle)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Logins)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trademark>()
                .Property(e => e.Metatitle)
                .IsUnicode(false);

            modelBuilder.Entity<Trademark>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Trademark)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Sex)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);
        }
    }
}
