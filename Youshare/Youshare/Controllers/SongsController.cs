using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Youshare.Models;

namespace Youshare.Controllers
{
    public class SongsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Songs
        public ActionResult Index()
        {
            var songs = db.songs.Include(s => s.ApplicationUser);
            return View(songs.ToList());
        }

        // GET: Songs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Songs songs = db.songs.Find(id);
            if (songs == null)
            {
                return HttpNotFound();
            }
            return View(songs);
        }

        // GET: Songs/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,VideoID")] Songs songs)
        {
            if (ModelState.IsValid)
            {
                db.songs.Add(songs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", songs.UserID);
            return View(songs);
        }

        // GET: Songs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Songs songs = db.songs.Find(id);
            if (songs == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", songs.UserID);
            return View(songs);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,VideoID")] Songs songs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(songs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", songs.UserID);
            return View(songs);
        }

        // GET: Songs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Songs songs = db.songs.Find(id);
            if (songs == null)
            {
                return HttpNotFound();
            }
            return View(songs);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Songs songs = db.songs.Find(id);
            db.songs.Remove(songs);
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
