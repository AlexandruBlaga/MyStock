using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyStock.ViewModels
{
    public class InvoiceVM
    {
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Number { get; set; }

        public int PartnerId { get; set; }
        public int ProductId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The quantity can not be less than 1")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Range(0.01, 2000000000.00, ErrorMessage = "The price can not be a negative number.")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Date { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public bool Payment { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public bool Transaction { get; set; }
    }
}