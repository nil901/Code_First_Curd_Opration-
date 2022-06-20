using Rgisterpage.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rgisterpage.Models
{
    public class Contex   : DbContext
    {
        public DbSet<Rgister> Rgister { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCat> ProductCat { get; set; }
       

    }
}