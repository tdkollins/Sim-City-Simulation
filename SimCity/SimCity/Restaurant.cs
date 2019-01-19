//June 11, 2018.
//Child class of Commercial parent class. Assigns corresponding variables for a commercial facility, Restaurant.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class Restaurant : Commercial
    {
        /// <summary>
        /// Constructor for a commertial facility, assigns correspoding variables.
        /// </summary>
        public Restaurant()
        {
            // Cost = 150, 000, 000
            buildCost = 150000000;
            // Cost = 500 000
            maintenanceCost = 500000;
            // Cost = 5
            powerCost = 5;
            // Output = 300
            pollutionOutput = 300;
            // 10 000 000/mon.
            revenue = 10000000;
            // Building name.
            buildingName = "Restaurant";
        }
    }
}
