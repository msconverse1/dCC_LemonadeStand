using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class WeeksWeather
    {
        static float tempature;
        static string forecast;
        public static string Forecast { get { return forecast; } set { forecast = value; } }
        public static float Tempature { get { return tempature; } set { tempature = value; } }
        
        public void CreateList(string forcast,float temp)
        {
            Tempature = temp;
            Forecast = forcast;
        }
    }
}
