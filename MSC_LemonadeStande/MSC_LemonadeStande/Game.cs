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
                    ShowCurrentWeather();
                    customer.IsPlayerThirsty();
                }
                ShowCurrentWeather();
                store.CalculateDaysPay();
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
            ShowCurrentWeather();
            store.CreateSetNumCups(newCal, currentDay);
            store.CupContains();
            store.Profits();
            Console.ReadLine();
        }
        void ShowCurrentWeather()
        {
            Console.Clear();
            Console.WriteLine("Current Day: " + currentDay);
            Console.WriteLine("Current Weather: " + newCal.WeatherForTheWeek[currentDay].Forecast);
            Console.WriteLine("Current Tempature: " + newCal.WeatherForTheWeek[currentDay].Temperature);
        }
        void ShowWeeksWeather()
        {
            Console.Clear();
            for (int i = 0; i < newCal.WeatherForTheWeek.Count(); i++)
            {
                Console.WriteLine("Day:" + i);
                Console.WriteLine("Current Weather: " + newCal.WeatherForTheWeek[i].Forecast);
                Console.WriteLine("Current Tempature: " + newCal.WeatherForTheWeek[i].Temperature+"\n");
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
