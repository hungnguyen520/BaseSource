using BaseSource.Data.Infrastructure;
using BaseSource.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseSource.Service
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        //====================================================================================

        public Product Add(Product product)
        {
            return _unitOfWork.productRepository.Add(product);
        }

        public void Update(Product product)
        {
            _unitOfWork.productRepository.Update(product);
        }

        public Product Delete(Guid id)
        {
            return _unitOfWork.productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _unitOfWork.productRepository.GetAll();
        }

        public Product GetById(Guid id)
        {
            return _unitOfWork.productRepository.GetSingleById(id);
        }

        public IEnumerable<Product> GetHotProduct(int top)
        {
            return _unitOfWork.productRepository.GetMulti(x => x.IsDeleted == false && x.HotFlag == true).OrderByDescending(x => x.CreateDate).Take(top);
        }

        public IEnumerable<Product> GetLastest(int top)
        {
            return _unitOfWork.productRepository.GetMulti(x => x.IsDeleted == false).OrderByDescending(x => x.CreateDate).Take(top);
        }

        public IEnumerable<Product> GetListProductByCategoryIdPaging(Guid categoryId, int page, int pageSize, string sort, int totalRow)
        {
            return _unitOfWork.productRepository.GetListProductByCategoryIdPaging(categoryId, page, pageSize, sort, totalRow);
        }

        public IEnumerable<string> GetListProductByName(string name)
        {
            return _unitOfWork.productRepository.GetMulti(x => x.IsDeleted == false && x.Name.Contains(name)).Select(y => y.Name);
        }

        public IEnumerable<Product> Search(string keyword, int page, int pageSize, string sort, int totalRow)
        {
            return _unitOfWork.productRepository.Search(keyword, page, pageSize, sort, totalRow);
        }

        public IEnumerable<Product> GetRelativeProducts(Guid productId, int top)
        {
            return _unitOfWork.productRepository.GetRelativeProducts(productId, top);
        }

        public bool SellProduct(Guid productId, int quantity)
        {
            return _unitOfWork.productRepository.SellProduct(productId, quantity);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}