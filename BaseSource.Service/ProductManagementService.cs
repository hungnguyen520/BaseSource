using BaseSource.Model.Models;
using BaseSource.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseSource.Service
{
    public class ProductManagementService : IProductManagementService
    {
        private IUnitOfWork _unitOfWork;

        public ProductManagementService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        //==================================================================================

        public ProductCatalog AddProductCatalog(ProductCatalog productCatalog)
        {
            return _unitOfWork.ProductCatalogRepository.Add(productCatalog);
        }

        public ProductCatalog DeleteProductCatalog(Guid id)
        {
            return _unitOfWork.ProductCatalogRepository.Delete(id);
        }

        public IEnumerable<ProductCatalog> GetAllProductCatalog()
        {
            return _unitOfWork.ProductCatalogRepository.GetAll();
        }

        public ProductCatalog GetByIdProductCatalog(Guid id)
        {
            return _unitOfWork.ProductCatalogRepository.GetSingleById(id);
        }

        public void UpdateProductCatalog(ProductCatalog productCatalog)
        {
            _unitOfWork.ProductCatalogRepository.Update(productCatalog);
        }

        //====================================================================================

        public Product AddProduct(Product product)
        {
            return _unitOfWork.ProductRepository.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _unitOfWork.ProductRepository.Update(product);
        }

        public Product DeleteProduct(Guid id)
        {
            return _unitOfWork.ProductRepository.Delete(id);
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _unitOfWork.ProductRepository.GetAll();
        }

        public Product GetByIdProduct(Guid id)
        {
            return _unitOfWork.ProductRepository.GetSingleById(id);
        }

        public IEnumerable<Product> GetHotProduct(int top)
        {
            return _unitOfWork.ProductRepository.GetMulti(x => x.IsDeleted == false && x.HotFlag == true).OrderByDescending(x => x.CreateDate).Take(top);
        }

        public IEnumerable<Product> GetLastestProduct(int top)
        {
            return _unitOfWork.ProductRepository.GetMulti(x => x.IsDeleted == false).OrderByDescending(x => x.CreateDate).Take(top);
        }

        public IEnumerable<Product> GetListProductByCategoryIdPaging(Guid categoryId, int page, int pageSize, string sort, int totalRow)
        {
            return _unitOfWork.ProductRepository.GetListProductByCategoryIdPaging(categoryId, page, pageSize, sort, totalRow);
        }

        public IEnumerable<string> GetListProductByName(string name)
        {
            return _unitOfWork.ProductRepository.GetMulti(x => x.IsDeleted == false && x.Name.Contains(name)).Select(y => y.Name);
        }

        public IEnumerable<Product> SearchProduct(string keyword, int page, int pageSize, string sort, int totalRow)
        {
            return _unitOfWork.ProductRepository.Search(keyword, page, pageSize, sort, totalRow);
        }

        public IEnumerable<Product> GetRelativeProducts(Guid productId, int top)
        {
            return _unitOfWork.ProductRepository.GetRelativeProducts(productId, top);
        }

        public bool SellProduct(Guid productId, int quantity)
        {
            return _unitOfWork.ProductRepository.SellProduct(productId, quantity);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}