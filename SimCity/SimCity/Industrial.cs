//June 12, 2018.
//This class constructs Industrial facility called Factory. 
//This is the child class of Building class.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class Industrial : Building
    {
        /// <summary>
        /// Checks if the industrial faclity can be placed at a specific area. Checks to see is if the industrial facility is within the designated range of residential facilities.
        /// </summary>
        /// <param name="map">The grid.</param>
        /// <returns>availableLocationI</returns>
        public override bool[,] BuildCheck(Building[,] map)
        {
            // sets the available loacation for the industrial facility on the map(25 X 25).
            bool[,] availableLocationI = new bool[map.GetLength(0), map.GetLength(1)];

            // Sets the bool if that location is taken by a factory or resicential facility.
            bool powerPlantPresent = false;
            bool isThereResidentialFacilities = false;

            // Loops throught the rows of the map.
            for (int row = 0; row < map.GetLength(0); row++)
            {
                // Loops throught the columns of the map.
                for (int column = 0; column < map.GetLength(1); column++)
                {
                    // if the lacation is not taken then the location is available.
                    if (map[column, row] == null)
                    {
                        // y axis for the industrial building.
                        for (int yAxis = row - 6; yAxis <= row + 6; yAxis++)
                        {
                            // Calculates the direction on x axis.
                            int xAxisDirection = 6 - Math.Abs(row - yAxis);

                            //for (int xAxis = column + xAxisDirection; xAxis >= column - xAxisDirection; xAxis--)
                            for (int xAxis = column + xAxisDirection; xAxis >= column - xAxisDirection; xAxis--)
                            {
                                // x and y Axis can not be a be a negative number.
                                if (xAxis >= 0 && xAxis < map.GetLength(0) && yAxis >= 0 && yAxis < map.GetLength(1))
                                {
                                    // checks if there is a residential facility.
                                    if (map[xAxis, yAxis] is Residential_Facilities && Math.Abs(xAxis - column) <= 6 && Math.Abs(yAxis - row) <= 6)
                                    {
                                        // true, there is a recidential facility.
                                        isThereResidentialFacilities = true;
                                    }
                                    else if (map[xAxis, yAxis] is PowerPlant)
                                    {
                                        powerPlantPresent = true;
                                    }
                                }
                            }
                        }

                        // defines there is a industria facility.
                        if (powerPlantPresent == true && isThereResidentialFacilities == false && SimSpace.IsThereARoadAdjacent(map, column, row))
                        {
                            //Set the location to true
                            availableLocationI[column, row] = true;
                        }
                        powerPlantPresent = false;
                        isThereResidentialFacilities = false;
                    }
                }
            }

            // returns the location of the industirial facility.
            return availableLocationI;
        }
    }
}
