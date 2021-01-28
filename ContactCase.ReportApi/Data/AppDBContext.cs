using ContactCase.ReportApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace ContactCase.ReportApi.Data
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReportConf());
        }

        public DbSet<Report> Report { get; set; }
    }
}
