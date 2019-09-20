using MyFramework.Core.DataAccess.EntityFramework;
using MyFramework.Project.DataAccess.Abstract;
using MyFramework.Project.Entities.ComplexType;
using MyFramework.Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Project.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, DatabaseContext>, IProductDal
    {
        public List<ProductCategory> GetProductCategory()
        {
            List<ProductCategory> result;
            using (DatabaseContext _dB=new DatabaseContext())
            {
                result = _dB.Product.Select(i => new ProductCategory { id = i.Id, CategoryName = i.Category.Name, Name = i.Name }).ToList();
            }
            return result;
        }
    }
}
