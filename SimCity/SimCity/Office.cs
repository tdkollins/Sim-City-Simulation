// June 11, 2018.
// Child class of Commercial parent class. Assigns corresponding variables for a commercial facility, Office.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class Office : Commercial
    {
        /// <summary>
        /// Constructor for a commertial facility, assigns correspoding variables.
        /// </summary>
        public Office()
        {
            // Cost = 3 000 000
            buildCost = 3000000;
            // Cost = 500 000
            maintenanceCost = 500000;
            // Cost = 15
            powerCost = 15;
            // Output = 800
            pollutionOutput = 800;
            // 10 000 000/mon.
            revenue = 10000000;
            // Building name.
            buildingName = "Office";
        }
    }
}
