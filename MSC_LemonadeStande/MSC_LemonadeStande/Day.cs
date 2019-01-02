using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Day
    {
        string dayName;
       public string forecast;
       public double temperature;
       public double changePrice;
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
        //public void SetDayName(int passedday)
        //{
        //    if (passedday % 7 == 0)
        //    {
        //        passedday = 0;
        //    }
        //    switch (passedday)
        //    {
        //        case 0:
        //            dayName= "Sunday";
        //            break;
        //        case 1:
        //            dayName="Monday";
        //            break;
        //        case 2:
        //            dayName = "Tuesday";
        //            break;
        //        case 3:
        //            dayName = "Wednesday";
        //            break;
        //        case 4:
        //            dayName = "Thursday";
        //            break;
        //        case 5:
        //            dayName = "Friday";
        //            break;
        //        case 6:
        //            dayName = "Saturday";
        //            break;
        //        default:
        //            break;
        //    }
        //}
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
                    changePrice = sunnyFactor;
                    break;
                case "Cloudy":
                    changePrice = 1;
                    break;
                case "Rain":
                    changePrice = rainFactor;
                    break;
                default:
                    break;
            }
        }
    }
}
