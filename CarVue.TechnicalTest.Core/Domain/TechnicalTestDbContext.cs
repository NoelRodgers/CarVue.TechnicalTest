using System.Data.Entity;
using CarVue.TechnicalTest.Core.Domain.Items;


namespace CarVue.TechnicalTest.Core.Domain
{
    public class TechnicalTestDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<PhysicalAddress> PhysicalAddresses { get; set; }

        public DbSet<VirtualAddress> VirtualAddresses { get; set; }
    }
}