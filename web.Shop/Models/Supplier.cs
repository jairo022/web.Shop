using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Shop.Models
{
    public class Supplier
    {
        public Supplier()
        {
            Products = new List<Product>();
        }  
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<Product> Products { get; set; }
    }
}
