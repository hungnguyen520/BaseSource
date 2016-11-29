using BaseSource.Core;
using BaseSource.Core.UnitOfWorks;
using BaseSource.Model.Dtos;
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

        public void Add(ProductCatalogDto dto)
        {
            ProductCatalog model = new ProductCatalog
            {
                Id = Guid.NewGuid(),
                IsDeleted = false,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Name = dto.Name
            };
            _unitOfWork.ProductCatalogRepository.Add(model);
            _unitOfWork.Save();
        }

        public void Edit(ProductCatalogDto dto)
        {
            var model = _unitOfWork.ProductCatalogRepository.GetSingleById(dto.Id);

            model.UpdateDate = DateTime.Now;
            model.Name = dto.Name;

            _unitOfWork.ProductCatalogRepository.Update(model);
            _unitOfWork.Save();
        }

        public void Delete(Guid id)
        {
            _unitOfWork.ProductCatalogRepository.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<ProductCatalog> GetAll()
        {
            return _unitOfWork.ProductCatalogRepository.GetAll();
        }

        public ProductCatalogDto GetById(Guid id)
        {
            var model = _unitOfWork.ProductCatalogRepository.GetSingleById(id);
            ProductCatalogDto dto = new ProductCatalogDto
            {
                Name = model.Name
            };
            return dto;
        }
    }
}