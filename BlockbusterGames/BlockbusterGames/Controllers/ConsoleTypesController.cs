using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlockbusterGames.Models;

namespace BlockbusterGames.Controllers
{
    public class ConsoleTypesController : Controller
    {
        private BlockbusterContext db = new BlockbusterContext();

        // GET: ConsoleTypes
        public ActionResult Index()
        {
            return View(db.Consoles.ToList());
        }

        // GET: ConsoleTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsoleType consoleType = db.Consoles.Find(id);
            if (consoleType == null)
            {
                return HttpNotFound();
            }
            return View(consoleType);
        }

        // GET: ConsoleTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConsoleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConsoleTypeId,Console_type,Price")] ConsoleType consoleType)
        {
            if (ModelState.IsValid)
            {
                db.Consoles.Add(consoleType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consoleType);
        }

        // GET: ConsoleTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsoleType consoleType = db.Consoles.Find(id);
            if (consoleType == null)
            {
                return HttpNotFound();
            }
            return View(consoleType);
        }

        // POST: ConsoleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConsoleTypeId,Console_type,Price")] ConsoleType consoleType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consoleType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consoleType);
        }

        // GET: ConsoleTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsoleType consoleType = db.Consoles.Find(id);
            if (consoleType == null)
            {
                return HttpNotFound();
            }
            return View(consoleType);
        }

        // POST: ConsoleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConsoleType consoleType = db.Consoles.Find(id);
            db.Consoles.Remove(consoleType);
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
