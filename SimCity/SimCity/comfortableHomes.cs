// June 12 2018
// The comfortable homes class, child class of Residential Facilities
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class comfortableHomes : Residential_Facilities
    {
        /// <summary>
        /// Constructor for a comfortable home, assigns corresponding variables
        /// </summary>
        public comfortableHomes()
        {        
            buildingName = "Comfortable Home"; // The name of this building
            buildCost = 5000000000; // Cost to build one comfortable home           
            maintenanceCost = 10000000; // Cost to maintain one comfortable home per month 
            powerCost = 50; // Cost of power to run one comfortable home            
            pollutionOutput = 2000; // Amount of pollution created by one comfortable home when the population is full            
            maximumPopulation = 15000; // The maximum population of one comfortable home
            currentPopulation = 0; // The current population of one comfortable home
            revenue = 0; // The amount of money engrossed through one comfortable home
            revenuePerThousand = 100000000; // per thousand people
            percentHappiness = 25; // The percentage of people that are happy in one comfortable home
        }
    }
}
