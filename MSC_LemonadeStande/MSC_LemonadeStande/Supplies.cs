using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Supplies
    {
        int experationTime;
        double price;
     public   int GetDaysRemaining()
        {
            return experationTime;
        }
      public  void SetDaysRemaining(int value)
        {
             experationTime = value;
        }

        public void SetPrice(double value)
        {
            price = value;
        }
        public double GetPrice()
        {
            return price;
        }
    }
}
