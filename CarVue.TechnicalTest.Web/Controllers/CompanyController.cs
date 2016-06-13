using System;
using System.Web.Mvc;
using CarVue.TechnicalTest.Web.Models;
using CarVue.TechnicalTest.Web.ViewModelBuilders;

namespace CarVue.TechnicalTest.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyViewModelBuilder _companyViewModelBuilder;

        public CompanyController(ICompanyViewModelBuilder companyViewModelBuilder)
        {
            _companyViewModelBuilder = companyViewModelBuilder;
        }

        public ActionResult Index(int? id = null)
        {
            var model = _companyViewModelBuilder.Build(id);
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(CompanySaveModel model)
        {
            if (ModelState.IsValid)
            {
                
            }
            throw new NotImplementedException();
        }
    }
}