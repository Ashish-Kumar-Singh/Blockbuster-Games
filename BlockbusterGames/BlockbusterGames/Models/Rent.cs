using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockbusterGames.Models
{
    public class Rent
    {
        public int RentId { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        //public virtual Genre Genre { get; set; }
        //public int ConsoleTypeId { get; set; }
        //public virtual ConsoleType ConsoleType { get; set; }
        //public int GenreId { get; set; }
        public int No_Of_Days { get; set; }


    }
}