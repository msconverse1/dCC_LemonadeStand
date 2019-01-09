using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Game
    {
        readonly Weather newCal;
        Store store;
        CustomerInteraction customer;
        int currentDay;
        List<Player> PotinalCustomers;
        static List<Store> TotalStores;
        readonly Random random;
        public Game()
        {
            newCal = new Weather();
            store = new Store();
            random = new Random();
            TotalStores = new List<Store>();
        }
        public void StartGame()
        {
             
           // Geolocation.GetGeoLocation();
            Console.WriteLine("How Many Days would you like to play");
            int.TryParse( Console.ReadLine(),out int daysTPlay);
            SetUpWeather(daysTPlay);
            Console.WriteLine("Do you wish to see the Weeks Weather?");
            if (Console.ReadLine().ToLower()=="yes")
            {
               
                ShowWeeksWeather(GwAPI.weeksWeathers);
                Console.WriteLine("Press ant Key to cotinue..");
                Console.ReadKey();
            }
            while (currentDay < daysTPlay)
            {
                CreateStore();
                CreateCustomers(currentDay);
                foreach (var item in PotinalCustomers)
                {
                    customer = new CustomerInteraction(item, store);
                    GwAPI.GetADaysWeather(currentDay);
                    //newCal.GetADaysWeather(currentDay);
                    customer.IsPlayerThirsty();
                    Console.WriteLine("Press ant Key to cotinue..");
                    Console.ReadLine();
                    if (store.prepedCups.Count ==0)
                    {
                        break;
                    }
                }
                GwAPI.GetADaysWeather(currentDay);
                //newCal.GetADaysWeather(currentDay);
                store.CalculateDaysPay();
                Console.WriteLine("Press Any Key to Start the next day..");
                Console.ReadLine();
                currentDay++;
                store.DecreaseLife();
            }
        }
        void SetUpWeather(int daysToPlay)
        {
            GwAPI.GetWeather(daysToPlay, random);
            //newCal.CreateWeather(daysToPlay,random);
        }
       
        void CreateStore()
        {
            GwAPI.GetADaysWeather(currentDay);
           // newCal.GetADaysWeather(currentDay);
            store.CreateInventory();
            
            store.CreateSetNumCups(currentDay);
            store.CupContains();
            store.Profits();
            Console.WriteLine("Press ant Key to cotinue..");
            Console.ReadLine();
        }
        void ShowCurrentWeather(int day)
        {     
            Console.WriteLine("Current Day: " + day);
            Console.WriteLine("Current Weather: " + GwAPI.weeksWeathers[day].Forecast);
            Console.WriteLine("Current Tempature: " + GwAPI.weeksWeathers[day].Temperature);
        }
        void ShowWeeksWeather(List<Day>test)
        {
            Console.Clear();
            for (int i = 0; i < test.Count(); i++)
            {
                ShowCurrentWeather(i);
            }
        }
        void CreateCustomers(int day)
        {
            PotinalCustomers = new List<Player>();
            
            for (int i = 0; i < GwAPI.weeksWeathers[day].ChangePeople; i++)
            {
                PotinalCustomers.Add(new Player(random));
            }
        }
       public void CreateMultiplayer()
        {
            Console.WriteLine("Would you  like to play against another store?");
            string result = Console.ReadLine();
            if (result.ToLower() == "yes")
            {
                RunMultiplayer();
            }
            else
            {
                StartGame();
            }

        }
        void RunMultiplayer()
        {

            for (int i = 0; i < 2; i++)
            {
                TotalStores.Add(new Store());
            }


            foreach (var ministore in TotalStores)
            {
                currentDay = 0;
                
                ministore.CurrentItems.RemainingMoney = 20;
                StartGame();

            }
            if (TotalStores[0].CurrentItems.CollectedMoney > TotalStores[1].CurrentItems.CollectedMoney)
            {
                Console.WriteLine("Store:1 collected more money than Store:2");
            }
            else if(TotalStores[0].CurrentItems.CollectedMoney < TotalStores[1].CurrentItems.CollectedMoney)
            {
                Console.WriteLine("Store:2 collected more money than Store:1");
            }
            else
            {
                Console.WriteLine("Store:1 Tied Store:2");
            }
        }
      
    }
}
