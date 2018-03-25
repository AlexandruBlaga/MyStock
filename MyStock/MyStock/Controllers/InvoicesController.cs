using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyStock.Data;
using MyStock.Repositories;
using MyStock.Mappings;
using MyStock.ViewModels;

namespace MyStock.Controllers
{
    public class InvoicesController : Controller
    {
        private lannisterEntities db = new lannisterEntities();
        private IInvoicesRepositories invoicesRepositories = new InvoicesRepositories();

        // GET: Invoices
        public ActionResult Index()
        {
            var invoicesVM = new List<InvoiceVM>();

            foreach (var invoice in invoicesRepositories.GetAll())
            {
                var invoiceVM = InvoiceMap.InvoiceToInvoiceVM(invoice);
                invoicesVM.Add(invoiceVM);
            }

            return View(invoicesVM);
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = invoicesRepositories.GetById(id.Value);
            if (invoice == null)
            {
                return HttpNotFound();
            }

            var invoiceVM = InvoiceMap.InvoiceToInvoiceVM(invoice);

            return View(invoiceVM);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.PartnerId = new SelectList(db.Partners, "PartnerId", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceId,Number,PartnerId,ProductId,Quantity,Price,Date,Payment,Transaction")] InvoiceVM invoiceVM)
        {
            var invoice = InvoiceMap.InvoiceVMToInvoice(invoiceVM);

            if (ModelState.IsValid)
            {
                invoicesRepositories.Add(invoice);
                return RedirectToAction("Index");
            }

            ViewBag.PartnerId = new SelectList(db.Partners, "PartnerId", "Name", invoice.PartnerId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", invoice.ProductId);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = invoicesRepositories.GetById(id.Value);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartnerId = new SelectList(db.Partners, "PartnerId", "Name", invoice.PartnerId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", invoice.ProductId);

            var invoiceVM = InvoiceMap.InvoiceToInvoiceVM(invoice);

            return View(invoiceVM);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceId,Number,PartnerId,ProductId,Quantity,Price,Date,Payment,Transaction")] InvoiceVM invoiceVM)
        {
            var invoice = InvoiceMap.InvoiceVMToInvoice(invoiceVM);

            if (ModelState.IsValid)
            {
                invoicesRepositories.Edit(invoice);
                return RedirectToAction("Index");
            }
            ViewBag.PartnerId = new SelectList(db.Partners, "PartnerId", "Name", invoice.PartnerId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", invoice.ProductId);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = invoicesRepositories.GetById(id.Value);
            if (invoice == null)
            {
                return HttpNotFound();
            }

            var invoiceVM = InvoiceMap.InvoiceToInvoiceVM(invoice);

            return View(invoiceVM);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = invoicesRepositories.GetById(id);
            invoicesRepositories.Delete(invoice);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
