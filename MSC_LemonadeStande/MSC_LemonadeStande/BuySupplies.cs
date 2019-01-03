using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class BuySupplies
    {
        public void BuyIce(Inventory inventory)
        {

            int prevIce;
            prevIce = inventory.Ice1;
            Console.WriteLine("How much Ice would you like to buy?");
            Console.WriteLine("Remaining Balnace: $" + inventory.RemainingMoney);
            Console.WriteLine("Current on Hand: " + prevIce);
            Console.WriteLine("Costs: " + "$" + inventory.Ice.GetPrice());
            int.TryParse(Console.ReadLine(), out  int ice);
            inventory.Ice1 = ice;
            inventory.CalculateSpentMoney(inventory.Ice.GetPrice() * inventory.Ice1);

            inventory.Ice1 *= 32;
            inventory.Ice1 += prevIce;
        }
        public void BuySugar(Inventory inventory)
        {
            int prevSugar;
            prevSugar = inventory.Sugar1;
            Console.WriteLine("How much Sugar would you like to buy?");
            Console.WriteLine("Remaining Balnace: $" + inventory.RemainingMoney);
            Console.WriteLine("Current on Hand: " + prevSugar);
            Console.WriteLine("Costs: " + "$" + inventory.Sugar.GetPrice());
            int.TryParse(Console.ReadLine(), out int sugar);
            inventory.Sugar1 = sugar;
            inventory.CalculateSpentMoney(inventory.Sugar.GetPrice() * inventory.Sugar1);
            inventory.Sugar1 *= 16;
            inventory.Sugar1 += prevSugar;
        }
        public void Buylemons(Inventory inventory)
        {
            int prevlemons;
            prevlemons = inventory.Lemons1;
            Console.WriteLine("How many Lemons would you like to buy?");
            Console.WriteLine("Remaining Balnace: $" + inventory.RemainingMoney);
            Console.WriteLine("Current on Hand: " + prevlemons);
            Console.WriteLine("Costs: " + "$" + inventory.Lemons.GetPrice());
            int.TryParse(Console.ReadLine(), out int lemons);
            inventory.Lemons1 = lemons;
            inventory.CalculateSpentMoney(inventory.Lemons.GetPrice() * inventory.Lemons1);
            inventory.Lemons1 *= 4;
            inventory.Lemons1 += prevlemons;
        }
    }
}
