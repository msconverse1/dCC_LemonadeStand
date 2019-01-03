using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    
    class CustomerInteraction
    {
        Store Store;
        Player Player;
        Inventory Inventory;

        public CustomerInteraction(Player player, Store store)
        {
            Store = store;
            Player = player;
            Inventory = Store.CurrentItems;
        }
       public void IsPlayerThirsty()
        {
                Store.CupContains();
            foreach (var item in Store.prepedCups)
            {
                if (Player.GetWantSugar())
                {
                    if (item.Sugar >=1)
                    {
                        PlayerBuysCup(item);
                        if (Player.Thirst > 10)
                        {
                            Console.WriteLine("I don't want to buy!");
                            break;
                        }
                    }
                }
                else if (!Player.GetWantSugar())
                {
                    if (item.Sugar < 1)
                    {
                        PlayerBuysCup(item);
                        if (Player.Thirst > 10)
                        {
                            Console.WriteLine("I don't want to buy!");
                            break;
                        }
                    }
                }
            }
        }
        void PlayerBuysCup(Cups item)
        {
            while (Player.Thirst < 10)
            {
                if (item.GetPrice() < Player.cashOnHand)
                {
                   Console.WriteLine("I would like to Buy");
                   Player.Thirst += 2;
                   Player.cashOnHand -= item.GetPrice();
                   Inventory.CollectedMoney += item.GetPrice();
                   item.IsFull = false;
                   break;
                }
                else
                {
                    Console.WriteLine("I don't want to buy!");
                    break;
                }
            }
        }

    }

}
