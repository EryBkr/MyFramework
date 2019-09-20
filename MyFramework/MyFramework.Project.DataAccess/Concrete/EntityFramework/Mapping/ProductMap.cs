using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using MyFramework.Project.Entities.Concrete;

namespace MyFramework.Project.DataAccess.Concrete.EntityFramework.Mapping
{
    public class ProductMap:EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Products", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Price).HasColumnName("Price");
            
        }
    }
}
