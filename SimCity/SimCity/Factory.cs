//June 11, 2018.
//Child class of Industrial parent class. Assigns corresponding variables for aN industrial facilitY.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class Factory : Industrial 
    {
        /// <summary>
        /// Constructor for a industrial facility, assigns correspoding variables.
        /// </summary>
        public Factory()
        {
            // Cost = 1 000 000 000
            buildCost = 1000000000;
            // Cost = 500 000
            maintenanceCost = 500000;
            // Cost = 50
            powerCost = 50;
            // Output = 20 000
            pollutionOutput = 20000;
            // 50 000 000/mon.
            revenue = 50000000;
            // Building name.
            buildingName = "Factory";
        }
    }
}
