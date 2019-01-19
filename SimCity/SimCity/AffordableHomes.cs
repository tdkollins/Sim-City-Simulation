// June 12 2018
// The Affordable homes class, child class of Residential Facilities
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class AffordableHomes : Residential_Facilities
    {
        /// <summary>
        /// Constructor for an affordable home, assigns corresponding variables
        /// </summary>
        public AffordableHomes()
        {
            buildingName = "Affordable Home"; // The name of this building
            buildCost = 100000000; // Cost to build one affordable home         
            maintenanceCost = 5000000; // Cost to maintain one affordable home per month 
            powerCost = 25; // Cost of power to run one affordable home            
            pollutionOutput = 1000; // Amount of pollution created by one affordable home when the population is full            
            maximumPopulation = 25000; // The maximum population of one affordable home
            currentPopulation = 0; // The current population of one affordable home
            revenue = 0; // The amount of money engrossed through one affordable home
            revenuePerThousand = 10000; // per thousand people
            percentHappiness = 10; // The percentage of people that are happy in one affordable home 
        }     
    }
}
