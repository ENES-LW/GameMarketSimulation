using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketSimulation
{
    class Customer
    {
        public List<Game> customerGames;
        public Customer()
        {
            customerGames = new List<Game>();
        }
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string  BirthYear { get; set; }
    }
}
