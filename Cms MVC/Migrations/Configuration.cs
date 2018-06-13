namespace Cms_MVC.Migrations
{
    using Cms_MVC.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cms_MVC.Models.CmsDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Cms_MVC.Models.CmsDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //context.SaveChanges();

            if (context.Countries == null || context.Countries.Count() < 1)
            {
                context.Countries.AddOrUpdate(
                                    new Country
                                    {
                                        CountryName = "Sweden",
                                        Population = 10000000
                                    },
                                    new Country
                                    {
                                        CountryName = "Denmark",
                                        Population = 5700000
                                    }
                    );
                    context.SaveChanges();
            }
            if (context.Cities == null || context.Cities.Count() < 1 )
            {
                context.Cities.AddOrUpdate(
                    new City
                    {
                        CityName = "Stockholm",
                        Population = 950000,
                        CountryId = context.Countries.Where(x => x.CountryName == "Sweden").First().CountryId,
                        Country = context.Countries.Where(x => x.CountryName == "Sweden").First()
                    },
                    new City
                    {
                        CityName = "K�penhamn",
                        Population = 580000,
                        CountryId = context.Countries.Where(x => x.CountryName == "Denmark").First().CountryId,
                        Country = context.Countries.Where(x => x.CountryName == "Denmark").First()
                    }
                    );

                context.SaveChanges();
            }

            if (context.People == null || context.People.Count() < 1)
            {
                var people = new List<Person> {
                                    new Person
                                    {
                                        FirstName = "Who",
                                        LastName = "Who",
                                        Email = "Abbott@Costell.com",
                                        Country = context.Countries.First(),
                                        CountryId = context.Countries.First().CountryId,
                                        City = context.Cities.First(),
                                        CityId = context.Cities.First().CityId
                                        
                                    },
                                    new Person
                                    {
                                        FirstName = "What",
                                        LastName = "Who",
                                        Email = "Abbott@Costell.com",
                                        Country = context.Countries.First(),
                                        CountryId = context.Countries.First().CountryId,
                                        City = context.Cities.First(),
                                        CityId = context.Cities.First().CityId
                                    },
                                    new Person
                                     {
                                        FirstName = "I don't know",
                                        LastName = "Who",
                                        Email = "Abbott@Costell.com",
                                        Country = context.Countries.First(),
                                        CountryId = context.Countries.First().CountryId,
                                        City = context.Cities.First(),
                                        CityId = context.Cities.First().CityId
                                     },
                                    new Person
                                    {
                                        FirstName = "Why",
                                        LastName = "Who",
                                        Email = "Abbott@Costell.com",
                                        Country = context.Countries.First(),
                                        CountryId = context.Countries.First().CountryId,
                                        City = context.Cities.First(),
                                        CityId = context.Cities.First().CityId
                                    },
                                    new Person
                                    {
                                        FirstName = "Because",
                                        LastName = "Who",
                                        Email = "Abbott@Costell.com",
                                        Country = context.Countries.First(),
                                        CountryId = context.Countries.First().CountryId,
                                        City = context.Cities.First(),
                                        CityId = context.Cities.First().CityId
                                    },
                                    new Person
                                    {
                                        FirstName = "Today",
                                        LastName = "Who",
                                        Email = "Abbott@Costell.com",
                                        Country = context.Countries.First(),
                                        CountryId = context.Countries.First().CountryId,
                                        City = context.Cities.First(),
                                        CityId = context.Cities.First().CityId
                                    },
                                    new Person
                                    {
                                        FirstName = "Tomorrow",
                                        LastName = "Who",
                                        Email = "Abbott@Costell.com",
                                        Country = context.Countries.First(),
                                        CountryId = context.Countries.First().CountryId,
                                        City = context.Cities.First(),
                                        CityId = context.Cities.First().CityId
                                    },
                                    new Person
                                    {
                                        FirstName = "I don't give a darn",
                                        LastName = "Who",
                                        Email = "Abbott@Costell.com",
                                        Country = context.Countries.First(),
                                        CountryId = context.Countries.First().CountryId,
                                        City = context.Cities.First(),
                                        CityId = context.Cities.First().CityId
                                    } };

                foreach (var item in people)
                {
                    context.People.AddOrUpdate(item);

                }

                context.SaveChanges();
            }
        }
    }
}
