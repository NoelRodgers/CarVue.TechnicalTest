using System.Collections.Generic;
using System.Linq;
using CarVue.TechnicalTest.Common.UnitOfWorkPattern;
using CarVue.TechnicalTest.Core.Domain.Items;
using CarVue.TechnicalTest.Core.Domain.Repositories;

namespace CarVue.TechnicalTest.Core.Domain.Service
{
    public class CompaniesService : ICompaniesService
    {
        private readonly ICompaniesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CompaniesService(ICompaniesRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public List<Company> GetAllCompanies()
        {
            return _repository.Get().ToList();
        }

        public Company GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(Company company)
        {
            _repository.Insert(company);
            _unitOfWork.Commit();
        }

        public void Update(Company company)
        {
            _repository.Update(company);
            _unitOfWork.Commit();
        }
    }
}