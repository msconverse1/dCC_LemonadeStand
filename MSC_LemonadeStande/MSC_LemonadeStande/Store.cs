using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Store
    {
        int numCupsToMake;
        List<Cups> prepedCups;
        public List<Cups> GetCup()
        {
            return prepedCups;
        }
        public void SetCup(List<Cups> value)
        {
            prepedCups = value;
        }
      public  void CreateSetNumCups(Inventory inventory)
        {
            SetCup(new List<Cups>());
            Console.WriteLine("How Many Cups would you like to make");
            int.TryParse(Console.ReadLine(), out int numCups);
            while(numCupsToMake < numCups)
            {
                prepedCups.Add(new Cups());
                prepedCups[numCupsToMake].CreateCup(AskForIce(inventory), AskForSugar(inventory), AskForLemons(inventory), IsFull());
                Console.WriteLine(prepedCups[numCupsToMake]);
                numCupsToMake++;
            }
        }
        public int AskForSugar(Inventory inventory)
        {
            Console.WriteLine("How many spoons of sugar would you like to add?");
            Console.WriteLine("Amount on hand: " + inventory.sugar);
            int.TryParse(Console.ReadLine(), out int spoons);
            if (spoons> inventory.sugar)
            {
              spoons =  AskForSugar(inventory);
                return spoons;
            }
            else
            {
                inventory.sugar -= spoons;
                return spoons;
            }

        }
        public int AskForIce(Inventory inventory)
        {
            Console.WriteLine("How many Cubes of ice would you like to add?");
            Console.WriteLine("Amount on hand: " + inventory.ice);
            int.TryParse(Console.ReadLine(), out int cubes);
            if (cubes > inventory.ice)
            {
               cubes = AskForIce(inventory);
                return cubes;
            }
            else
            {
                inventory.ice -= cubes;
                return cubes;
            }
        }
        public int AskForLemons(Inventory inventory)
        {
            Console.WriteLine("How many Slices of lemons would you like to add?");
            Console.WriteLine("Amount on hand: " + inventory.lemons);
            int.TryParse(Console.ReadLine(), out int lemons);
            if (lemons > inventory.lemons)
            {
                lemons = AskForLemons(inventory);
                return lemons;
            }
            else
            {
                inventory.lemons -= lemons;
                return lemons;
            }
        }
        bool IsFull()
        {
            return true;
        }
        bool IsEmpty()
        {
            return false;
        }
    }
}
