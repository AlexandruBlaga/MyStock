using MyStock.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyStock.ViewModels
{
    public class ProductVM
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Product Name")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Range(0.01, 2000000000.00, ErrorMessage = "The price can not be a negative number.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, MinimumLength = 2)]
        public string Type { get; set; }

        [Required]
        public BrandEnum Brand { get; set; }
    }
}