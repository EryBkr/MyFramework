using MyFramework.Project.DataAccess.Concrete.EntityFramework.Mapping;
using MyFramework.Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Project.DataAccess.Concrete.EntityFramework
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext():base("MyFrameworkDB")
        {
            Database.SetInitializer(new DataInitilaizer());
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}
