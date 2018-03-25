using MyStock.Data;
using MyStock.Enum;
using MyStock.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyStock.Mappings
{
    public class InvoiceMap
    {
        public static InvoiceVM InvoiceToInvoiceVM(Invoice invoice)
        {
            var invoiceVM = new InvoiceVM
            {
                InvoiceId = invoice.InvoiceId,
                Number = invoice.Number,
                PartnerId = invoice.PartnerId,
                ProductId = invoice.ProductId,
                Quantity = invoice.Quantity,
                Price = invoice.Price,
                Date = invoice.Date,
                Payment = (PaymentEnum)invoice.Payment,
                Transaction = (TransactionEnum)invoice.Transaction,
                Partner = invoice.Partner,
                Product = invoice.Product
            };

            return invoiceVM;
        }

        public static Invoice InvoiceVMToInvoice(InvoiceVM invoiceVM)
        {
            var invoice = new Invoice
            {
                InvoiceId = invoiceVM.InvoiceId,
                Number = invoiceVM.Number,
                PartnerId = invoiceVM.PartnerId,
                ProductId = invoiceVM.ProductId,
                Quantity = invoiceVM.Quantity,
                Price = invoiceVM.Price,
                Date = invoiceVM.Date,
                Payment = (int)invoiceVM.Payment,
                Transaction = (int)invoiceVM.Transaction,
                Partner = invoiceVM.Partner,
                Product = invoiceVM.Product
            };

            return invoice;
        }

    }
}