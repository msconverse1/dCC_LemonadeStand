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
        readonly Inventory currentItems;
        readonly Player player;
        CustomerInteraction customer;
        int currentDay;
        List<Player> PotinalCustomers;
        public Game()
        {
            newCal = new Weather();
            store = new Store();
            currentItems = new Inventory();
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
                    customer = new CustomerInteraction(item, store, currentItems);
                    ShowCurrentWeather();
                    customer.IsPlayerThirsty();
                }
                ShowCurrentWeather();
                store.CalculateDaysPay(currentItems);
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
            CreateInventory();
            ShowCurrentWeather();
            store.CreateSetNumCups(currentItems,newCal, currentDay);
            store.CupContains();
            store.Profits(currentItems);
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
        void CreateInventory()
        {
            ShowCurrentWeather();

            store.buySupplies.BuyIce(currentItems);
            store.buySupplies.Buylemons(currentItems);
            store.buySupplies.BuySugar(currentItems);
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
