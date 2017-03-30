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
    public class AttendanceController : Controller
    {
        private TrackingSystemEntities db = new TrackingSystemEntities();

        // GET: Attendance
        public ActionResult Index()
        {
            var attendance = db.Attendance.Include(a => a.VisitorCard);
            return View(attendance.ToList());
        }

        // GET: Attendance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: Attendance/Create
        public ActionResult CheckIn()
        {
            ViewBag.CardId = new SelectList(db.VisitorCard.Where(vc => vc.Active && vc.Attendance.All(a => a.CheckOut.HasValue)), "CardId", "VisitorName");
            return View();
        }

        // GET: Attendance/Create
        public ActionResult CheckOut()
        {
            ViewBag.CardId = new SelectList(db.VisitorCard.Where(vc => vc.Active && vc.Attendance.Any(a => !a.CheckOut.HasValue)), "CardId", "VisitorName");
            return View();
        }

        // POST: Attendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckIn([Bind(Include = "CardId")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                if (db.Attendance.Any(a => a.CardId == attendance.CardId && !a.CheckOut.HasValue))
                {
                        ModelState.AddModelError(nameof(attendance.CardId), "Visitor is already checked in");
                        return View(attendance);                    
                }

                attendance.CheckIn = DateTime.Now;                
                db.Attendance.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CardId = new SelectList(db.VisitorCard, "CardId", "VisitorName", attendance.CardId);
            return View(attendance);
        }
        // POST: Attendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut([Bind(Include = "CardId")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                if (db.Attendance.All(a => a.CardId == attendance.CardId && a.CheckOut.HasValue))
                {
                    ModelState.AddModelError(nameof(attendance.CardId), "Visitor is not checked in");
                    return View(attendance);
                }

                var dbValue = db.Attendance.SingleOrDefault(a => a.CardId == attendance.CardId && !a.CheckOut.HasValue);
                if (dbValue == null)
                {
                    ModelState.AddModelError(nameof(attendance.CardId), "No checked in attendance");
                    return View(attendance);
                }

                dbValue.CheckOut = DateTime.Now;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CardId = new SelectList(db.VisitorCard, "CardId", "VisitorName", attendance.CardId);
            return View(attendance);
        }

        //TODO left for future implementation
        // GET: Attendance/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Attendance attendance = db.Attendance.Find(id);
        //    if (attendance == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(attendance);
        //}

        //// POST: Attendance/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Attendance attendance = db.Attendance.Find(id);
        //    db.Attendance.Remove(attendance);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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