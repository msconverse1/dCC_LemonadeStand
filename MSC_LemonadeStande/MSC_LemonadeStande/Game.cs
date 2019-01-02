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
        Inventory currentItems;
        int currentDay;
        public void StartGame()
        {
            Console.WriteLine("How Many Days would you like to play");
           int.TryParse( Console.ReadLine(),out int daysTPlay);
            SetUpWeather(daysTPlay);
            while (currentDay < daysTPlay)
            {
                CreateStore();
                CreateCustomers();
                currentDay++;
            }
        }
        void SetUpWeather(int daysToPlay)
        {
            newCal = new Weather();
            newCal.CreateWeather(daysToPlay);
        }
        void CreateStore()
        {
            store = new Store();
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
            Console.WriteLine("Current Weather: " + newCal.WeatherForTheWeek[currentDay].forecast);
            Console.WriteLine("Current Tempature: " + newCal.WeatherForTheWeek[currentDay].temperature);
        }
        void CreateInventory()
        {
            currentItems = new Inventory();
            ShowCurrentWeather();
            currentItems.BuyIce();
            currentItems.Buylemons();
            currentItems.BuySugar();
        }
        void CreateCustomers()
        {
            Player player = new Player();    
        }
    }
}
