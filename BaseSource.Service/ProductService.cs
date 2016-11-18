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

        public IEnumerable<Product> GetListProductByCategoryIdPaging(Guid categoryId, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _unitOfWork.productRepository.GetMulti(x => x.IsDeleted == false && x.ProductCatalogId == categoryId);

            switch (sort)
            {
                case "hotflag":
                    query = query.OrderByDescending(x => x.HotFlag);
                    break;

                case "safeoff":
                    query = query.OrderByDescending(x => x.SafeOff.HasValue);
                    break;

                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreateDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<string> GetListProductByName(string name)
        {
            return _unitOfWork.productRepository.GetMulti(x => x.IsDeleted == false && x.Name.Contains(name)).Select(y => y.Name);
        }

        public IEnumerable<Product> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _unitOfWork.productRepository.GetMulti(x => x.IsDeleted == false && x.Name.Contains(keyword));

            switch (sort)
            {
                case "hotflag":
                    query = query.OrderByDescending(x => x.HotFlag);
                    break;

                case "safeoff":
                    query = query.OrderByDescending(x => x.SafeOff.HasValue);
                    break;

                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreateDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Product> GetRelativeProducts(Guid productId, int top)
        {
            var product = _unitOfWork.productRepository.GetSingleById(productId);
            return _unitOfWork.productRepository.GetMulti(x => x.IsDeleted == false && x.Id != productId && x.ProductCatalogId == product.ProductCatalogId).OrderByDescending(x => x.CreateDate).Take(top);
        }

        public bool SellProduct(Guid productId, int quantity)
        {
            var product = _unitOfWork.productRepository.GetSingleById(productId);
            if (product.NumberInStock < quantity)
                return false;
            product.NumberInStock -= quantity;
            return true;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}