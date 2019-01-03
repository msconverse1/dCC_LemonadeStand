using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Cups 
    {
       int ice;
       int sugar;
       int lemons;
       double price;
       bool isFull;

        public int Ice { get => ice; set => ice = value; }
        public int Sugar { get => sugar; set => sugar = value; }
        public int Lemons { get => lemons; set => lemons = value; }
        public bool IsFull { get => isFull; set => isFull = value; }
        public double GetPrice()
        {
            return price;
        }

        public void SetPrice(double value)
        {
           price = value;
        }

        public void CreateCup(int cubes,int spoon,int slices,bool status)
        {
            Ice = cubes;
            Sugar = spoon;
            Lemons = slices;
            isFull = status;
        }

    }
}
