﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MSC_LemonadeStande
{
     static class GwAPI
    {
        const string APPID = "b12d7daaddc0081351361cc2c38e4f1e";
        const string location = "Milwaukee";
        static float tempature;
        static string forecast;
      public static List<WeeksWeather> weeksWeathers;

        public static string Forecast { get { return forecast; } set { forecast = value; } }
        public static float Tempature { get { return tempature; } set { tempature = value; } }
        static void SetWeather(List<WeeksWeather> value)
        {
            weeksWeathers = value;
        }
        public static void GetWeather(int day)
        {

            //current time 
          //  CurrentTimeWeather();
            //5day ForeCast
            getForcast(day);
        }
        static void CurrentTimeWeather()
        {
            using (WebClient web = new WebClient())
            {
                
                string url = $"http://api.openweathermap.org/data/2.5/weather?q={location}" +
                                 $"&mode=json&units=metric&APPID={APPID}";

                var json = web.DownloadString(url);
                var result = JsonConvert.DeserializeObject<GwAPI.Root>(json);
                Root output = result;
                Forecast = output.Weather[0].main;
                
                Tempature = ConvertCToF(output.main.temp);
            }
        }
      static void getForcast(int day)
        {
            string url = $"http://api.openweathermap.org/data/2.5/forecast?q={location}" +
                             $"&mode=json&units=metric&APPID={APPID}";
            using (WebClient web = new WebClient())
            {
                var json = web.DownloadString(url);
                var Object = JsonConvert.DeserializeObject<WeatherForcast>(json);
                WeatherForcast forcast = Object;
                SetWeather(new List<WeeksWeather>());
                for (int i = 0; i < day; i++)
                {
                    weeksWeathers.Add(new WeeksWeather());
                    if (i<5)
                    {
                        weeksWeathers[i].CreateList(forcast.list[i].weathers[0].main, ConvertCToF(forcast.list[i].temp.day));
                    }
                    if (i >=5)
                    {
                        weeksWeathers[i].CreateList(forcast.list[1].weathers[0].main, ConvertCToF(forcast.list[1].temp.day));
                    }
                }
            }
        }
  
        //Methods for Parsing the JSON 
       // RM(datatypes name must match the JSON datatype name)
        public  class weather
        {
           public  string main { get; set; }
           public  string description { get; set; }
        }//parse the Json object an return 
        public  class main
        {
            public double temp { get; set; }
            
        }// parse Json object to the main then capture the tempature. RM(datatypes name must match the JSON datatype name)
     
        public  class Root
        {
            public  List<weather> Weather { get; set; }
            public  main main { get; set; } 
        }
        static float ConvertCToF(double C)
        {
            C = (C* 1.8)+32; 
            return (float)C ;
        }
    }
}
