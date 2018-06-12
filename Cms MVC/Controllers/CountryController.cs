using Cms_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cms_MVC.Controllers
{
    public class CountryController : Controller
    {
        CmsDb _db = new CmsDb();

        public ActionResult Index()
        {
            var model = _db.Countries.Include("Cities").ToList();
            return View(model);
        }
    }
}