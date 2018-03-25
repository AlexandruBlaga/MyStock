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
    public class PartnersController : Controller
    {
        private lannisterEntities db = new lannisterEntities();
        private IPartnersRepositories partnersRepositories = new PartnersRepositories();

        // GET: Partners
        public ActionResult Index()
        {
            var partnersVM = new List<Partner>();

            foreach (var partner in partnersRepositories.GetAll())
            {
                var partnerVM = PartnerMap.PartnerToPartnerVM(partner);
            }

            return View(partnersVM);
        }

        // GET: Partners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = partnersRepositories.GetById(id.Value);
            if (partner == null)
            {
                return HttpNotFound();
            }

            var partnerVM = PartnerMap.PartnerToPartnerVM(partner);

            return View(partnerVM);
        }

        // GET: Partners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Partners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartnerId,Name,Phone,Card")] PartnerVM partnerVM)
        {
            var partner = PartnerMap.PartnerVMToPartner(partnerVM);

            if (ModelState.IsValid)
            {
                partnersRepositories.Add(partner);
                return RedirectToAction("Index");
            }

            return View(partnerVM);
        }

        // GET: Partners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = partnersRepositories.GetById(id.Value);
            if (partner == null)
            {
                return HttpNotFound();
            }

            var partnerVM = PartnerMap.PartnerToPartnerVM(partner);

            return View(partnerVM);
        }

        // POST: Partners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartnerId,Name,Phone,Card")] PartnerVM partnerVM)
        {
            var partner = PartnerMap.PartnerVMToPartner(partnerVM);

            if (ModelState.IsValid)
            {
                partnersRepositories.Edit(partner);
                return RedirectToAction("Index");
            }
            return View(partner);
        }

        // GET: Partners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = partnersRepositories.GetById(id.Value);
            if (partner == null)
            {
                return HttpNotFound();
            }

            var partnerVM = PartnerMap.PartnerToPartnerVM(partner);

            return View(partnerVM);
        }

        // POST: Partners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partner partner = partnersRepositories.GetById(id);

            partnersRepositories.Delete(partner);

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
