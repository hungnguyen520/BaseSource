using BaseSource.Core;
using System.Web.Mvc;

namespace BaseSource.Web.Controllers
{
    public class ProductCatalogController : Controller
    {
        private IProductCatalogService _productCatalogService;

        public ProductCatalogController(IProductCatalogService productCatalogService)
        {
            this._productCatalogService = productCatalogService;
        }

        //========================================================================================

        public ActionResult Index()
        {
            return View(_productCatalogService.GetAll());
        }
    }
}