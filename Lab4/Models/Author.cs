using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lab4.Models
{
    public class Author
    {
        public int id { get; set; }
        [Display(Name = "Author Name")]
        public string name { get; set; }
        public virtual List<books> Books { get; set; }
    }
}