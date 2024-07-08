using Microsoft.EntityFrameworkCore;
using TechNationDashboard.Entities;

namespace TechNationDashboard.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<NotaFiscal> NotasFiscais { get; set; }
    }
}
