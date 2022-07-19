using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rgisterpage.Models
{
    public class Login
    {  
        [Key] 
        public int Id { get; set; }
       
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "This field is required")] 
        public string UserName { get; set; } 
        
        [Display(Name ="Passworld")] 
        [Required(ErrorMessage = "This field is required")] 
        [DataType(DataType.Password)]
        public string Passworld { get; set; }
         
        [Required(ErrorMessage  ="This field is required")] 
        [Compare("Passworld",ErrorMessage ="Confirm dosen't match type again")] 
        [NotMapped] 
        public string RePassworld {get; set;}  

















    }
}