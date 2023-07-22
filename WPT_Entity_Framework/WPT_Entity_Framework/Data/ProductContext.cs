using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPT_Entity_Framework.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set;}
        public DbSet<Category> Categories { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = products.db");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
