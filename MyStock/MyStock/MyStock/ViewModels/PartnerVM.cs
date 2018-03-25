using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyStock.ViewModels
{ 
    public class PartnerVM
    {
        public int PartnerId { get; set; }

        [DisplayName("Partner Name")]
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Phone]
        public string Phone { get; set; }

        [CreditCard]
        public string Card { get; set; }
    }
}