using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Sugar : Supplies
    {
        public Sugar()
        {
            SetPrice(1.5);
            SetDaysRemaining(22);
        }
    }
}
