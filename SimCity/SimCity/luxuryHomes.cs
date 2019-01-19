//June 12 2018
//The Luxury Homes class, child class of Residential Facilities
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class luxuryHomes : Residential_Facilities
    {
        /// <summary>
        /// Constructor for a luxury home, assigns corresponding variables
        /// </summary>
        public luxuryHomes()
        {
            buildingName = "Luxury Home"; // The name of this building
            buildCost = 100000000000; // Cost to build one luxury home          
            maintenanceCost = 1000000000; // Cost to maintain one luxury home per month 
            powerCost = 100; // Cost of power to run one luxury home            
            pollutionOutput = 5000; // Amount of pollution created by one luxury home when the population is full            
            maximumPopulation = 10000; // The maximum population of one luxury home
            currentPopulation = 0; // The current population of one luxury home
            revenue = 0; // The amount of money engrossed through one luxury home
            revenuePerThousand = 1500000000; // per thousand people
            percentHappiness = 50; // The percentage of people that are happy in one luxury home       
        }
        
    }
}
