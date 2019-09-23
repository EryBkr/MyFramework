using MyFramework.Core.Aspects.PostSharp;
using MyFramework.Core.CrossCuttingConcerns.Caching.MicrosoftCache;
using MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using MyFramework.Project.Business.Abstract;
using MyFramework.Project.Business.ValidationsRules.FluentValidations;
using MyFramework.Project.DataAccess.Abstract;
using MyFramework.Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace MyFramework.Project.Business.Concrete.Managers
{
    public class ProductManager : IProductManager
    {
        private IProductDal _productDal;
        
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidateAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [LogAspect(typeof(DatabaseLogger))]
        [LogExceptionAspect(typeof(DatabaseLogger))]
        [SecuredOperations(Roles = "Admin")]
        public Product Add(Product entity)
        {
            
            _productDal.Add(entity);
            return entity;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product Get(int id)
        {
            return _productDal.Get(id);
        }

        [CacheAspect(typeof(MemoryCacheManager), 60)]
        [LogAspect(typeof(DatabaseLogger))]
        [PerformanceCounterAspect]
        [SecuredOperations(Roles = "Admin")]
        public IQueryable<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        [TransactionalOperationAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            _productDal.Add(product2);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Update(Product entity)
        {
            _productDal.Update(entity);
            return entity;
        }
    }
}
