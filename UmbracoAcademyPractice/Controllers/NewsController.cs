using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace UmbracoAcademyPractice.Controllers
{
    public class NewsController : SurfaceController, IRenderMvcController
    {
        public ActionResult Index(RenderModel model)
        {
            return View(model);
        }
    }
}