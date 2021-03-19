using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lab4.Models
{
    public class catalog
    {
        [Display(Name = "Cataloge Id")]
        public int id { get; set; }

        [Display(Name ="Catalog Name")]
        public string name { get; set; }

        public virtual List<books> Books { get; set; }
    }
}