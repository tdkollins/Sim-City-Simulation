//June 11, 2018.
//Child class of Commercial parent class. Assigns corresponding variables for a commercial facility, Store.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class Store : Commercial
    {
        /// <summary>
        /// Constructor for a commertial facility, assigns correspoding variables.
        /// </summary>
        public Store()
        {
            // Cost = 200 000 000
            buildCost = 200000000;
            // Cost = 100 000
            maintenanceCost = 100000;
            // Cost = 5
            powerCost = 5;
            // Output = 500
            pollutionOutput = 500;
            // 20 000 000/mon.
            revenue = 20000000;
            // Building name.
            buildingName = "Store";
        }
    }
}
