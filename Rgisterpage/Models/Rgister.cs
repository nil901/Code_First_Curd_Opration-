using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rgisterpage.Models
{
    public class Rgister
    {
        [Key]
        public int UserId { get; set; }  

        public string UserName { get; set; } 

        public string Email { get; set; }    

        public int  Password { get; set; } 
         
        public string Gender { get; set; }  

    }
}