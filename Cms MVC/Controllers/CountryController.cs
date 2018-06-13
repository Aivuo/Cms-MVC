using Cms_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cms_MVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CountryController : Controller
    {
        CmsDb _db = new CmsDb();

        public ActionResult Index()
        {
            var model = _db.Countries.Include("Cities").ToList();
            return View(model);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _db.Countries.Add(country);
                _db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = _db.Countries.Include("Cities")
                                     .First(x => x.CountryId == id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Country country, params int[] Cities)
        {
            if (country != null)
            {
                var model = _db.Countries.Include("Cities")
                                         .First(x => x.CountryId == country.CountryId);
                model.CountryName = country.CountryName;
                model.Population = country.Population;

                if (Cities != null)
                {
                    foreach (var item in Cities)
                    {
                        var removeMe = model.Cities.First(x => x.CityId == item);
                        model.Cities.Remove(removeMe);
                        _db.Cities.Remove(removeMe);
                    }
                }
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult EditCity(int id)
        {
            var model = _db.Cities.Include("Country")
                                  .First(x => x.CityId == id);
            var model2 = _db.Countries.ToList();

            var viewModel = new EditCityViewModel(model, model2);


            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditCity(City city, int CountryId)
        {
            if (city == null)
            {
                return View();
            }
            var model = _db.Cities.Include("Country").First(x => x.CityId == city.CityId);

            model.CityName = city.CityName;
            model.Population = city.Population;

            model.Country = _db.Countries.First(x => x.CountryId == CountryId);
            model.CountryId = model.Country.CountryId;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult AddCity(int CountryId)
        {
            var model = new City
            {
                CountryId = CountryId
            };
            var model2 = _db.Countries.ToList();

            var viewModel = new EditCityViewModel(model, model2);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddCity(City city, int CountryId)
        {
            if (city == null)
            {
                return View();
            }
            var model = new City
            {
                CityName = city.CityName,
                Population = city.Population,

                Country = _db.Countries.First(x => x.CountryId == CountryId)
            };
            model.CountryId = model.Country.CountryId;

            _db.Cities.Add(model);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}