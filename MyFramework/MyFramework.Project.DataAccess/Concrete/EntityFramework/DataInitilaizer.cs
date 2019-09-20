using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyFramework.Project.Entities.Concrete;

namespace MyFramework.Project.DataAccess.Concrete.EntityFramework
{
    public class DataInitilaizer:DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category(){Name="Teknoloji"}
            };
            foreach (var item in categories)
            {
                context.Category.Add(item);
            }
            context.SaveChanges();

            List<Product> products = new List<Product>()
            {
                new Product(){Name="Bilgisayar",Price=5000,CategoryId=1}
            };
            foreach (var item in products)
            {
                context.Product.Add(item);
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
