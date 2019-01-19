/// June 12, 2018
/// Parent class of all residential facilities, 
/// child class of Building
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class Residential_Facilities : Building
    {
        /// <summary>
        /// Obtain the total happiness
        /// </summary>
        /// <param name="map"></param>
        /// <returns>the total happiness</returns>
        public int GetTotalHappiness(Building[,] map)
        {
            double totalHappiness = 0;
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int column = 0; column < map.GetLength(1); column++)
                {
                    if (map[row, column] is Residential_Facilities)
                    {
                        double multiplyBy = ((map[row, column].GetPercentHappiness) / 100.0);
                        totalHappiness = totalHappiness + (map[row, column].CurrentPopulation * multiplyBy);
                    }
                }
            }
            return (int)totalHappiness; 
        }
           
        /// <summary>
        /// Obtain the total population across all residential facilities
        /// </summary>
        /// <param name="map"></param>
        /// <returns>the total population</returns>
        public int GetTotalPopulation(Building[,] map)
        {
            int totalPopulation = 0;
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int column = 0; column < map.GetLength(1); column++)
                {
                    if (map[row, column] is Residential_Facilities)
                    {
                        totalPopulation = totalPopulation + map[row, column].CurrentPopulation;
                    }
                }
            }

            return totalPopulation;
        }

        /// <summary>
        /// Increase the population
        /// </summary>
        /// <param name="map"></param>
        /// <returns>new map</returns>
        public Building[,] IncreasePopulation(Building[,] map)
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int column = 0; column < map.GetLength(1); column++)
                {
                    if (map[row, column] is Residential_Facilities)
                    {
                        map[row,column].CurrentPopulation = map[row,column].CurrentPopulation + (map[row,column].GetMaximumPopulation / 10);

                        if (currentPopulation > maximumPopulation)
                        {
                            map[row, column].CurrentPopulation = maximumPopulation;
                        }

                        map[row, column].HappyPopulation = map[row, column].CurrentPopulation * (100 / map[row, column].GetPercentHappiness);
                        map[row,column].Revenue = map[row, column].CurrentPopulation / 1000 * map[row, column].GetRevenuePerThousand;
                    }
                }
            }
            return map;
        }

        /// <summary>
        /// Check if tile is available for building a Residential Facility, must be within 8 tile range of all 5 different essential services, and 6 tiles away from industrial facilities
        /// </summary>
        /// <param name="map"></param>
        /// <returns>available tile</returns>
        public override bool[,] BuildCheck(Building[,] map)
        {
            bool[,] availableTile = new bool[map.GetLength(0), map.GetLength(1)];

            bool isThereSchool = false;
            bool isThereMedical = false;
            bool isThereGovernment = false;
            bool isThereIndustrial = false;
            bool isTherePowerPlant = false;
            bool isThereEmergencyServices = false;

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int column = 0; column < map.GetLength(1); column++)
                {
                    if (map[column, row] == null)
                    {
                        for (int y = row - 8; y <= row + 8; y++)
                        {

                            int xdistance = 8 - Math.Abs(row - y);

                            for (int x = column + xdistance; x >= column - xdistance; x--)
                            {
                                if (x >= 0 && x < map.GetLength(0) && y >= 0 && y < map.GetLength(1))
                                {
                                    if (map[x, y] is School)
                                    {
                                        isThereSchool = true;
                                    }
                                    else if (map[x, y] is Medical)
                                    {
                                        isThereMedical = true;
                                    }
                                    else if (map[x, y] is PowerPlant)
                                    {
                                        isTherePowerPlant = true;
                                    }
                                    else if (map[x, y] is Government)
                                    {
                                        isThereGovernment = true;
                                    }
                                    else if (map[x, y] is EmergencyServices)
                                    {
                                        isThereEmergencyServices = true;
                                    }
                                    else if (map[x, y] is Industrial && Math.Abs(x - column) <= 6 && Math.Abs(y - row) <= 6)
                                    {
                                        isThereIndustrial = true;
                                    }
                                }
                            }
                        }
                        
                        if (isThereSchool == true && isThereMedical == true && isThereGovernment == true && isTherePowerPlant == true && isThereEmergencyServices == true && isThereIndustrial == false && SimSpace.IsThereARoadAdjacent(map, column, row) == true)
                        {
                            availableTile[column, row] = true;
                        }

                        isThereSchool = false;
                        isThereMedical = false;
                        isThereGovernment = false;
                        isTherePowerPlant = false;
                        isThereIndustrial = false;
                        isThereEmergencyServices = false;
                    }
                }
            }
            return availableTile;
        }

        /// <summary>
        /// Construct a comfortable home
        /// </summary>
        /// <param name="map"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="money"></param>
        /// <returns>new map</returns>
        public Building[,] BuildComfortableHome(Building[,] map, int x, int y, long money)
        {
            Building comfortableHome = new comfortableHomes();
            if (money < comfortableHome.BuildCost)
            {
                return map;
            }

            map[x, y] = comfortableHome;
            return map;
        }

        /// <summary>
        /// Construct an affordable home
        /// </summary>
        /// <param name="map"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="money"></param>
        /// <returns>new map</returns>
        public Building[,] BuildAffordableHome(Building[,] map, int x, int y, long money)
        {
            Building affordableHome = new AffordableHomes();
            if (money < affordableHome.BuildCost)
            {
                return map;
            }

            map[x, y] = affordableHome;
            return map;
        }

        /// <summary>
        /// Construct a luxury home
        /// </summary>
        /// <param name="map"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="money"></param>
        /// <returns>new map</returns>
        public Building[,] BuildLuxuryHome(Building[,] map, int x, int y, long money)
        {
            Building luxuryHome = new luxuryHomes();
            if (money < luxuryHome.BuildCost)
            {
                return map;
            }

            map[x, y] = luxuryHome;
            return map;
        }
 
    }
}
