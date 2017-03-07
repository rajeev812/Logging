using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoggingEntityFramework.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("ProductConnString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProductContext>());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ExceptionLogger> ExceptionLoggers { get; set; }
    }
}