using System.Data.Entity;
using CarVue.TechnicalTest.Core.Domain.Items;

namespace CarVue.TechnicalTest.Core.Domain.Repositories
{
    public class CompaniesRepository : Repository<Company>, ICompaniesRepository
    {
        public CompaniesRepository(TechnicalTestDbContext context) : base(context)
        {
        }
    }
}