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
        Weather Weather;
        int currentDay;

        public List<Cups> GetCup()
        {
            return prepedCups;
        }
        public void SetCup(List<Cups> value)
        {
            prepedCups = value;
        }
        public void CupContains()
        {
            int i = 1;
            foreach (var item in prepedCups)
            {

                Console.WriteLine("Cup:" + i + $"\nContains Ice:{ item.Ice }"+
                                           $" Sugar: {item.Sugar}"+ $" Lemons: {item.Lemons} "
                                           );
                i++;
            }

        }
        public  void CreateSetNumCups(Inventory inventory,Weather weather,int day)
        {
            SetCup(new List<Cups>());
            Weather = weather;
            currentDay = day;
            Console.WriteLine("How Many Cups would you like to make");
            int.TryParse(Console.ReadLine(), out int numCups);
            while(numCupsToMake < numCups)
            {
                Console.Clear();
                ShowCurrentWeather();
                prepedCups.Add(new Cups());
                prepedCups[numCupsToMake].CreateCup(AskForIce(inventory), AskForSugar(inventory), AskForLemons(inventory), IsFull());
                numCupsToMake++;
                Console.Clear();
                ShowCurrentWeather();
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
        void ShowCurrentWeather()
        {
            Console.Clear();
            Console.WriteLine("Current Weather: " + Weather.WeatherForTheWeek[currentDay].forecast);
            Console.WriteLine("Current Tempature: " + Weather.WeatherForTheWeek[currentDay].temperature);
        }
        public void Profits(Inventory inventory)
        {
            Console.WriteLine("Started the day with:"+ inventory.startingMoney);
            Console.WriteLine("Remaining after Supplier Bought: " + inventory.RemainingMoney);
        }
        void CurrentSupplies(Inventory inventory)
        {

            Console.WriteLine("Started the day with supplies: Ice:" + inventory.ice 
                                      +"Sugar:"+inventory.sugar + "Lemons:"+inventory.lemons 
                                      );
        }
    }
}
