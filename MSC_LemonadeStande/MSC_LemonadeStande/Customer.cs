using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    
    class Customer
    {
        Store Store;
        Player Player;

        public Customer(Player player, Store store)
        {
            Store = store;
            Player = player;
        }
        void IsPlayerThirsty()
        {
            
            if (Player.Thirst <10)
            {
                Store.CupContains();   

            }
        }
        

    }

}
