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
        public Player(Random random)
        {
            cashOnHand = random.Next(10, 42);
            WillingToPay = random.Next(5, 15);
            Thirst = random.Next(0, 20);
            int check = random.Next(0, 10);
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
