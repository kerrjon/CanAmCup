﻿using System;
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
    public class ScoresController : Controller
    {
        private CanAmContext db = new CanAmContext();

        // GET: Scores
        public ActionResult Index()
        {
            var scores = db.Scores.Include(s => s.Holes).Include(s => s.Matches);
            return View(scores.ToList());
        }

        // GET: Scores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // GET: Scores/Create
        public ActionResult Create()
        {
            ViewBag.HoleId = new SelectList(db.Holes, "HoleId", "HoleId");
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "CourseName");
            return View();
        }

        // POST: Scores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchId,HoleId,HoleWinner")] Score score)
        {
            if (ModelState.IsValid)
            {
                db.Scores.Add(score);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HoleId = new SelectList(db.Holes, "HoleId", "HoleId", score.HoleId);
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "CourseName", score.MatchId);
            return View(score);
        }

        // GET: Scores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            ViewBag.HoleId = new SelectList(db.Holes, "HoleId", "HoleId", score.HoleId);
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "CourseName", score.MatchId);
            return View(score);
        }

        // POST: Scores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchId,HoleId,HoleWinner")] Score score)
        {
            if (ModelState.IsValid)
            {
                db.Entry(score).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HoleId = new SelectList(db.Holes, "HoleId", "HoleId", score.HoleId);
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "CourseName", score.MatchId);
            return View(score);
        }

        // GET: Scores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // POST: Scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Score score = db.Scores.Find(id);
            db.Scores.Remove(score);
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
