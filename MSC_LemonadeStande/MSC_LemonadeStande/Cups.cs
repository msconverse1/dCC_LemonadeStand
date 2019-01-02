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
       
        bool isFull;
       public void CreateCup(int cubes,int spoon,int slices,bool status)
        {
            ice = cubes;
            sugar = spoon;
            lemons = slices;
            isFull = status;
        }

    }
}
