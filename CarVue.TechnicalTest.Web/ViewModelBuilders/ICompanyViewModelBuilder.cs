using CarVue.TechnicalTest.Web.Models;

namespace CarVue.TechnicalTest.Web.ViewModelBuilders
{
    public interface ICompanyViewModelBuilder
    {
        CompanyViewModel Build(int? id);
    }
}