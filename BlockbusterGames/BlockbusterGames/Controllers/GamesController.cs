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
    public class GamesController : Controller
    {
        private BlockbusterContext db = new BlockbusterContext();

        // GET: Games
        public ActionResult Index()
        {

            return View(db.Games.Include(g => g.Genre).Include(g => g.ConsoleType).ToList());
        }

        //search action
        public ActionResult Search()
        {
            return View();
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.ConsoleTypeId = new SelectList(db.Consoles, "ConsoleTypeId", "Console_type");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreType");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameId,Name,price,ConsoleTypeId,GenreId,Release_Date")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConsoleTypeId = new SelectList(db.Consoles, "ConsoleTypeId", "Console_type", game.ConsoleTypeId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreType", game.GenreId);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConsoleTypeId = new SelectList(db.Consoles, "ConsoleTypeId", "Console_type", game.ConsoleTypeId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreType", game.GenreId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the Name properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameId,Name,price,ConsoleTypeId,GenreId,Release_Date")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConsoleTypeId = new SelectList(db.Consoles, "ConsoleTypeId", "Console_type", game.ConsoleTypeId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreType", game.GenreId);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
