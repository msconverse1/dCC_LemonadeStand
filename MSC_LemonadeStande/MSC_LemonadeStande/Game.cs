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
        int currentDay;
        public void StartGame()
        {
            Console.WriteLine("How Many Days would you like to play");
           int.TryParse( Console.ReadLine(),out int daysTPlay);
            SetUpWeather(daysTPlay);
            while (currentDay < daysTPlay)
            {
                CreateStore();
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
            Store store = new Store();
            Inventory currentItems = new Inventory();
            ShowCurrentWeather();
            currentItems.BuyIce();
            currentItems.Buylemons();
            currentItems.BuySugar();
            ShowCurrentWeather();
           
            store.CreateSetNumCups(currentItems);
            Console.WriteLine("ice total: " + currentItems.ice);
            Console.ReadLine();
        }
        void ShowCurrentWeather()
        {
            Console.Clear();
            Console.WriteLine("Current Weather: " + newCal.WeatherForTheWeek[currentDay].forecast);
            Console.WriteLine("Current Tempature: " + newCal.WeatherForTheWeek[currentDay].temperature);
        }

    }
}
