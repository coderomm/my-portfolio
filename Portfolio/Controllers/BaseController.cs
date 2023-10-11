using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class BaseController : Controller
    {
        private readonly DbCoderOmEntities db = new DbCoderOmEntities();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.About = db.AboutDetailsTbls.SingleOrDefault();

            base.OnActionExecuting(filterContext);
        }
    }
}