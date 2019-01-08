using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class WeatherForcast
    {
           city city { get; set; }
        public  List<list> list { get; set; }// forcast list
    }
    class city
    {
        public string name { get; set; }
    }
   public class temp
    {
       public double day { get; set; }
    }
   public class weather
    {
      public  string main { get; set; }
      public  string description { get; set; }
    }
   public class list
    {
        public double dt { get; set; }//days in millsecounds
      public  temp temp { get; set; }
        public List<weather> weathers { get; set; } // weather list 
        city city { get; set; }
    }
}
