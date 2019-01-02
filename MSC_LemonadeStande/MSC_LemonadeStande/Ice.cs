using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Ice : Supplies
    {
        public Ice()
        {
            SetPrice(0.75);
            SetDaysRemaining(3);
            
        }
    }
}
