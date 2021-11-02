using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UmbracoAcademyPractice.Models;

namespace UmbracoAcademyPractice.Controllers
{
    public class SubscriptionController : Controller
    {
        private UmbracoAcademyPracticeDBEntities db = new UmbracoAcademyPracticeDBEntities();

        // GET: Subscription
        public ActionResult Index()
        {
            return View(db.Subscription.ToList());
        }

        // GET: Subscription/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscription.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // GET: Subscription/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subscription/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "email,date,status")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Subscription.Add(subscription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subscription);
        }

        // GET: Subscription/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscription.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // POST: Subscription/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "email,date,status")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subscription);
        }

        // GET: Subscription/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscription.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // POST: Subscription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Subscription subscription = db.Subscription.Find(id);
            db.Subscription.Remove(subscription);
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
