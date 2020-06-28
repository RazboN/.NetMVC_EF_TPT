using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetMVC_EF_TPT.Models;

namespace NetMVC_EF_TPT.DB
{
    public class OrderContext : DbContext
    {
        IConfiguration _iconfiguration;
        private const string connectionString = "Server=DESKTOP-6PBOME5;Database=MVC_EF;" +
            "Trusted_Connection=True;";
        public OrderContext()
        {
        }

        public OrderContext(IConfiguration iconfiguration) : base()
        {
            _iconfiguration = iconfiguration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_iconfiguration.GetSection("Data")
                .GetSection("ConnectionString").Value);
            //optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Kargo>().ToTable("Kargo");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");
        }

        public DbSet<OrderDetail> siparisler { get; set; }
    }
}
