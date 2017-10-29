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
                    City = "Zaragoza",
                    Name = "Pepe Perez",
                    Country = "España",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 1,
                    Email = "pepe.perez@gmail.com"
                },
                new Client
                {
                    City = "Huesca",
                    Name = "Maria Luisa Fernandez",
                    Country = "España",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 2,
                    Email = "m.luisa.fernandez@hotmail.com"
                },
                new Client
                {
                    City = "Teruel",
                    Name = "Antonio Sanchez",
                    Country = "España",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 3,
                    Email = "sanchez.antonio@yahoo.es"
                },
                new Client
                {
                    City = "Alcañiz",
                    Name = "Pedro Ruiz",
                    Country = "España",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 4,
                    Email = "pedroruiz@gmail.com"
                },
                new Client
                {
                    City = "Barbastro",
                    Name = "Lucia Perez",
                    Country = "España",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 5,
                    Email = "lucia_perez@gmail.com"
                }
            );

            context.SaveChanges();
        }
    }
}