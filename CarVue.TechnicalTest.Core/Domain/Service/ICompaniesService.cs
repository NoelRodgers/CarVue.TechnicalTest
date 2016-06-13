using System.Collections.Generic;
using CarVue.TechnicalTest.Core.Domain.Items;

namespace CarVue.TechnicalTest.Core.Domain.Service
{
    public interface ICompaniesService
    {
        List<Company> GetAllCompanies();
        Company GetById(int id);
    }
}