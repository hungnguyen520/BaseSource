﻿using BaseSource.Data.Infrastructure;
using BaseSource.Model.Models;
using System;

namespace BaseSource.Data.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product, Guid>
    {
    }
}