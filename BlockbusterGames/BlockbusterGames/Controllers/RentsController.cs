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
    public class RentsController : Controller
    {
        private BlockbusterContext db = new BlockbusterContext();

        // GET: Rents
        public ActionResult Index()
        {
            //var rents = db.Rents.Include(r => r.ConsoleType).Include(r => r.Customer).Include(r => r.Game).Include(r => r.Genre);
            var rents = db.Rents;
            return View(rents.ToList());
        }

        // GET: Rents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = db.Rents.Find(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }

        // GET: Rents/Create
        public ActionResult Create()
        {
            
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            ViewBag.GameId = new SelectList(db.Games, "GameId", "Name");
            return View();
        }

        //GET: Rents/Search
        public ActionResult Search()
        {
            return View();
        }
        // POST: Rents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentId,CustomerId,GameId,No_Of_Days")] Rent rent)
        {
            if (ModelState.IsValid)
            {
                db.Rents.Add(rent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.ConsoleTypeId = new SelectList(db.Consoles, "ConsoleTypeId", "Console_type", rent.ConsoleTypeId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", rent.CustomerId);
            ViewBag.GameId = new SelectList(db.Games, "GameId", "Name", rent.GameId);
            //ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreType", rent.GenreId);
            return View(rent);
        }

        // GET: Rents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = db.Rents.Find(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ConsoleTypeId = new SelectList(db.Consoles, "ConsoleTypeId", "Console_type", rent.ConsoleTypeId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", rent.CustomerId);
            ViewBag.GameId = new SelectList(db.Games, "GameId", "Name", rent.GameId);
            //ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreType", rent.GenreId);
            return View(rent);
        }

        // POST: Rents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentId,CustomerId,GameId,ConsoleTypeId,GenreId,No_Of_Days")] Rent rent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ConsoleTypeId = new SelectList(db.Consoles, "ConsoleTypeId", "Console_type", rent.ConsoleTypeId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", rent.CustomerId);
            ViewBag.GameId = new SelectList(db.Games, "GameId", "Name", rent.GameId);
           // ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreType", rent.GenreId);
            return View(rent);
        }

        // GET: Rents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = db.Rents.Find(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }

        // POST: Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rent rent = db.Rents.Find(id);
            db.Rents.Remove(rent);
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
