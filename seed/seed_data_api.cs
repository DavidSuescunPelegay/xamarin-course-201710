context.Clients.AddOrUpdate(
                new Client
                {
                    City = "Zaragoza",
                    Name = "Pepe Perez",
                    Country = "España",
                    Image = "https://cdn.pixabay.com/photo/2015/06/28/03/17/man-824125_960_720.jpg",
                    ClientId = 1,
                    Email = "pepe.perez@gmail.com"
                },
                new Client
                {
                    City = "Huesca",
                    Name = "Maria Luisa Fernandez",
                    Country = "España",
                    Image = "https://cdn.pixabay.com/photo/2015/06/28/03/17/man-824125_960_720.jpg",
                    ClientId = 2,
                    Email = "m.luisa.fernandez@hotmail.com"
                },
                new Client
                {
                    City = "Teruel",
                    Name = "Antonio Sanchez",
                    Country = "España",
                    Image = "https://cdn.pixabay.com/photo/2015/06/28/03/17/man-824125_960_720.jpg",
                    ClientId = 3,
                    Email = "sanchez.antonio@yahoo.es"
                },
                new Client
                {
                    City = "Alcañiz",
                    Name = "Pedro Ruiz",
                    Country = "España",
                    Image = "https://cdn.pixabay.com/photo/2015/06/28/03/17/man-824125_960_720.jpg",
                    ClientId = 4,
                    Email = "pedroruiz@gmail.com"
                },
                new Client
                {
                    City = "Barbastro",
                    Name = "Lucia Perez",
                    Country = "España",
                    Image = "https://cdn.pixabay.com/photo/2015/06/28/03/17/man-824125_960_720.jpg",
                    ClientId = 5,
                    Email = "lucia_perez@gmail.com"
                }
            );

            context.SaveChanges();