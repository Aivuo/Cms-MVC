namespace Cms_MVC.Migrations
{
    using Cms_MVC.Models;
    using System;
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

            context.People.AddOrUpdate(
                                new Person
                                {
                                    FirstName = "Who",
                                    LastName = "Who",
                                    Email = "Abbott@Costell.com"
                                },
                                new Person
                                {
                                    FirstName = "What",
                                    LastName = "Who",
                                    Email = "Abbott@Costell.com"
                                },
                                new Person
                                 {
                                     FirstName = "I don't know",
                                     LastName = "Who",
                                     Email = "Abbott@Costell.com"
                                 },
                                new Person
                                {
                                    FirstName = "Why",
                                    LastName = "Who",
                                    Email = "Abbott@Costell.com"
                                },
                                new Person
                                {
                                    FirstName = "Because",
                                    LastName = "Who",
                                    Email = "Abbott@Costell.com"
                                },
                                new Person
                                {
                                    FirstName = "Today",
                                    LastName = "Who",
                                    Email = "Abbott@Costell.com"
                                },
                                new Person
                                {
                                    FirstName = "Tomorrow",
                                    LastName = "Who",
                                    Email = "Abbott@Costell.com"
                                },
                                new Person
                                {
                                    FirstName = "I don't give a darn",
                                    LastName = "Who",
                                    Email = "Abbott@Costell.com"
                                }
                );
            context.SaveChanges();

            context.Countries.AddOrUpdate(
                                new Country
                                {
                                    CountryName = "Sweden",
                                    Population = 10000000
                                },
                                new Country
                                {
                                    CountryName = "Denmark",
                                    Population = 6000000
                                }
                );
            context.SaveChanges();

            context.Cities.AddOrUpdate(
                new City
                {
                    CityName = "Stockholm",
                    Population = 2000000,
                    CountryId = context.Countries.Where(x => x.CountryName == "Sweden").First().CountryId,
                    Country = context.Countries.Where(x => x.CountryName == "Sweden").First()
                },
                new City
                {
                    CityName = "Köpenhamn",
                    Population = 1000000,
                    CountryId = context.Countries.Where(x => x.CountryName == "Denmark").First().CountryId,
                    Country = context.Countries.Where(x => x.CountryName == "Denmark").First()
                }
                );
        }
    }
}
