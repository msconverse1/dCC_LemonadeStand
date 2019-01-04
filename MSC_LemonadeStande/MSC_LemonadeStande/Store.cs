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

        internal Inventory CurrentItems { get; set; }

        public Store()
        {
            buySupplies = new BuySupplies();
            CurrentItems = new Inventory();
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
        public  void CreateSetNumCups(Weather weather,int day)
        {
            SetCup(new List<Cups>());
            numCupsToMake = 0;
            currentDay = day;
            Console.WriteLine("How Many Cups would you like to make?");
            Console.WriteLine("Currently have Ice:" + CurrentItems.Ice1 + "Currently have Sugar: " + CurrentItems.Sugar1 +
                                       "Currently have Lemons: " + CurrentItems.Lemons1);
            int.TryParse(Console.ReadLine(), out int numCups);
            while(numCupsToMake < numCups)
            {
                Console.Clear();
                ShowCurrentWeather(weather);
                prepedCups.Add(new Cups());
                Console.WriteLine("Cup: " + numCupsToMake);
                prepedCups[numCupsToMake].CreateCup(AskForIce(CurrentItems), AskForSugar(CurrentItems), AskForLemons(CurrentItems), IsFull());
                numCupsToMake++;
                Console.Clear();
                ShowCurrentWeather(weather);
            }
            SetPriceOfEachCup( weather.WeatherForTheWeek[currentDay].ChangePrice);
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
        public void Profits()
        {
            Console.WriteLine("Started the day with:"+ CurrentItems.StartingMoney);
            Console.WriteLine("Remaining after Supplier Bought: " + CurrentItems.RemainingMoney);
        }
        void CurrentSupplies()
        {
            Console.WriteLine("Started the day with supplies: Ice: " + CurrentItems.Ice1 
                                      +"\nSugar: "+ CurrentItems.Sugar1 + "\nLemons: "+ CurrentItems.Lemons1 
                                      );
        }
        void SetPriceOfEachCup(double factor)
        {
            foreach (var item in prepedCups)
            {
                //sugar is 1.5, ice .75 , lemons 2.25 1cup cost 4.5 to make
                //16,32,4
                item.SetPrice(( ((CurrentItems.Sugar.GetPrice()/4 * item.Sugar)
                                 + (CurrentItems.Lemons.GetPrice()/2 * item.Lemons)
                                 + (CurrentItems.Ice.GetPrice()/3 * item.Ice))* factor
                                  ));
            }
        }
       public void CalculateDaysPay()
        {
            Console.WriteLine("End of the Day Report!");
            Console.WriteLine("Is total Cash in Store: $" +(CurrentItems.CollectedMoney + CurrentItems.RemainingMoney));
            Console.WriteLine("Is current profits based off Started with after Supplies where bought: $" +(CurrentItems.CollectedMoney- CurrentItems.StartingMoney));
            CurrentItems.RemainingMoney += CurrentItems.CollectedMoney;
            CurrentItems.StartingMoney = CurrentItems.RemainingMoney;
        }

        public void CreateInventory()
        {
            buySupplies.BuyIce(CurrentItems);
            buySupplies.Buylemons(CurrentItems);
            buySupplies.BuySugar(CurrentItems);
        }
    }
}
