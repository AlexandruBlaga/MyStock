using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyStock.Data;
using MyStock.ViewModels;
using MyStock.Repositories;
using MyStock.Mappings;

namespace MyStock.Controllers
{
    public class ProductsController : Controller
    {
        private lannisterEntities db = new lannisterEntities();
        private IProductsRepositories productsRepositories = new ProductsRepositories();

        // GET: Products
        public ActionResult Index()
        {
            var productsVM = new List<ProductVM>();

            foreach (var product in productsRepositories.GetAll())
            {
                var productVM = ProductMap.ProductToProductVM(product);

                productsVM.Add(productVM);
            }

            return View(productsVM);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productsRepositories.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }

            var productVM = ProductMap.ProductToProductVM(product);

            return View(productVM);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Name,Price,Type,Brand")] ProductVM productVM)
        {
            var product = ProductMap.ProductVMToProduct(productVM);

            if (ModelState.IsValid)
            {
                productsRepositories.Add(product);
                return RedirectToAction("Index");
            }

            return View(productVM);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productsRepositories.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }

            var productVM = ProductMap.ProductToProductVM(product);

            return View(productVM);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,Price,Type,Brand")] ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                var product = ProductMap.ProductVMToProduct(productVM);

                productsRepositories.Edit(product);
                
                return RedirectToAction("Index");
            }
            return View(productVM);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productsRepositories.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }

            var productVM = ProductMap.ProductToProductVM(product);

            return View(productVM);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = productsRepositories.GetById(id);

            productsRepositories.Delete(product);

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
