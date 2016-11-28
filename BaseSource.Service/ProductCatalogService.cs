using BaseSource.Core;
using BaseSource.Core.UnitOfWorks;
using BaseSource.Model.Models;
using System;
using System.Collections.Generic;

namespace BaseSource.Service
{
    public class ProductCatalogService : IProductCatalogService
    {
        private IUnitOfWork _unitOfWork;

        public ProductCatalogService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        //==================================================================================

        public ProductCatalog Add(ProductCatalog productCatalog)
        {
            var dto = _unitOfWork.ProductCatalogRepository.Add(productCatalog);
            _unitOfWork.Save();
            return dto;
        }

        public void Edit(ProductCatalog productCatalog)
        {
            _unitOfWork.ProductCatalogRepository.Update(productCatalog);
            _unitOfWork.Save();
        }

        public ProductCatalog Delete(Guid id)
        {
            var dto = _unitOfWork.ProductCatalogRepository.Delete(id);
            _unitOfWork.Save();
            return dto;
        }

        public IEnumerable<ProductCatalog> GetAll()
        {
            return _unitOfWork.ProductCatalogRepository.GetAll();
        }

        public ProductCatalog GetById(Guid id)
        {
            return _unitOfWork.ProductCatalogRepository.GetSingleById(id);
        }
    }
}