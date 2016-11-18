using BaseSource.Data.Infrastructure;
using BaseSource.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _unitOfWork.productCatalogRepository.Add(productCatalog);
        }

        public ProductCatalog Delete(Guid id)
        {
            return _unitOfWork.productCatalogRepository.Delete(id);
        }

        public IEnumerable<ProductCatalog> GetAll()
        {
            return _unitOfWork.productCatalogRepository.GetAll();
        }

        public ProductCatalog GetById(Guid id)
        {
            return _unitOfWork.productCatalogRepository.GetSingleById(id);
        }

        public void Update(ProductCatalog productCatalog)
        {
            _unitOfWork.productCatalogRepository.Update(productCatalog);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
