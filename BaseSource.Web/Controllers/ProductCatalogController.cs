using BaseSource.Core;
using BaseSource.Model.Dtos;
using System;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductCatalogDto dto)
        {
            _productCatalogService.Add(dto);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            return View(_productCatalogService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(ProductCatalogDto dto)
        {
            _productCatalogService.Edit(dto);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            _productCatalogService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}