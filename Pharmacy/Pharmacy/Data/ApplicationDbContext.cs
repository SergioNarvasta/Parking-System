using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Models.Entities;

namespace Pharmacy.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HDVMSQLDES; Database=Z_Pharmacy; User=sa; Password=S0p0rt3; MultipleActiveResultSets=true;");
        }
        public DbSet<Pharmacy.Models.Entities.Cliente> Cliente { get; set; }
        public DbSet<Pharmacy.Models.Entities.Producto> Producto { get; set; }
        public DbSet<Pharmacy.Models.Entities.Venta> Venta { get; set; }
        public DbSet<Pharmacy.Models.Entities.DetalleVenta> DetalleVenta { get; set; }
    }
}