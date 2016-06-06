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
    public class RoomsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rooms
        public ActionResult Index()
        {
            var rooms = db.rooms.Include(r => r.ApplicationUser);
            return View(rooms.ToList());
        }

        // GET: Rooms/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooms rooms = db.rooms.Find(id);
            if (rooms == null)
            {
                return HttpNotFound();
            }

            var list = db.songs.ToList();
            Queue<String> qID = new Queue<string>();
            foreach(var i in list)
            {
                qID.Enqueue(i.VideoID);
            }
            qID.Enqueue("hil1F2T19GY");
            qID.Enqueue("npjF032TDDQ");
            qID.Enqueue("yW0QKrvJPaU");
            qID.Enqueue("cPJUBQd-PNM");
            qID.Enqueue("I-sH53vXP2A");
            qID.Enqueue("hil1F2T19GY");
            qID.Enqueue("hil1F2T19GY");
            qID.Enqueue("hil1F2T19GY");
            qID.Enqueue("hil1F2T19GY");
            ViewBag.Songqueue = qID.ToArray();
            return View(rooms);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            ViewBag.AdminID = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,AdminID")] Rooms rooms)
        {
            if (ModelState.IsValid)
            {
                db.rooms.Add(rooms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdminID = new SelectList(db.Users, "Id", "Email", rooms.AdminID);
            return View(rooms);
        }

        // GET: Rooms/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooms rooms = db.rooms.Find(id);
            if (rooms == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdminID = new SelectList(db.Users, "Id", "Email", rooms.AdminID);
            return View(rooms);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,AdminID")] Rooms rooms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rooms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdminID = new SelectList(db.Users, "Id", "Email", rooms.AdminID);
            return View(rooms);
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooms rooms = db.rooms.Find(id);
            if (rooms == null)
            {
                return HttpNotFound();
            }
            return View(rooms);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Rooms rooms = db.rooms.Find(id);
            db.rooms.Remove(rooms);
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
