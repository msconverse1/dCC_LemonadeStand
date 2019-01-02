using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Program
    {
        static void Main(string[] args)
        {
            Weather newday = new Weather();
            newday.CreateWeather(7);
            Console.ReadKey();
        }
    }
}
