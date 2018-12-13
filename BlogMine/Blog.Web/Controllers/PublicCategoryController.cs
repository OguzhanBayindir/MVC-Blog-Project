using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class PublicCategoryController : Controller
    {
        // GET: PublicCategory
        public ActionResult List()
        {
            return View();
        }
    }
}