// June 8th 2018
// Medical class, used for constructing Medical buildings, child class of Essential Services
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class Medical : EssentialServices
    {
        /// <summary>
        /// Constructor for a medical object, assigns corresponding variables
        /// </summary>
        public Medical()
        {
            //Build cost is 1 000 000 000
            buildCost = 1000000000;
            //mantenance cost is 15 000 000
            maintenanceCost = 15000000;
            //Power cost is 20 units
            powerCost = 20;
            //Pollution output is 20 units
            pollutionOutput = 20;
            //Set the building name
            buildingName = "Medical Building";
        }
    }
}
