using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{

    public class OfertasModels
    {

        //[Required]
        //[Display(Name = "id")]
        public string id { get; set;}
        public string nombreoferta { get; set; }
        public string fechai { get; set; }
        public string fechaf { get; set; }
        public string precio { get; set; }
        public string descrip { get; set; }

    }
}