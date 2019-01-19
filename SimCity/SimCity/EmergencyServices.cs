// June 8th 2018
// Emergency Services class, child class of Essential Services
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class EmergencyServices : EssentialServices
    {
        /// <summary>
        /// Constructor for an Emergency Services object, assigns corresponding variables
        /// </summary>
        public EmergencyServices()
        {
            //Build cost is 100 000 000 
            buildCost = 100000000;
            //mantenance cost is 50000
            maintenanceCost = 50000;
            //Power cost is 5 units
            powerCost = 5;
            //Pollution output is 10 units
            pollutionOutput = 10;
            //Set the building name
            buildingName = "Emergency Service Building";
        }
    }
}
