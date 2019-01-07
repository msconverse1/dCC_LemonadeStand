using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Weather
    {
        int currentDay;
        public List<Day> WeatherForTheWeek;
        public List<Day> GetDay()
        {
            return WeatherForTheWeek;
        }
        public void SetDay(List<Day> value)
        {
            WeatherForTheWeek = value;
        }

       public void CreateWeather(int numDays,Random random)
        {
            SetDay(new List<Day>());
            while (currentDay<numDays)
            {
                WeatherForTheWeek.Add(new Day());    
                WeatherForTheWeek[currentDay].CurrentWeather(random);
                WeatherForTheWeek[currentDay].SetInflation(random);
                    currentDay++;
            }
        }
        public void GetADaysWeather(int dayUserWants)
        {
            Console.Clear();
            Console.WriteLine("Current Day: "+dayUserWants);
            Console.WriteLine("Current Weather: " + WeatherForTheWeek[dayUserWants].GetForecast());
            Console.WriteLine("Current Tempature: " + WeatherForTheWeek[dayUserWants].GetTemperature());
        }
        
    }
}
