//June 8th 2018
//Enviromental Facility Class, child of the Enviromental Buildings Class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class EnviromentalFacility : Enviromental
    {
        /// <summary>
        /// Constructor for an enviromental facility object, assigns corresponding variables
        /// </summary>
        public EnviromentalFacility()
        {
            //Build cost is 10 000 000 000
            buildCost = 10000000000;
            //mantenance cost is 3000000 
            maintenanceCost = 3000000;
            //Power cost is 75 units
            powerCost = 75;
            //Pollution output is -10000 units
            pollutionOutput = -10000;
            //Set the building name
            buildingName = "Enviromental Facility";
        }
    }
}
