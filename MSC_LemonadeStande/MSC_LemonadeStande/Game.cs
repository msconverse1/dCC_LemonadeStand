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
                }
                newCal.GetADaysWeather(currentDay);
                store.CalculateDaysPay();
                Console.WriteLine("Press Any Key to Start the next day..");
                Console.ReadLine();
                currentDay++;
            }
        }
        void SetUpWeather(int daysToPlay)
        {
            newCal.CreateWeather(daysToPlay);
        }
        void CreateStore()
        {
            store.CreateInventory();
            newCal.GetADaysWeather(currentDay);
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
    }
}
