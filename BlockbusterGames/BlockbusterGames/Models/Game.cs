using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockbusterGames.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public int price { get; set; }
        public DateTime Release_Date { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int ConsoleTypeId { get; set; }
        public ConsoleType ConsoleType { get; set; }

    }
}