using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoAcademyPractice.Models;

namespace UmbracoAcademyPractice.Controllers
{
    public class SubscriptionController : SurfaceController
    {
        private UmbracoAcademyPracticeDBEntities db = new UmbracoAcademyPracticeDBEntities();

        [HttpPost]
        public ActionResult SubscriptionForm([Bind(Include = "email,date,status")] Subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            var vDate = DateTime.Now;
            var vStatus = "active";
            subscription.date = vDate;
            subscription.status = vStatus;
            db.Subscription.Add(subscription);
            db.SaveChanges();

            return RedirectToCurrentUmbracoPage();
        }
    }
}
