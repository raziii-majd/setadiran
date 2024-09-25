using SetadIran.Model;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SetadIran.Context
{
    public class MainContext : DbContext
    {   
  
        public DbSet<Advertising_Public> Advertising_Public { get; set; }

        public DbSet<DebugLog> Dlogs { get; set; }

        public IConfiguration Configuration { get; }

        public MainContext(DbContextOptions<MainContext> options) : base(options) { }
        public MainContext() : base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings1.json").Build();
            options.UseSqlServer(configuration.GetConnectionString("SetadIran"));
            options.EnableSensitiveDataLogging();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Advertising_Public>().ToTable("Advertising_Public");
        }
    }
}
