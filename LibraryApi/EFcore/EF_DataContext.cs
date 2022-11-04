using Microsoft.EntityFrameworkCore;

namespace LibraryApi.EFcore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.UseSerialColumns();
        //}

        public DbSet<books> books { get; set; }
        public DbSet<authors> authors { get; set; }
        public DbSet<relation> relation { get; set; }


    }
}
