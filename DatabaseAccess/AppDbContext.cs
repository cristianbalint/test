

using Entities;
using System.Data.Entity;

namespace DatabaseAccess
{
    public class AppDbContext : DbContext
    {
        private string _connectionString;

        public AppDbContext() : base("name=DbConnection")
        {
        }
        //public AppDbContext(string connString) : base(connString)
        //{
        //    _connectionString = connString;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //}


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetVersion> AssetVersions { get; set; }

        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
        }
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

