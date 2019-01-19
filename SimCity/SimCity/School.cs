//June 8th 2018
//School class, used for constructing school buildings, child class of Essential Services
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class School : EssentialServices
    {
        /// <summary>
        /// Constructor for a school object, assigns corresponding variables
        /// </summary>
        public School()
        {
            //Build cost is 500 000 000 
            buildCost = 500000000;
            //mantenance cost is 5 000 000 
            maintenanceCost = 5000000;
            //Power cost is 15 units
            powerCost = 15;
            //Pollution output is 5 units
            pollutionOutput = 5;
            //Set the building name
            buildingName = "School";
        }
    }
}
