using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Game
    {
        public void StartGame()
        {
           // Console.WriteLine("How Many Days would you like to play");
           //int.TryParse( Console.ReadLine(),out int daysTPlay);
           // SetUpWeather(daysTPlay);
            Console.WriteLine("How Many Cups would you like to make");
            int.TryParse(Console.ReadLine(), out int numCups);
            CreateStore(numCups);
        }
        void SetUpWeather(int daysToPlay)
        {
            Weather newday = new Weather();
            newday.CreateWeather(daysToPlay);
        }
        void CreateStore(int numCups)
        {
            Store store = new Store();
  
                store.CreateSetNumCups(numCups);
            
           
            Console.ReadLine();
        }

    }
}
