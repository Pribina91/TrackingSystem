using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrackingSystem.Models;

namespace TrackingSystem.Controllers
{
    public class VisitorCardsController : Controller
    {
        private TrackingSystemEntities db = new TrackingSystemEntities();

        // GET: VisitorCards
        public ActionResult Index()
        {
            return View(db.VisitorCard.ToList());
        }

        // GET: VisitorCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitorCard visitorCard = db.VisitorCard.Find(id);
            if (visitorCard == null)
            {
                return HttpNotFound();
            }
            return View(visitorCard);
        }

        // GET: VisitorCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VisitorCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CardId,Active,VisitorName")] VisitorCard visitorCard)
        {
            if (ModelState.IsValid)
            {
                db.VisitorCard.Add(visitorCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visitorCard);
        }

        // GET: VisitorCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitorCard visitorCard = db.VisitorCard.Find(id);
            if (visitorCard == null)
            {
                return HttpNotFound();
            }
            return View(visitorCard);
        }

        // POST: VisitorCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CardId,Active,VisitorName")] VisitorCard visitorCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitorCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visitorCard);
        }

        // GET: VisitorCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitorCard visitorCard = db.VisitorCard.Find(id);
            if (visitorCard == null)
            {
                return HttpNotFound();
            }
            return View(visitorCard);
        }

        // POST: VisitorCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitorCard visitorCard = db.VisitorCard.Find(id);
            db.VisitorCard.Remove(visitorCard);
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
