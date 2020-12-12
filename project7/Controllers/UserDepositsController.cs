using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project7.Models;

namespace project7.Controllers
{
    public class UserDepositsController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: UserDeposits
        public ActionResult Index()
        {
            return View(db.Deposits.ToList());
        }

        // GET: UserDeposits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDeposit userDeposit = db.Deposits.Find(id);
            if (userDeposit == null)
            {
                return HttpNotFound();
            }
            return View(userDeposit);
        }

        // GET: UserDeposits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDeposits/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AmountOfPrice")] UserDeposit userDeposit)
        {
            if (ModelState.IsValid)
            {
                db.Deposits.Add(userDeposit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDeposit);
        }

        // GET: UserDeposits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDeposit userDeposit = db.Deposits.Find(id);
            if (userDeposit == null)
            {
                return HttpNotFound();
            }
            return View(userDeposit);
        }

        // POST: UserDeposits/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AmountOfPrice")] UserDeposit userDeposit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDeposit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDeposit);
        }

        // GET: UserDeposits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDeposit userDeposit = db.Deposits.Find(id);
            if (userDeposit == null)
            {
                return HttpNotFound();
            }
            return View(userDeposit);
        }

        // POST: UserDeposits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDeposit userDeposit = db.Deposits.Find(id);
            db.Deposits.Remove(userDeposit);
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
