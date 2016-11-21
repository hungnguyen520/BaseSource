using System.Web.Mvc;
using BaseSource.Service;
using BaseSource.Model.Models;
using System.Collections;
using System.Collections.Generic;

namespace BaseSource.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductCatalogService productCatalogService;
        public HomeController(IProductCatalogService productCatalogService)
        {
            this.productCatalogService = productCatalogService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {

            return View(productCatalogService.GetAll());
        }
    }
}