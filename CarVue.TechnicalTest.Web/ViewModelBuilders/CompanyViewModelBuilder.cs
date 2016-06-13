using System;
using CarVue.TechnicalTest.Common.Extensions;
using CarVue.TechnicalTest.Core.Domain.Service;
using CarVue.TechnicalTest.Web.Models;

namespace CarVue.TechnicalTest.Web.ViewModelBuilders
{
    public class CompanyViewModelBuilder : ICompanyViewModelBuilder
    {
        private readonly ICompaniesService _service;

        public CompanyViewModelBuilder(ICompaniesService service)
        {
            _service = service;
        }

        public CompanyViewModel Build(int? id = null)
        {
            if (!id.HasValue) return new CompanyViewModel();

            var company = _service.GetById(id.Value);
            if (company == null) throw new InvalidOperationException("The company with id {0} was not found".FormatString(id)); //TODO - 404 error

            return new CompanyViewModel
            {
                Id = company.Id,
                CompanyName = company.Name
            };
        }
    }
}