namespace BlockbusterGames.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using BlockbusterGames.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<BlockbusterGames.Models.BlockbusterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlockbusterGames.Models.BlockbusterContext context)
        {
             var customers = new List<Customer>
            {
                new Customer {Name="John", Address="22 vicar street, Rathmines, Dublin", city="Dublin"},
                new Customer {Name="Sherlock", Address="221B baker street, London", city="London"},
                new Customer {Name="Watson", Address="12 new street, Brey, Wicklow", city="Wicklow"},
                new Customer {Name="Luther", Address="4 newer street, Galway", city="Galway"},
                new Customer {Name="James Doe", Address="52 nwweesy street, Cork", city="Cork"}
            };
            customers.ForEach(u => context.Customers.AddOrUpdate(customer => customer.Name, u));
            context.SaveChanges();

            var genres = new List<Genre>
            {
                new Genre {GenreType="Racing" },
                new Genre {GenreType="Sports"},
                new Genre {GenreType="Indie"},
                new Genre {GenreType="Competitive"},
                new Genre {GenreType="Co-OP"}
            };
            genres.ForEach(g => context.Genres.AddOrUpdate(genre => genre.GenreType, g));
            context.SaveChanges();

            var consoles = new List<ConsoleType>
            {
                new ConsoleType {Console_type="PS2" ,Price=4},
                new ConsoleType {Console_type="Xbox One X",Price=4},
                new ConsoleType {Console_type="PS3",Price=4},
                new ConsoleType {Console_type="Xbox One",Price=4}
            };
            consoles.ForEach(d => context.Consoles.AddOrUpdate(console => console.Console_type, d));
            context.SaveChanges();
        }
    }
}
