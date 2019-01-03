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
        readonly Player player;
        CustomerInteraction customer;
        int currentDay;
        public Game()
        {
            newCal = new Weather();
            store = new Store();
            currentItems = new Inventory();
            player = new Player();
            customer = new CustomerInteraction(player, store, currentItems);
        }
        public void StartGame()
        {
            Console.WriteLine("How Many Days would you like to play");
           int.TryParse( Console.ReadLine(),out int daysTPlay);
            SetUpWeather(daysTPlay);
            while (currentDay < daysTPlay)
            {
                CreateStore();
                customer.IsPlayerThirsty();
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
            Console.WriteLine("Current Weather: " + newCal.WeatherForTheWeek[currentDay].Forecast);
            Console.WriteLine("Current Tempature: " + newCal.WeatherForTheWeek[currentDay].Temperature);
        }
        void CreateInventory()
        {
            ShowCurrentWeather();

            store.buySupplies.BuyIce(currentItems);
            store.buySupplies.Buylemons(currentItems);
            store.buySupplies.BuySugar(currentItems);
        }
    }
}
