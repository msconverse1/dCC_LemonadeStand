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
        CustomerInteraction customer;
        int currentDay;
        List<Player> PotinalCustomers;
        List<Store> TotalStores;
        readonly Random random;
        public Game()
        {
            newCal = new Weather();
            store = new Store();
            random = new Random(); 
        }
        public void StartGame()
        {
            GwAPI.GetWeather();
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
                DecreaseLife();
            }
        }
        void SetUpWeather(int daysToPlay)
        {
            newCal.CreateWeather(daysToPlay,random);
        }
        void CreateStore()
        {
            newCal.GetADaysWeather(currentDay);
            store.CreateInventory();
            
            store.CreateSetNumCups(newCal, currentDay);
            store.CupContains();
            store.Profits();
            Console.WriteLine("Press ant Key to cotinue..");
            Console.ReadLine();
        }
        void ShowCurrentWeather(int day)
        {     
            Console.WriteLine("Current Day: " + day);
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
                PotinalCustomers.Add(new Player(random));
            }
        }
        void CreateMultiplayer()
        {
            Console.WriteLine("Would you  like to play against another store?");
            string result = Console.ReadLine();
            if (result.ToLower() == "yes")
            {
                RunMultiplayer();
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
        void DecreaseLife()
        {
            foreach (var item in store.CurrentItems.Ice)
            {
                item.SetDaysRemaining(item.GetDaysRemaining() - 1);
            }
            foreach (var item in store.CurrentItems.Lemons)
            {
                item.SetDaysRemaining(item.GetDaysRemaining() - 1);
            }
            foreach (var item in store.CurrentItems.Sugar)
            {
                item.SetDaysRemaining(item.GetDaysRemaining() - 1);
            }
            for (int i = 0; i < store.CurrentItems.Ice.Count; i++)
            {
                if (store.CurrentItems.Ice[i].GetDaysRemaining() <=0)
                {
                    store.CurrentItems.Ice.Remove(store.CurrentItems.Ice[i]);
                }
            }
            for (int i = 0; i < store.CurrentItems.Lemons.Count; i++)
            {
                if (store.CurrentItems.Lemons[i].GetDaysRemaining() <= 0)
                {
                    store.CurrentItems.Lemons.Remove(store.CurrentItems.Lemons[i]);
                }
            }
            for (int i = 0; i < store.CurrentItems.Sugar.Count; i++)
            {
                if (store.CurrentItems.Sugar[i].GetDaysRemaining() <= 0)
                {
                    store.CurrentItems.Sugar.Remove(store.CurrentItems.Sugar[i]);
                }
            }

        }
    }
}
