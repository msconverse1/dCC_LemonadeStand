using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Player
    {
       public double WillingToPay;
       public double cashOnHand;
       public int Thirst;
        bool wantSugar;
        public bool GetWantSugar()
        {
            return wantSugar;
        }
        public void SetWantSugar(bool value)
        {
            wantSugar = value;
           
        }
        public Player()
        {
            Random cash = new Random();
            cashOnHand = cash.Next(10, 42);
            System.Threading.Thread.Sleep(35);
            WillingToPay = cash.Next(5, 15);
           
            Random water = new Random();
            Thirst = water.Next(0, 20);
            Random sugar = new Random();
            int check = sugar.Next(0, 10);
                 System.Threading.Thread.Sleep(20);
            if (check % 2==0)
            {
                wantSugar = false;
            }
            else
            {
                wantSugar = true;
            }
        }

    }
}
