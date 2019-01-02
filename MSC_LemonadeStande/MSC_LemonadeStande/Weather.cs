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

       public void CreateWeather(int numDays)
        {
            SetDay(new List<Day>());
            do
            {         
                WeatherForTheWeek.Add(new Day());
                WeatherForTheWeek[currentDay].CurrentWeather();
                WeatherForTheWeek[currentDay].SetInflation();
                if (currentDay <=numDays)
                {
                    currentDay++;
                }
            } while (currentDay <= 7);
            
        }
    }
}
