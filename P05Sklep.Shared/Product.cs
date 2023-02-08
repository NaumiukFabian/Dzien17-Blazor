using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05Sklep.Shared
{
    public class Product
    {
        public int Id { get; set; }
        //[Key]
        //public int MyValue;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? Color { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = String.Empty;
        public bool Premium { get; set; }
        public MaterialCategory MaterialCategory { get; set; }
        public int MaterialCategoryId { get; set; }
        public IEnumerable<Product_ProductAdjective> product_ProductAdjectives { get; set; }
    }
}
