using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketSimulation
{
    class GameManager
    {
        public void buyAGame(Customer customer, Game game)
        {
            Console.WriteLine("\t--------------------you bought " + game.Name + " \nClick a key to continue");
            customer.customerGames.Add(game);
        }
    }
}
