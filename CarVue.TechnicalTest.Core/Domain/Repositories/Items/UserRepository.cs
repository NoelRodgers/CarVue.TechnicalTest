using CarVue.TechnicalTest.Core.Domain.Items;

namespace CarVue.TechnicalTest.Core.Domain.Repositories.Items
{
    public class UserRepository : Repository<User, TechnicalTestDbContext>, IUserRepository
    {
        public UserRepository(TechnicalTestDbContext context) : base(context)
        {
        }
    }
}