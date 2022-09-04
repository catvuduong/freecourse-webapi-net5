using Microsoft.EntityFrameworkCore;

namespace my_web_api_app.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        { }
        #region DbSet
        public DbSet<Good> Goods { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        #endregion 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(order => order.OrderCode);
                e.Property(order => order.DateTime).HasDefaultValueSql("getutcdate()");
                e.Property(order => order.Receiver).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");
                entity.HasKey(e => new
                {
                    e.OrderCode,
                    e.GoodCode
                });

                entity.HasOne(e => e.Order)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.OrderCode)
                .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(e => e.Good)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.GoodCode)
                .HasConstraintName("FK_OrderDetail_Good");
            });
        }
    }
}
