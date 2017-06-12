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
    public class TransactionDetailsController : Controller
    {
        private ExternalBankContext db = new ExternalBankContext();

        // GET: TransactionDetails
        public ActionResult Index()
        {
            var transactionDetail = db.TransactionDetail.Include(t => t.Account);
            return View(transactionDetail.ToList());
        }

        // GET: TransactionDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionDetail transactionDetail = db.TransactionDetail.Find(id);
            if (transactionDetail == null)
            {
                return HttpNotFound();
            }
            return View(transactionDetail);
        }

        // GET: TransactionDetails/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Account, "Id", "Id");
            return View();
        }

        // POST: TransactionDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TransactionId,AccountId,Amount,Description")] TransactionDetail transactionDetail)
        {
            if (ModelState.IsValid)
            {
                db.TransactionDetail.Add(transactionDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Account, "Id", "Id", transactionDetail.AccountId);
            return View(transactionDetail);
        }

        // GET: TransactionDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionDetail transactionDetail = db.TransactionDetail.Find(id);
            if (transactionDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Account, "Id", "Id", transactionDetail.AccountId);
            return View(transactionDetail);
        }

        // POST: TransactionDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TransactionId,AccountId,Amount,Description")] TransactionDetail transactionDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactionDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Account, "Id", "Id", transactionDetail.AccountId);
            return View(transactionDetail);
        }

        // GET: TransactionDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionDetail transactionDetail = db.TransactionDetail.Find(id);
            if (transactionDetail == null)
            {
                return HttpNotFound();
            }
            return View(transactionDetail);
        }

        // POST: TransactionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransactionDetail transactionDetail = db.TransactionDetail.Find(id);
            db.TransactionDetail.Remove(transactionDetail);
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
