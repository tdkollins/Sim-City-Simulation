//June 8th 2018
//Park class, used for constructing park buildings, child class of Enviromental
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class Park : Enviromental
    {
        /// <summary>
        /// Constructor for a park object, assigns corresponding variables
        /// </summary>
        public Park()
        {
            //Build cost is 50 000 000
            buildCost = 50000000;
            //mantenance cost is 10 000 000
            maintenanceCost = 10000000;
            //Power cost is 0 units
            powerCost = 0;
            //Pollution output is -1000 units
            pollutionOutput = -1000;
            //Set the building name
            buildingName = "Park";
        }
    }
}
