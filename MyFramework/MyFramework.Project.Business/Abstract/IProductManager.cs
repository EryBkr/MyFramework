﻿using MyFramework.Core.Business.Abstract;
using MyFramework.Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Project.Business.Abstract
{
    public interface IProductManager:IGenericManager<Product>
    {
        void TransactionalOperation(Product product1,Product product2);
    }
}
