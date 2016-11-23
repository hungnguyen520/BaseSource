using BaseSource.Service;
using System.Web.Mvc;

namespace BaseSource.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductManagementService _productManagementService;

        public HomeController(IProductManagementService productManagementService)
        {
            this._productManagementService = productManagementService;
        }

        //========================================================================================

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductCatalogList()
        {
            return View(_productManagementService.GetAllProductCatalog());
        }
    }
}