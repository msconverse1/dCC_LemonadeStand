using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Game
    {
        Weather newCal;
        Store store;
        readonly Player player;
        CustomerInteraction customer;
        int currentDay;
        List<Player> PotinalCustomers;
        List<Store> TotalStores;
        public Game()
        {
            newCal = new Weather();
            store = new Store();
            player = new Player();      
        }
        public void StartGame()
        {
            Console.WriteLine("How Many Days would you like to play");
            int.TryParse( Console.ReadLine(),out int daysTPlay);
            SetUpWeather(daysTPlay);
            Console.WriteLine("Do you wish to see the Weeks Weather?");
            if (Console.ReadLine().ToLower()=="yes")
            {
                ShowWeeksWeather();
                Console.WriteLine("Press ant Key to cotinue..");
                Console.ReadKey();
            }
            while (currentDay < daysTPlay)
            {
                CreateStore();
                CreateCustomers(currentDay);
                foreach (var item in PotinalCustomers)
                {
                    customer = new CustomerInteraction(item, store);
                    newCal.GetADaysWeather(currentDay);
                    
                    customer.IsPlayerThirsty();
                    Console.WriteLine("Press ant Key to cotinue..");
                    Console.ReadLine();
                }
                newCal.GetADaysWeather(currentDay);
                store.CalculateDaysPay();
                Console.WriteLine("Press Any Key to Start the next day..");
                Console.ReadLine();
                currentDay++;
                store.CurrentItems.Ice.SetDaysRemaining(  store.CurrentItems.Ice.GetDaysRemaining()-1);
                store.CurrentItems.Lemons.SetDaysRemaining(store.CurrentItems.Lemons.GetDaysRemaining() - 1);
                store.CurrentItems.Sugar.SetDaysRemaining(store.CurrentItems.Sugar.GetDaysRemaining() - 1);
            }
        }
        void SetUpWeather(int daysToPlay)
        {
            newCal.CreateWeather(daysToPlay);
        }
        void CreateStore()
        {
            newCal.GetADaysWeather(currentDay);
            store.CreateInventory();
            
            store.CreateSetNumCups(newCal, currentDay);
            store.CupContains();
            store.Profits();
            Console.ReadLine();
        }
        void ShowCurrentWeather(int day)
        {     
            Console.WriteLine("Current Day: " + currentDay);
            Console.WriteLine("Current Weather: " + newCal.WeatherForTheWeek[day].Forecast);
            Console.WriteLine("Current Tempature: " + newCal.WeatherForTheWeek[day].Temperature);
        }
        void ShowWeeksWeather()
        {
            Console.Clear();
            for (int i = 0; i < newCal.WeatherForTheWeek.Count(); i++)
            {
                ShowCurrentWeather(i);
            }
        }
        void CreateCustomers(int day)
        {
            PotinalCustomers = new List<Player>();
            for (int i = 0; i < newCal.WeatherForTheWeek[day].ChangePeople; i++)
            {
                PotinalCustomers.Add(new Player());
            }
        }
        string CreateMultiplayer()
        {
            Console.WriteLine("Would you  like to play against another store?");
            string result = Console.ReadLine();
            if (result.ToLower() == "yes" || result.ToLower() == "no" )
            {
                return result;
            }
            else
            {
              return  result= CreateMultiplayer();
            }
        }
        void RunMultiplayer()
        {
            Store store2 = new Store();
            TotalStores.Add(store);
            TotalStores.Add(store2);

            foreach (var ministore in TotalStores)
            {
                StartGame();
            }
        }
    }
}
