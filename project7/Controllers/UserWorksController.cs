using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project7.Models;

namespace project7.Controllers
{
    public class UserWorksController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: UserWorks
        public async Task<ActionResult> Index()
        {
            var works = db.Works.Include(u => u.Status).Include(u => u.User);
            return View(await works.ToListAsync());
        }

        // GET: UserWorks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWork userWork = await db.Works.FindAsync(id);
            if (userWork == null)
            {
                return HttpNotFound();
            }
            return View(userWork);
        }

        // GET: UserWorks/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.Status, "Id", "NameOfStatus");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: UserWorks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserId,StatusId")] UserWork userWork)
        {
            if (ModelState.IsValid)
            {
                db.Works.Add(userWork);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Status, "Id", "NameOfStatus", userWork.StatusId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", userWork.UserId);
            return View(userWork);
        }

        // GET: UserWorks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWork userWork = await db.Works.FindAsync(id);
            if (userWork == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Status, "Id", "NameOfStatus", userWork.StatusId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", userWork.UserId);
            return View(userWork);
        }

        // POST: UserWorks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserId,StatusId")] UserWork userWork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userWork).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Status, "Id", "NameOfStatus", userWork.StatusId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", userWork.UserId);
            return View(userWork);
        }

        // GET: UserWorks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWork userWork = await db.Works.FindAsync(id);
            if (userWork == null)
            {
                return HttpNotFound();
            }
            return View(userWork);
        }

        // POST: UserWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserWork userWork = await db.Works.FindAsync(id);
            db.Works.Remove(userWork);
            await db.SaveChangesAsync();
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
