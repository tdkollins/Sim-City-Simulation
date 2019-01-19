//June 8 2018
//Build class, parent class of the facility and road classes.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    abstract class Building
    {
        //Variables and subprograms used throughout the building child classes.
        protected long buildCost;
        public long BuildCost
        {
            get { return buildCost; }
        }

        protected long maintenanceCost;
        public long MaintenanceCost
        {
            get { return maintenanceCost; }
        }

        protected int powerCost;
        public int PowerCost
        {
            get { return powerCost; }
        }

        protected int pollutionOutput;
        public int PollutionOutput
        {
            get { return pollutionOutput; }
        }

        protected long revenue;
        public long Revenue
        {
            get { return revenue; }
            set
            {
                if (this is Residential_Facilities)
                {
                    revenue = value;
                }
            }
        }

        protected string buildingName;
        public string BuildingName
        {
            get { return buildingName; }
        }

        protected int happyPopulation;
        public int HappyPopulation
        {
            get { return happyPopulation; }
            set
            {
                if (this is Residential_Facilities)
                {
                    happyPopulation = value;
                }
            }
        }

        /// <summary>
        /// Virtual subprogram to check the map onto where the player can build
        /// </summary>
        /// <param name="map">the current state of the map</param>
        /// <returns>a boolean array reflecting where the player</returns>
        public virtual bool[,] BuildCheck(Building[,] map)
        {
            //Create a boolean array of map length and height to store where buildings can be built
            bool[,] availableBuildLocations = new bool[map.GetLength(0), map.GetLength(1)];

            //Scan the whole map for areas with no building on it, and set those areas to true
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    //If there is no building in the current location and there is a road beside the current location
                    if (map[row, col] == null && SimSpace.IsThereARoadAdjacent(map, row, col) == true)
                    {
                        //Flag it as true
                        availableBuildLocations[row, col] = true;
                    }
                }
            }

            //Return the availableBuildLocations
            return availableBuildLocations;
        }

        /// <summary>
        /// Initialize the current population
        /// </summary>
        protected int currentPopulation;

        /// <summary>
        /// Get the current population
        /// </summary>
        public int CurrentPopulation
        {
            get { return currentPopulation; }
            set
            {
                if (this is Residential_Facilities)
                {
                    currentPopulation = value;
                }
            }
        }

        /// <summary>
        /// Initialize the maximum population variable
        /// </summary>
        protected int maximumPopulation;

        /// <summary>
        /// Get the maximum population
        /// </summary>
        public int GetMaximumPopulation
        {
            get { return maximumPopulation; }
        }

        /// <summary>
        /// Initialize revenue per thousand variable
        /// </summary>
        protected long revenuePerThousand;

        /// <summary>
        /// Get the revenue per thousand
        /// </summary>
        public long GetRevenuePerThousand
        {
            get { return revenuePerThousand; }
        }

        /// <summary>
        /// Initialize the percentage of people who are happy
        /// </summary>
        protected int percentHappiness;

        /// <summary>
        /// Get the percentage of people who are happy
        /// </summary>
        public int GetPercentHappiness
        {
            get { return percentHappiness; }
            set
            {
                if (this is Residential_Facilities)
                {
                    percentHappiness = value;
                }
            }
        }
    }
}
