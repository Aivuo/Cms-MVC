using Cms_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cms_MVC.Controllers
{
    public class HomeController : Controller
    {
        CmsDb _db = new CmsDb();

        public ActionResult Index()
        {
            var model = _db.People.Include("Country")
                                  .Include("City")
                                  .ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new Person();
            var model2 = _db.Countries.Include("Cities").ToList();
            //var model3 = _db.Cities.ToList();

            var viewModel = new AddPersonViewModel(model, model2);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Person person, int CountryId, int CityId)
        {
            person.CityId = CityId;
            person.City = _db.Cities.First(x => x.CityId == CityId);
            person.CountryId = CountryId;
            person.Country = _db.Countries.First(x => x.CountryId == CountryId);

            _db.People.Add(person);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = _db.People.Include("City").Include("Country").First(x => x.PersonId == id);
            var model2 = _db.Countries.Include("Cities").ToList();

            var viewModel = new AddPersonViewModel(model, model2);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Person person, int CountryId, int CityId)
        {
            var model = _db.People.Include("City")
                                  .Include("Country")
                                  .First(x => x.PersonId == person.PersonId);
            model.FirstName = person.FirstName;
            model.LastName = person.LastName;
            model.Email = person.Email;

            model.CityId = CityId;
            model.City = _db.Cities.First(x => x.CityId == CityId);

            model.CountryId = CountryId;
            model.Country = _db.Countries.First(x => x.CountryId == CountryId);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}