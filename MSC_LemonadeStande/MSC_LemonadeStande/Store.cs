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
        public Inventory CurrentItems { get; set; }
        bool IsFull()
        {
            return true;
        }
        bool IsEmpty()
        {
            return false;
        }
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
        public  void CreateSetNumCups(int day)
        {
            SetCup(new List<Cups>());
            numCupsToMake = 0;
            currentDay = day;
            Console.WriteLine("How Many Cups would you like to make?");
            Console.WriteLine("Currently have Ice:" + CurrentItems.Ice1 + "Currently have Sugar: " + CurrentItems.Sugar1 +
                                       "Currently have Lemons: " + CurrentItems.Lemons1);
            int.TryParse(Console.ReadLine(), out int numCups);
            Console.WriteLine("how many cups do you want to make the same?");
            int.TryParse(Console.ReadLine(), out int setOfCups);

            if (setOfCups >= 2&& setOfCups < numCups)
            {
                int ice = AskForIce(CurrentItems,setOfCups);
                int lemons = AskForLemons(CurrentItems,setOfCups);
                int sugar = AskForSugar(CurrentItems,setOfCups);

                for (int i = 0; i < setOfCups; i++)
                {
                    prepedCups.Add(new Cups());
                    prepedCups[i].CreateCup(ice, lemons, sugar, IsFull());
                }

                numCupsToMake = setOfCups;
            }
            while (numCupsToMake < numCups)
                {
                setOfCups = 0;
                Console.Clear();
                    GwAPI.GetADaysWeather(currentDay);
                    //ShowCurrentWeather(weather);
                    prepedCups.Add(new Cups());
                    Console.WriteLine("Cup: " + numCupsToMake);
                    prepedCups[numCupsToMake].CreateCup(AskForIce(CurrentItems,setOfCups), AskForSugar(CurrentItems,setOfCups), AskForLemons(CurrentItems,setOfCups), IsFull());
                    numCupsToMake++;

                    GwAPI.GetADaysWeather(currentDay);
                    //ShowCurrentWeather(weather);
                }
            if (setOfCups>numCups)
            {
                Console.WriteLine("Your set is higher than the numer of cups you can make lets try again");
                CreateSetNumCups(day);
            }
                                
            SetPriceOfEachCup(GwAPI.weeksWeathers[currentDay].ChangePrice);
        }
        public int AskForSugar(Inventory inventory,int setOfCups)
        {
            Console.WriteLine("How many spoons of sugar would you like to add?");
            Console.WriteLine("Amount on hand: " + inventory.Sugar1);
            int.TryParse(Console.ReadLine(), out int spoons);
            if (setOfCups == 0)
            {
                setOfCups = 1;
            }
            if (spoons> inventory.Sugar1)
            {
              spoons =  AskForSugar(inventory,setOfCups);
              return spoons;
            }
            else
            {
                if ((spoons * setOfCups)< inventory.Sugar1)

                {
                    inventory.Sugar1 -= (spoons * setOfCups);
                    return spoons;
                }
                else
                {
                    spoons = AskForSugar(inventory, setOfCups);
                    return spoons;
                }
            }
        }
        public int AskForIce(Inventory inventory,int setOfCups)
        {
            Console.WriteLine("How many Cubes of ice would you like to add?");
            Console.WriteLine("Amount on hand: " + inventory.Ice1);
            int.TryParse(Console.ReadLine(), out int cubes);
            if (setOfCups ==0)
            {
                setOfCups = 1;
            }
            if (cubes > inventory.Ice1)
            {
               cubes = AskForIce(inventory,setOfCups);
                return cubes;
            }
            else
            {
                if ((cubes*setOfCups) <= inventory.Ice1)
                {
                    inventory.Ice1 -= (cubes * setOfCups);
                    return cubes;
                }
                else
                {
                    cubes = AskForIce(inventory, setOfCups);
                    return cubes;
                }
            }
        }
        public int AskForLemons(Inventory inventory,int setOfCups)
        {
            Console.WriteLine("How many Slices of lemons would you like to add?");
            Console.WriteLine("Amount on hand: " + inventory.Lemons1);
            int.TryParse(Console.ReadLine(), out int lemons);
            if (setOfCups == 0)
            {
                setOfCups = 1;
            }
            if (lemons > inventory.Lemons1)
            {
                lemons = AskForLemons(inventory,setOfCups);
                return lemons;
            }
            else
            {
                if ((lemons * setOfCups) <=inventory.Lemons1)
                {
                    inventory.Lemons1 -= (lemons * setOfCups);
                    return lemons;
                }
                else
                {
                    lemons = AskForLemons(inventory, setOfCups);
                    return lemons;
                }

            }
        }
        void ShowCurrentWeather(Weather weather)
        {
            Console.Clear();
            Console.WriteLine("Current Weather: " + weather.WeatherForTheWeek[currentDay].Forecast);
            Console.WriteLine("Current Tempature: " +weather.WeatherForTheWeek[currentDay].Temperature);
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
            CurrentItems.RemainingMoney += CurrentItems.CollectedMoney;
            CurrentItems.StartingMoney = CurrentItems.RemainingMoney;
            Console.WriteLine("Is total Cash in Store: $" +(CurrentItems.RemainingMoney));
            Console.WriteLine("Is current profits based off Started with after Supplies where bought: $" +(CurrentItems.CollectedMoney- CurrentItems.StartingMoney));

        }

        public void CreateInventory()
        {
            buySupplies.BuyIce(CurrentItems);
            buySupplies.Buylemons(CurrentItems);
            buySupplies.BuySugar(CurrentItems);
        }
       public void DecreaseLife()
        {
           CurrentItems.Ice.SetDaysRemaining(CurrentItems.Ice.GetDaysRemaining() - 1);
            CurrentItems.Sugar.SetDaysRemaining(CurrentItems.Sugar.GetDaysRemaining() - 1);
            CurrentItems.Lemons.SetDaysRemaining(CurrentItems.Lemons.GetDaysRemaining() - 1);
            if (CurrentItems.Ice.GetDaysRemaining() <= 0)
            {
                CurrentItems.Ice1 -= buySupplies.PrevIce;
            }
            if (CurrentItems.Sugar.GetDaysRemaining() <= 0)
            {
                CurrentItems.Sugar1 -= buySupplies.PrevSugar;
            }
            if (CurrentItems.Lemons.GetDaysRemaining() <= 0)
            {
                CurrentItems.Lemons1 -= buySupplies.Prevlemons ;
            }

        }
    }
}
