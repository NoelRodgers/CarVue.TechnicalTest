using System.Web.Mvc;
using CarVue.TechnicalTest.Web.ViewModelBuilders;

namespace CarVue.TechnicalTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompanyListViewModelBuilder _viewModelBuilder;

        public HomeController(ICompanyListViewModelBuilder viewModelBuilder)
        {
            _viewModelBuilder = viewModelBuilder;
        }

        public ActionResult Index()
        {
            var model = _viewModelBuilder.Build();
            return View(model);
        }
    }
}