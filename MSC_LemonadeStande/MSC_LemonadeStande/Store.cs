using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Store
    {
        string currentForecast;
        double currentTempature;
        double startingMoney;
        int currentday;
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
      public  void CreateSetNumCups(int cupsToMake)
        {
            SetCup(new List<Cups>());
            while(numCupsToMake < cupsToMake)
            {
                prepedCups.Add(new Cups());
                prepedCups[numCupsToMake].CreateCup(AskForIce(), AskForSugar(), AskForLemons(), IsFull());
                Console.WriteLine(prepedCups[numCupsToMake]);
                numCupsToMake++;
            }

        }
        public int AskForSugar()
        {
            Console.WriteLine("How many spoons of sugar would you like to add?");
            int.TryParse(Console.ReadLine(), out int spoons);
            return spoons;
        }
        public int AskForIce()
        {
            Console.WriteLine("How many Cubes of ice would you like to add?");
            int.TryParse(Console.ReadLine(), out int cubes);
            return cubes;
        }
        public int AskForLemons()
        {
            Console.WriteLine("How many Slices of lemons would you like to add?");
            int.TryParse(Console.ReadLine(), out int lemons);
            return lemons;
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
