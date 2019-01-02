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
        readonly Ice Ice;
        readonly Sugar Sugar;
        readonly Lemons Lemons;
       public double startingMoney;
        public double RemainingMoney;
        public Inventory()
        {
            startingMoney = 20.00;
            RemainingMoney = startingMoney;
            Ice = new Ice();
            Sugar = new Sugar();
            Lemons = new Lemons();

        }
       public  void BuyIce()
        {
            Console.WriteLine("How much Ice would you like to buy?");
            Console.WriteLine("Remaining Balnace: $"+ RemainingMoney);
            Console.WriteLine("Costs: " + "$"+Ice.GetPrice());
            int.TryParse(Console.ReadLine(), out ice);
            CalculateSpentMoney(Ice.GetPrice()* ice);
        }
        public void BuySugar()
        {
            Console.WriteLine("How much Sugar would you like to buy?");
            Console.WriteLine("Remaining Balnace: $" + RemainingMoney);
            Console.WriteLine("Costs: " + "$" + Sugar.GetPrice());
            int.TryParse(Console.ReadLine(), out sugar);
            CalculateSpentMoney(Sugar.GetPrice() * sugar);
        }
        public void Buylemons()
        {
            Console.WriteLine("How many Lemons would you like to buy?");
            Console.WriteLine("Remaining Balnace: $" + RemainingMoney);
            Console.WriteLine("Costs: " + "$" + Lemons.GetPrice());
            int.TryParse(Console.ReadLine(), out lemons);
            CalculateSpentMoney(Lemons.GetPrice() * lemons);
        }
        void BuyCups()
        {
            Console.WriteLine("How many Cups would you like to buy?");
            Console.WriteLine("Remaining Balnace: $" + RemainingMoney);
            int.TryParse(Console.ReadLine(), out cups);
        }
        void CalculateSpentMoney(double spent)
        {
            RemainingMoney -= spent;
        }
    }
}
