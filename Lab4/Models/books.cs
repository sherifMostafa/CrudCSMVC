using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lab4.Models
{
    public class books
    {
        public int id { get; set; }
        public string name { get; set; }
        public string brief { get; set; }
        public string Desc { get; set; }
        public string Pdf { get; set; }


        [ForeignKey("author")]
        public int? author_id { get; set; }
        [ForeignKey("catalog")]
        public int? catalog_id { get; set; }
        [ForeignKey("user")]
        public int? user_id { get; set; }

        public virtual catalog catalog { get; set; }
        public virtual Author author { get; set; }

        public virtual users user { get; set; }

    }
}