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
       public List<Cups> prepedCups;
        public BuySupplies buySupplies;
        int currentDay;
        public Store()
        {
            buySupplies = new BuySupplies();
        }
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
                                           $" Sugar: {item.Sugar}"+ $" Lemons: {item.Lemons} " + 
                                           $" Price: {item.GetPrice()}"
                                           );
                i++;
            }

        }
        public  void CreateSetNumCups(Inventory inventory,Weather weather,int day)
        {
            SetCup(new List<Cups>());
            numCupsToMake = 0;
            currentDay = day;
            Console.WriteLine("How Many Cups would you like to make");
            int.TryParse(Console.ReadLine(), out int numCups);
            while(numCupsToMake < numCups)
            {
                Console.Clear();
                ShowCurrentWeather(weather);
                prepedCups.Add(new Cups());
                prepedCups[numCupsToMake].CreateCup(AskForIce(inventory), AskForSugar(inventory), AskForLemons(inventory), IsFull());
               
                numCupsToMake++;
                Console.Clear();
                ShowCurrentWeather(weather);
            }
            SetPriceOfEachCup(inventory, weather.WeatherForTheWeek[currentDay].ChangePrice);
        }
        public int AskForSugar(Inventory inventory)
        {
            Console.WriteLine("How many spoons of sugar would you like to add?");
            Console.WriteLine("Amount on hand: " + inventory.Sugar1);
            int.TryParse(Console.ReadLine(), out int spoons);
            if (spoons> inventory.Sugar1)
            {
              spoons =  AskForSugar(inventory);
                return spoons;
            }
            else
            {
                inventory.Sugar1 -= spoons;
                return spoons;
            }

        }
        public int AskForIce(Inventory inventory)
        {
            Console.WriteLine("How many Cubes of ice would you like to add?");
            Console.WriteLine("Amount on hand: " + inventory.Ice1);
            int.TryParse(Console.ReadLine(), out int cubes);
            if (cubes > inventory.Ice1)
            {
               cubes = AskForIce(inventory);
                return cubes;
            }
            else
            {
                inventory.Ice1 -= cubes;
                return cubes;
            }
        }
        public int AskForLemons(Inventory inventory)
        {
            Console.WriteLine("How many Slices of lemons would you like to add?");
            Console.WriteLine("Amount on hand: " + inventory.Lemons1);
            int.TryParse(Console.ReadLine(), out int lemons);
            if (lemons > inventory.Lemons1)
            {
                lemons = AskForLemons(inventory);
                return lemons;
            }
            else
            {
                inventory.Lemons1 -= lemons;
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
        void ShowCurrentWeather(Weather weather)
        {
            Console.Clear();
            Console.WriteLine("Current Weather: " + weather.WeatherForTheWeek[currentDay].Forecast);
            Console.WriteLine("Current Tempature: " + weather.WeatherForTheWeek[currentDay].Temperature);
        }
        public void Profits(Inventory inventory)
        {
            Console.WriteLine("Started the day with:"+ inventory.StartingMoney);
            Console.WriteLine("Remaining after Supplier Bought: " + inventory.RemainingMoney);
        }
        void CurrentSupplies(Inventory inventory)
        {
            Console.WriteLine("Started the day with supplies: Ice:" + inventory.Ice1 
                                      +"Sugar:"+inventory.Sugar1 + "Lemons:"+inventory.Lemons1 
                                      );
        }
        void SetPriceOfEachCup(Inventory inventory,double factor)
        {
            foreach (var item in prepedCups)
            {
                //sugar is 1.5, ice .75 , lemons 2.25 1cup cost 4.5 to make
                //16,32,4
                item.SetPrice(( ((inventory.Sugar.GetPrice()/4 * item.Sugar)
                                 + (inventory.Lemons.GetPrice()/2 * item.Lemons)
                                 + (inventory.Ice.GetPrice()/3 * item.Ice))* factor
                                  ));
            }
        }
       public void CalculateDaysPay(Inventory inventory)
        {
            Console.WriteLine("Is total Cash in Store" +( inventory.CollectedMoney + inventory.RemainingMoney));
            Console.WriteLine("Is current profits based off Started with after Supplies where bought" +(inventory.CollectedMoney- inventory.StartingMoney));
            inventory.RemainingMoney += inventory.CollectedMoney;
        }
    }
}
