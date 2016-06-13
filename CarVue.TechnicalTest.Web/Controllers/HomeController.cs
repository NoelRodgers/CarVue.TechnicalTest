using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarVue.TechnicalTest.Common.Interfaces;
using CarVue.TechnicalTest.Core.Domain.Repositories;

namespace CarVue.TechnicalTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var users = _unitOfWork.UserRepository.Get();
            return View();
        }
    }
}