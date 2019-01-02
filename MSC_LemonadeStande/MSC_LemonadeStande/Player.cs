using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Player
    {
        double WillingToPay;
        double cashOnHand;
        int Thirst;
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
            System.Threading.Thread.Sleep(500);
            WillingToPay = cash.Next(10, 42);
            System.Threading.Thread.Sleep(50);
            Random water = new Random();
            Thirst = water.Next(0, 20);
        }

    }
}
