using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4.Models
{
    public class users
    {

        [Display(Name = "User Id")]
        public int id { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string name { get; set; }

        [Required(ErrorMessage ="*")]
        [Range(20,60,ErrorMessage = "Age must 20 : 60 ")]
        public int? age { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        [NotMapped]
        [Compare("password",ErrorMessage ="Password Not matched")]
        public string confirm_password { get; set; }

        public string photo { get; set; }
        public virtual List<books> Books { get; set; }
       
    }
}