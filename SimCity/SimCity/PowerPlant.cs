//June 8th 2018
//Power Plant class, used for constructing power plant buildings, child class of Essential Services
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class PowerPlant : EssentialServices
    {
        /// <summary>
        /// Constructor for a power plant object, assigns corresponding variables
        /// </summary>
        public PowerPlant()
        {
            //Build cost is 500 000 000
            buildCost = 500000000;
            //mantenance cost is 100 000 000 
            maintenanceCost = 100000000;
            //Power cost is 100 units
            powerCost = -100;
            //Pollution output is 100 units
            pollutionOutput = 100;
            //Set the building name
            buildingName = "Power Plant";
        }
    }
}
