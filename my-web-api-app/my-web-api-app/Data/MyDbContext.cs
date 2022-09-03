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
        #endregion 
    }
}
