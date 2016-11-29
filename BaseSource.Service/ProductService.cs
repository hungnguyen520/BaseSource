using BaseSource.Core;
using BaseSource.Core.UnitOfWorks;
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

        //==================================================================================

        public void Add(Product product)
        {
            _unitOfWork.ProductRepository.Add(product);
            _unitOfWork.Save();
        }

        public void Edit(Product product)
        {
            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.Save();
        }

        public void Delete(Guid id)
        {
            _unitOfWork.ProductRepository.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<Product> GetAll()
        {
            return _unitOfWork.ProductRepository.GetAll();
        }

        public Product GetById(Guid id)
        {
            return _unitOfWork.ProductRepository.GetSingleById(id);
        }

        public IEnumerable<Product> GetHot(int top)
        {
            return _unitOfWork.ProductRepository.GetMulti(x => x.IsDeleted == false && x.HotFlag == true).OrderByDescending(x => x.CreateDate).Take(top);
        }

        public IEnumerable<Product> GetLastest(int top)
        {
            return _unitOfWork.ProductRepository.GetMulti(x => x.IsDeleted == false).OrderByDescending(x => x.CreateDate).Take(top);
        }

        public IEnumerable<Product> GetListByCategoryIdPaging(Guid categoryId, int page, int pageSize, string sort, int totalRow)
        {
            return _unitOfWork.ProductRepository.GetListProductByCategoryIdPaging(categoryId, page, pageSize, sort, totalRow);
        }

        public IEnumerable<string> GetListByName(string name)
        {
            return _unitOfWork.ProductRepository.GetMulti(x => x.IsDeleted == false && x.Name.Contains(name)).Select(y => y.Name);
        }

        public IEnumerable<Product> Search(string keyword, int page, int pageSize, string sort, int totalRow)
        {
            return _unitOfWork.ProductRepository.Search(keyword, page, pageSize, sort, totalRow);
        }

        public IEnumerable<Product> GetRelative(Guid productId, int top)
        {
            return _unitOfWork.ProductRepository.GetRelativeProducts(productId, top);
        }
    }
}