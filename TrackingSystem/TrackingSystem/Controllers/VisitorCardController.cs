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
    public class VisitorCardController : Controller
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
                if (string.IsNullOrEmpty(visitorCard.VisitorName)
                    || string.IsNullOrEmpty(visitorCard.VisitorName.Trim()))
                {
                    ModelState.AddModelError(nameof(visitorCard.VisitorName), "Visitor name is required.");
                    return View(visitorCard);
                }

                visitorCard.VisitorName = visitorCard.VisitorName.Trim();

                if (db.VisitorCard
                    .Any(
                        vc =>
                            visitorCard.Active
                            && vc.Active
                            && string.Compare(
                                vc.VisitorName,
                                visitorCard.VisitorName,
                                StringComparison.InvariantCultureIgnoreCase) == 0)
                )
                {
                    ModelState.AddModelError(nameof(visitorCard.VisitorName), "Visitor with this name already has a card");
                    return View(visitorCard);
                }

                db.VisitorCard.Add(visitorCard);
                db.SaveChanges();
                return View("Details", visitorCard);
            }

            return View(visitorCard);
        }

        //POST: VisitorCards/Deactivate/5
        [HttpGet]
        public ActionResult Deactivate(int? id)
        {
            if (ModelState.IsValid)
            {
                var card = db.VisitorCard.SingleOrDefault(vc => vc.CardId == id);
                if (card == null)
                {
                    ModelState.AddModelError(nameof(id), "Card doesnt exists");
                    return View("Index");
                }

                if (!card.Active)
                {
                    ModelState.AddModelError(nameof(card.Active), "Card is not active");
                }
                else if (card.Attendance.Any(a => !a.CheckOut.HasValue))
                {
                    ModelState.AddModelError(nameof(card.Active), "Card has one or more checked in visits");
                }
                else
                {
                    card.Active = false;
                    db.SaveChanges();
                }

                return View("Details", card);
            }

            return View("Index");
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