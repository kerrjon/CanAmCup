using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CanAmCup.DAL;
using CanAmCup.Models;

namespace CanAmCup.Controllers
{
    public class MatchPlayersController : Controller
    {
        private CanAmContext db = new CanAmContext();

        // GET: MatchPlayers
        public ActionResult Index()
        {
            var matchPlayers = db.MatchPlayers.Include(m => m.Matches).Include(m => m.Players);
            return View(matchPlayers.ToList());
        }

        // GET: MatchPlayers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchPlayer matchPlayer = db.MatchPlayers.Find(id);
            if (matchPlayer == null)
            {
                return HttpNotFound();
            }
            return View(matchPlayer);
        }

        // GET: MatchPlayers/Create
        public ActionResult Create()
        {
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "CourseName");
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "FirstName");
            return View();
        }

        // POST: MatchPlayers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchId,PlayerId")] MatchPlayer matchPlayer)
        {
            if (ModelState.IsValid)
            {
                db.MatchPlayers.Add(matchPlayer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "CourseName", matchPlayer.MatchId);
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "FirstName", matchPlayer.PlayerId);
            return View(matchPlayer);
        }

        // GET: MatchPlayers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchPlayer matchPlayer = db.MatchPlayers.Find(id);
            if (matchPlayer == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "CourseName", matchPlayer.MatchId);
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "FirstName", matchPlayer.PlayerId);
            return View(matchPlayer);
        }

        // POST: MatchPlayers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchId,PlayerId")] MatchPlayer matchPlayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matchPlayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "CourseName", matchPlayer.MatchId);
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "FirstName", matchPlayer.PlayerId);
            return View(matchPlayer);
        }

        // GET: MatchPlayers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchPlayer matchPlayer = db.MatchPlayers.Find(id);
            if (matchPlayer == null)
            {
                return HttpNotFound();
            }
            return View(matchPlayer);
        }

        // POST: MatchPlayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatchPlayer matchPlayer = db.MatchPlayers.Find(id);
            db.MatchPlayers.Remove(matchPlayer);
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
