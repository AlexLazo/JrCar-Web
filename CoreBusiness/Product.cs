using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Precio debe de ser mayor o igual a {0}")]
        public double? Price { get; set; }

        public int Year { get; set; }

        // Propiedad de Navegación para EFCore
        public Category Category { get; set; }
    }
}
