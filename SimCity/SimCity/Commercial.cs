//June 12, 2018.
//This class constructs Commercial facilities, Store, Office and Restaurant. 
//This is the child class of Building class.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class Commercial : Building
    {
        // Check where the player can build commertial facility
        // no accupied tile.
        public override bool[,] BuildCheck(Building[,] map)
        {
            //Array for available build locations
            bool[,] availableLocationC = new bool[map.GetLength(0), map.GetLength(1)];

            //Variable to define if there's a residential facility present
            bool residentialFacilitiesPresent = false;

            for (int row = 0; row < map.GetLength(0); row++)
            {
                // Loops throught the columns of the map.
                for (int column = 0; column < map.GetLength(1); column++)
                {
                    // if the lacation is not taken then the location is available.
                    if (map[column, row] == null)
                    {
                        // y axis for the commertil building. 
                        for (int yAxis = row - 6; yAxis <= row + 6; yAxis++)
                        {
                            // Calculates the direction on x axis.
                            int xAxisDirection = 6 - Math.Abs(row - yAxis);


                            //Loop for the x axis
                            for (int xAxis = column + xAxisDirection; xAxis >= column - xAxisDirection; xAxis--)
                            {
                                // x and y Axis can not be a be a negative number.
                                if (xAxis >= 0 && xAxis < map.GetLength(0) && yAxis >= 0 && yAxis < map.GetLength(1))
                                {
                                    //If there is a residential facility within 6 spaces
                                    if (map[xAxis, yAxis] is Residential_Facilities && Math.Abs(xAxis - column) <= 6 && Math.Abs(yAxis - row) <= 6)
                                    {
                                        residentialFacilitiesPresent = true;
                                    }
                                }
                            }
                        }

                        // defines there is a commercial facility.
                        if (residentialFacilitiesPresent == true && SimSpace.IsThereARoadAdjacent(map, column, row) == true)
                        {
                            //Set the build location to true
                            availableLocationC[column, row] = true;
                        }
                        //Set residentialfacilities present back to false
                        residentialFacilitiesPresent = false;
                    }
                }
            }
            return availableLocationC;
        }
    }
}
