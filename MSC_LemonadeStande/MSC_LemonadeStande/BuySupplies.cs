using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class BuySupplies
    {
        private int prevIce;
        int prevSugar;
        int prevlemons;

        public int PrevSugar { get => prevSugar; set => prevSugar = value; }
        public int Prevlemons { get => prevlemons; set => prevlemons = value; }
        public int PrevIce { get => prevIce; set => prevIce = value; }

        public void BuyIce(Inventory inventory)
        {
            PrevIce = inventory.Ice1;
            Console.WriteLine("How much Ice would you like to buy?");
            Console.WriteLine("Remaining Balnace: $" + inventory.RemainingMoney);
            
                Console.WriteLine("Current on Hand: " + PrevIce);
          
                Console.WriteLine("Costs: " + "$" + inventory.Ice.GetPrice());
            int.TryParse(Console.ReadLine(), out  int ice);
            
            inventory.Ice1 = ice;
            
            inventory.CalculateSpentMoney((float)inventory.Ice.GetPrice() * inventory.Ice1);
            inventory.Ice1 *= 32;
            inventory.Ice1 += PrevIce;
        }
        public void BuySugar(Inventory inventory)
        {
           
            prevSugar = inventory.Sugar1;
            Console.WriteLine("How much Sugar would you like to buy?");
            Console.WriteLine("Remaining Balnace: $" + inventory.RemainingMoney);
            Console.WriteLine("Current on Hand: " + PrevSugar);
            Console.WriteLine("Costs: " + "$" + inventory.Sugar.GetPrice());
            int.TryParse(Console.ReadLine(), out int sugar);
            inventory.Sugar1 = sugar;
            inventory.CalculateSpentMoney((float)inventory.Sugar.GetPrice() * inventory.Sugar1);
            inventory.Sugar1 *= 16;
            inventory.Sugar1 += PrevSugar;
        }
        public void Buylemons(Inventory inventory)
        {
            Prevlemons = inventory.Lemons1;
            Console.WriteLine("How many Lemons would you like to buy?");
            Console.WriteLine("Remaining Balnace: $" + inventory.RemainingMoney);
            Console.WriteLine("Current on Hand: " + Prevlemons);
            Console.WriteLine("Costs: " + "$" + inventory.Lemons.GetPrice());
            int.TryParse(Console.ReadLine(), out int lemons);
            inventory.Lemons1 = lemons;
            inventory.CalculateSpentMoney((float)inventory.Lemons.GetPrice() * inventory.Lemons1);
            inventory.Lemons1 *= 4;
            inventory.Lemons1 += Prevlemons;
        }
    }
}
