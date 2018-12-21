using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockbusterGames.Models
{
    public class RentDTO
    {
        public int RentId { get; set; }
        public int CustomerId { get; set; }
        public int GameId { get; set; }
        public int No_Of_Days { get; set; }
    }
}