//June 8th 2018
//Government class, used for constructing Government buildings, child class of Essential Services
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class Government : EssentialServices
    {
        /// <summary>
        /// Constructor for a government object, assigns corresponding variables
        /// </summary>
        public Government()
        {
            //Build cost is 500 000 000
            buildCost = 500000000;
            //mantenance cost is 100 000 000 
            maintenanceCost = 100000000;
            //Power cost is 10 units
            powerCost = 10;
            //Pollution output is 0 units
            pollutionOutput = 0;
            //Set the building name
            buildingName = "Government Building";
        }
    }
}
