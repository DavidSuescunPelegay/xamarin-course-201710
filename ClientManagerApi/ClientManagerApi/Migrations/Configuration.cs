using System.Collections.Generic;
using System.Runtime.Remoting;
using ClientManagerApi.Models;

namespace ClientManagerApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClientManagerApi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClientManagerApi.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Clients.AddOrUpdate(
                new Client
                {
                    City = "Alicante",
                    Name = "Kasper Brown",
                    Country = "Spain",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 1,
                    Email = "curabitur.massa @ut.ca"
                },
                new Client
                {
                    City = "Eastonberg",
                    Name = "Elise Steuber V",
                    Country = "Saint Barthélemy",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 2,
                    Email = "Conrad.Dickinson@wiley.biz"
                },
                new Client
                {
                    City = "Pansyview",
                    Name = "Kaley Kris",
                    Country = "Sweden",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 3,
                    Email = "Andrew@daron.me"
                },
                new Client
                {
                    City = "Runteland",
                    Name = "Tressa Gerhold",
                    Country = "Brazil",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 4,
                    Email = "Billie@lew.io"
                },
                new Client
                {
                    City = "Ebonystad",
                    Name = "Kyler Marks Jr.",
                    Country = "Trinidad and Tobago",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 5,
                    Email = "Easton_Farrell@magdalen.us"
                },
                new Client
                {
                    City = "Konopelskiland",
                    Name = "Mr. Jamey Williamson",
                    Country = "Guinea-Bissau",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 6,
                    Email = "Marquis@hailey.tv"
                },
                new Client
                {
                    City = "Mayratown",
                    Name = "Brianne Borer",
                    Country = "San Marino",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 7,
                    Email = "Abbigail.Howe@troy.net"
                },
                new Client
                {
                    City = "North Maxieburgh",
                    Name = "Brennon Reilly",
                    Country = "Brunei",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 8,
                    Email = "Amelia@arnaldo.biz"
                },
                new Client
                {
                    City = "South Wyman",
                    Name = "Dr. Ashley Gleichner",
                    Country = "Pacific Islands Trust Territory",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 9,
                    Email = "Jaylon@kristoffer.tv"
                }
            );

            context.SaveChanges();
        }
    }
}