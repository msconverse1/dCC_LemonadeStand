using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Game
    {
        int currday;
        public void StartGame()
        {
            Console.WriteLine("How Many Days would you like to play");
           int.TryParse( Console.ReadLine(),out int daysTPlay);
            SetUpWeather(daysTPlay);
        }
        void SetUpWeather(int daysToPlay)
        {
            Weather newday = new Weather();
            newday.CreateWeather(daysToPlay);


           
            Console.ReadLine();
        }
    }
}
