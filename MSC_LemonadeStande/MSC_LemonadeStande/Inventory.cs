using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Inventory
    {
        public int ice;
        public int sugar;
        public int lemons;
        public int cups;
        void BuyIce()
        {
            Console.WriteLine("How much Ice would you like to buy?");
            int.TryParse(Console.ReadLine(), out ice);
        }
        void BuySugar()
        {
            Console.WriteLine("How much Sugar would you like to buy?");
            int.TryParse(Console.ReadLine(), out sugar);
        }
        void Buylemons()
        {
            Console.WriteLine("How many Lemons would you like to buy?");
            int.TryParse(Console.ReadLine(), out lemons);
        }
        void BuyCups()
        {
            Console.WriteLine("How many Cups would you like to buy?");
            int.TryParse(Console.ReadLine(), out cups);
        }
    }
}
