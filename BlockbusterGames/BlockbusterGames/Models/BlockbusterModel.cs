using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BlockbusterGames.Models
{
    public class BlockbusterContext : DbContext
    {
        public BlockbusterContext() : base("BlockbusterContext")
        {

        }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ConsoleType> Consoles { get; set; }
        public DbSet<Customer> Customers { get; set; }


    }
}