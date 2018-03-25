using MyStock.Data;
using MyStock.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyStock.Mappings
{
    public class PartnerMap
    {
        public static PartnerVM PartnerToPartnerVM(Partner partner)
        {
            var partnerVM = new PartnerVM
            {
                PartnerId = partner.PartnerId,
                Name = partner.Name,
                Phone = partner.Phone,
                Card = partner.Card
            };

            return partnerVM;
        }

        public static Partner PartnerVMToPartner(PartnerVM partnerVM)
        {
            var partner = new Partner
            {
                PartnerId = partnerVM.PartnerId,
                Name = partnerVM.Name,
                Phone = partnerVM.Phone,
                Card = partnerVM.Card
            };

            return partner;
        }
    }
}