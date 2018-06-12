using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cms_MVC.Models
{ 
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int Population { get; set; }
        public List<City> Cities { get; set; }
    }
}