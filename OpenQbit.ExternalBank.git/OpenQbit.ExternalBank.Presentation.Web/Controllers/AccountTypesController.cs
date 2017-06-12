using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenQbit.ExternalBank.Common.Models;
using OpenQbit.ExternalBank.DAL;

namespace OpenQbit_ExternalBank.Web.Presentation.Controllers
{
    public class AccountTypesController : Controller
    {
        private ExternalBankContext db = new ExternalBankContext();

        // GET: AccountTypes
        public ActionResult Index()
        {
            return View(db.AccountTypes.ToList());
        }

        // GET: AccountTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountTypes accountTypes = db.AccountTypes.Find(id);
            if (accountTypes == null)
            {
                return HttpNotFound();
            }
            return View(accountTypes);
        }

        // GET: AccountTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,SubType,status")] AccountTypes accountTypes)
        {
            if (ModelState.IsValid)
            {
                db.AccountTypes.Add(accountTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountTypes);
        }

        // GET: AccountTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountTypes accountTypes = db.AccountTypes.Find(id);
            if (accountTypes == null)
            {
                return HttpNotFound();
            }
            return View(accountTypes);
        }

        // POST: AccountTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,SubType,status")] AccountTypes accountTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountTypes);
        }

        // GET: AccountTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountTypes accountTypes = db.AccountTypes.Find(id);
            if (accountTypes == null)
            {
                return HttpNotFound();
            }
            return View(accountTypes);
        }

        // POST: AccountTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountTypes accountTypes = db.AccountTypes.Find(id);
            db.AccountTypes.Remove(accountTypes);
            db.SaveChanges();
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
