﻿using System;
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
   public class main
    {
       public double temp { get; set; }
    }
   public class weather
    {
      public  string main { get; set; }
      public  string description { get; set; }
    }
   public class list
    {
        public double dt { get; set; }//days in millsecounds
      public  main main { get; set; }
        public List<weather> weather { get; set; } // weather list 
        city city { get; set; }
    }
}
