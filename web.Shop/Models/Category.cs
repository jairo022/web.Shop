using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Shop.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }

    }
}
