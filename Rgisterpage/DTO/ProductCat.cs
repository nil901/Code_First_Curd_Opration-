 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Rgisterpage.Models;

namespace Rgisterpage.DTO
{
    public class ProductCat

    {
        [Key] 
        
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string categoryId { get; set; }

        public string CategoryName { get; set; }

        public string price { get; set; }

      
    }
}