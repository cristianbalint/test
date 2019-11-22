

using Entities;
using System.Data.Entity;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        private string _connectionString;

        public AppDbContext(string connString)
        {
            _connectionString = connString;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //}

        public DbSet<Folder> Folders { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetVersion> AssetVersions { get; set; }

    }

    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GiftGroupContext>
    //{
    //    public GiftGroupContext CreateDbContext(string[] args)
    //    {
    //        var builder = new DbContextOptionsBuilder<GiftGroupContext>();
    //        return new GiftGroupContext(null);
    //    }
    //}
}

