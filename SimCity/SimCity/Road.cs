/// June 12th 2018
/// The Road class, 
/// used for constructing roads, 
/// child class of 'Building'
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class Road : Building
    {
        /// <summary>
        /// Constructor for a road, assigns corresponding variables
        /// </summary>
        public Road()
        {
            buildingName = "Road";
            buildCost = 0;
        }

        public override bool[,] BuildCheck(Building[,] map)
        {
            //Create a boolean array of map length and height to store where buildings can be built
            bool[,] availableBuildLocations = new bool[map.GetLength(0), map.GetLength(1)];

            //Scan the whole map for areas with no building on it, and set those areas to true
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    //If there is no building in the current location
                    if (map[row, col] == null)
                    {
                        //Flag it as true
                        availableBuildLocations[row, col] = true;
                    }
                }
            }

            //Return the availableBuildLocations
            return availableBuildLocations;
        }
    }
}
