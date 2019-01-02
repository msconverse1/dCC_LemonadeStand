using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Day
    {
       public string forecast;
       public double temperature;
        double changePrice;
        private readonly double sunnyFactor = 1.5;
        private readonly double rainFactor = .5;
        public string GetForecast()
        {
            return forecast;
        }
        public double GetTemperature()
        {
            return temperature;
        }
        public  void CurrentWeather()
        {
            Random Temp = new Random();
            temperature = Temp.Next(70, 120);
            System.Threading.Thread.Sleep(500);
            Random int_forecast = new Random();
         
            switch (int_forecast.Next(1, 3))
            {
                case 1:
                    forecast = "Clear";
                    break;
                case 2:
                    forecast = "Cloudy";
                    break;
                case 3:
                    forecast = "Rain";
                    break;

                default:
                    break;
            }
        }
       public void SetInflation()
        {
            switch (forecast)
            {
                case "Clear":
                    changePrice = sunnyFactor * temperature;
                    break;
                case "Cloudy":
                    changePrice = temperature;
                    break;
                case "Rain":
                    changePrice = rainFactor * temperature;
                    break;
                default:
                    break;
            }
        }
    }
}
