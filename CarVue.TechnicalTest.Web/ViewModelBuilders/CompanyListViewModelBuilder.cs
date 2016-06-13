using CarVue.TechnicalTest.Common.Extensions;
using CarVue.TechnicalTest.Core.Domain.Items;
using CarVue.TechnicalTest.Core.Domain.Service;
using CarVue.TechnicalTest.Web.Models;

namespace CarVue.TechnicalTest.Web.ViewModelBuilders
{
    public class CompanyListViewModelBuilder : ICompanyListViewModelBuilder
    {
        private readonly ICompaniesService _service;

        public CompanyListViewModelBuilder(ICompaniesService service)
        {
            _service = service;
        }

        public CompanyListViewModel Build()
        {
            var companies = _service.GetAllCompanies();

            var model = new CompanyListViewModel
            {
                Companies = companies.SelectToList(BuildCompanyModel)
            };
            return model;
        }

        //TODO - Use Automapper to do this instead
        private CompanyViewModel BuildCompanyModel(Company company)
        {
            return new CompanyViewModel
            {
                CompanyName = company.Name,
                Id = company.Id
            };
        }
    }
}