using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace MSC_LemonadeStande
{
     static class GwAPI
    {
        const string APPID = "b12d7daaddc0081351361cc2c38e4f1e";
        const string location = "Milwaukee";
        static float tempature;
        static string forecast;
        public static string Forecast { get { return forecast; } set { forecast = value; } }
        public static float Tempature { get { return tempature; } set { tempature = value; } }
      
        public static void GetWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = $"http://api.openweathermap.org/data/2.5/weather?q={location}" +
    $"&mode=json&units=metric&APPID={APPID}";

                var json = web.DownloadString(url);
               var result = JsonConvert.DeserializeObject<GwAPI.Root>(json);
                Root output = result;
             Forecast=   output.Weather[0].main;
                double i=output.main.temp;
            Tempature =ConvertCToF(output.main.temp);
            }
        }
        public  class weather
        {
           public  string main { get; set; }
           public  string description { get; set; }
        }
        public  class main
        {
            public double temp { get; set; }
            
        }
     
        public  class Root
        {
            public  List<weather> Weather { get; set; }
            public  main main { get; set; }
           
        }
        static float ConvertCToF(double C)
        {
            C *= 1.8;
            return (float)C+32 ;
        }
    }
    

}
