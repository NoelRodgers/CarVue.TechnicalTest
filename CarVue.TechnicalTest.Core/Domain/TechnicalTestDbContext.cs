using System.Data.Entity;
using CarVue.TechnicalTest.Core.Domain.Items;

namespace CarVue.TechnicalTest.Core.Domain
{
    public class TechnicalTestDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}