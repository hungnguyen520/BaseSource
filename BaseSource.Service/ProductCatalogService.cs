using BaseSource.Core;
using BaseSource.Core.UnitOfWorks;
using BaseSource.Model.Dtos;
using BaseSource.Model.Models;
using log4net;
using System;
using System.Collections.Generic;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4Net.config", Watch = true)]

namespace BaseSource.Service
{
    public class ProductCatalogService : IProductCatalogService
    {
        private ILog _logger;

        private IUnitOfWork _unitOfWork;

        public ProductCatalogService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        //==================================================================================

        public void Add(ProductCatalogDto dto)
        {
            _logger.Info($"Enter Add ProductCatalog, dto = {dto}");

            if (dto == null)
            {
                _logger.Error($"ProductCatalog is null");
                throw new ArgumentNullException("ProductCatalog is null");
            }
            else
            {
                try
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
                catch (ApplicationException ex)
                {
                    _logger.Error(ex.ToString());
                    throw new ApplicationException(ex.ToString());
                }
            }
        }

        public void Edit(ProductCatalogDto dto)
        {
            _logger.Info($"Edit ProductCatalog, {dto}");

            if (dto == null)
            {
                _logger.Error($"ProductCatalog is null");
                throw new ArgumentNullException("ProductCatalog is null");
            }
            else
            {
                try
                {
                    var model = _unitOfWork.ProductCatalogRepository.GetSingleById(dto.Id);
                    model.UpdateDate = DateTime.Now;
                    model.Name = dto.Name;
                    _unitOfWork.ProductCatalogRepository.Update(model);
                    _unitOfWork.Save();
                }
                catch (ApplicationException ex)
                {
                    _logger.Error(ex.ToString());
                    throw new ApplicationException(ex.ToString());
                }
            }

        }

        public void Delete(Guid id)
        {
            _logger.Info($"Delete ProductCatalog, {id}");

            if (string.IsNullOrEmpty(id.ToString()))
            {
                _logger.Error($"ProductCatalog id not exist");
                throw new ArgumentNullException("ProductCatalog id not exist");
            }
            else
            {
                try
                {
                    _unitOfWork.ProductCatalogRepository.Delete(id);
                    _unitOfWork.Save();
                }
                catch (ApplicationException ex)
                {
                    _logger.Error(ex.ToString());
                    throw new ApplicationException(ex.ToString());
                }
            }

        }

        public IEnumerable<ProductCatalog> GetAll()
        {
            _logger.Info("Get all ProductCatalog");

            try
            {
                return _unitOfWork.ProductCatalogRepository.GetAll();
            }
            catch (ApplicationException ex)
            {
                _logger.Error(ex.ToString());
                throw new ApplicationException(ex.ToString());
            }
        }

        public ProductCatalogDto GetById(Guid id)
        {
            _logger.Info($"Get ProductCatalog by Id, {id}");

            if (string.IsNullOrEmpty(id.ToString()))
            {
                _logger.Error($"ProductCatalog id not exist");
                throw new ArgumentNullException("ProductCatalog id not exist");
            }
            else
            {
                try
                {
                    var model = _unitOfWork.ProductCatalogRepository.GetSingleById(id);
                    ProductCatalogDto dto = new ProductCatalogDto
                    {
                        Name = model.Name
                    };
                    return dto;
                }
                catch (ApplicationException ex)
                {
                    _logger.Error(ex.ToString());
                    throw new ApplicationException(ex.ToString());
                }
            }
        }
    }
}