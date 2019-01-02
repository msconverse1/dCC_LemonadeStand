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
        private int lemons;
       
        bool isFull;

        public int Ice { get => ice; set => ice = value; }
        public int Sugar { get => sugar; set => sugar = value; }
        public int Lemons { get => lemons; set => lemons = value; }

        public void CreateCup(int cubes,int spoon,int slices,bool status)
        {
            Ice = cubes;
            Sugar = spoon;
            Lemons = slices;
            isFull = status;
        }

    }
}
