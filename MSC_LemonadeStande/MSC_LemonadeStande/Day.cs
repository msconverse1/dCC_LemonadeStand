using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Day
    {
        private string forecast;
        private float temperature;
        private double changePrice;
        private double changePeople;
        private readonly double sunnyFactor = 1.5;
        private readonly double rainFactor = .5;
        private readonly double snowFactor = .2;
        public string Forecast { get => forecast; set => forecast = value; }
        public float Temperature { get => temperature; set => temperature = value; }
        public double ChangePrice { get => changePrice; set => changePrice = value; }
        public double ChangePeople { get => changePeople; set => changePeople = value; }
        public void CreateList(string forcast, float temp)
        {
           Temperature = temp;
           Forecast = forcast;
        }
        public string GetForecast()
        {
            return forecast;
        }
        public double GetTemperature()
        {
            return temperature;
        }

        public  void CurrentWeather(Random Temp)
        { 
            temperature = Temp.Next(70, 120);
            int type = Temp.Next(1, 3);
            switch (type)
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
       public void SetInflation(Random Temp)
        {
            changePeople = Temp.Next(10, 30);    
            switch (forecast)
            {
                case "Clear":
                    changePrice = sunnyFactor;
                    changePeople *= 2;
                    break;
                case "Cloudy":
                    changePrice = 1;
                    changePeople *= 1;
                    break;
                case "Rain":
                    changePrice = rainFactor;
                    changePeople *= 0.25;
                    break;
                case "Snow":
                    changePrice = snowFactor;
                    changePeople *= .05;
                    break;
                default:
                    break;
            }
        }
    }
}
