using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class SimSpace
    {
        //Variables for the simspace, and get Properties
        private int population;
        public int Population
        {
            get { return population; }
        }

        private long money = 5000000000;
        public long Money
        {
            get { return money; }
        }

        private int month = 0;
        public int Month
        {
            get { return month; }
        }

        private int pollution = 0;
        public int Pollution
        {
            get { return pollution; }
        }

        private int power;
        public int Power
        {
            get { return power; }
        }

        private int score = 0;
        public int Score
        {
            get { return score; }
        }

        private long revenue;
        public long Revenue
        {
            get { return revenue; }
        }

        private long maintenanceCosts;
        public long MaintenanceCosts
        {
            get { return maintenanceCosts; }
        }

        private int happyPopulation;
        public int HappyPopulation
        {
            get { return happyPopulation; }
        }

        //Sim space objects to utilize each of the methods for respective sim spaces
        SimSpaceTrevor simSpaceTrevor = new SimSpaceTrevor();

        //Random events object
        RandomEvents randomEvents = new RandomEvents();


        /// <summary>
        /// Checks where the player can build enviromental facilities
        /// </summary>
        /// <param name="map">the current map</param>
        /// <returns>a boolean array of where the player can place enviromental facilities</returns>
        public bool[,] BuildCheckCommercial(Building[,] map)
        {
            return simSpaceTrevor.CommercialCheck(map);
        }

        /// <summary>
        /// Constructs the building
        /// </summary>
        /// <param name="map">the current map</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        /// <returns>the new map (will not add the building if the player does not have enough money)</returns>
        public Building[,] BuildRestaurant(Building[,] map, int x, int y)
        {
            //Run the subprogram in the Maria sim space model
            map = simSpaceTrevor.RestaurantBuilding(map, x, y, money);

            //If the building was sucsessfully built (the location is not null)
            if (map[x, y] != null)
            {
                //Subtract the build cost from the player's pool of money 
                SubtractBuildCost(map[x, y].BuildCost);
            }

            //Calculate Stats
            CalculateStats(map);

            //Return the map
            return map;
        }

        /// <summary>
        /// Constructs the building
        /// </summary>
        /// <param name="map">the current map</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        /// <returns>the new map (will not add the building if the player does not have enough money)</returns>
        public Building[,] BuildStore(Building[,] map, int x, int y)
        {
            //Run the subprogram in the Maria sim space model
            map = simSpaceTrevor.StoreBuilding(map, x, y, money);

            //If the building was sucsessfully built (the location is not null)
            if (map[x, y] != null)
            {
                //Subtract the build cost from the player's pool of money 
                SubtractBuildCost(map[x, y].BuildCost);
            }

            //Calculate Stats
            CalculateStats(map);

            //Return the map
            return map;
        }

        /// <summary>
        /// Constructs the building
        /// </summary>
        /// <param name="map">the current map</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        /// <returns>the new map (will not add the building if the player does not have enough money)</returns>
        public Building[,] BuildOffice(Building[,] map, int x, int y)
        {
            //Run the subprogram in the Maria sim space model
            map = simSpaceTrevor.OfficeBuilding(map, x, y, money);

            //If the building was sucsessfully built (the location is not null)
            if (map[x, y] != null)
            {
                //Subtract the build cost from the player's pool of money 
                SubtractBuildCost(map[x, y].BuildCost);
            }

            //Calculate Stats
            CalculateStats(map);

            //Return the map
            return map;
        }

        /// <summary>
        /// Checks where the player can build enviromental facilities
        /// </summary>
        /// <param name="map">the current map</param>
        /// <returns>a boolean array of where the player can place enviromental facilities</returns>
        public bool[,] BuildCheckIndustrial(Building[,] map)
        {
            return simSpaceTrevor.IndustrialCheck(map);
        }

        /// <summary>
        /// Constructs the building
        /// </summary>
        /// <param name="map">the current map</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        /// <returns>the new map (will not add the building if the player does not have enough money)</returns>
        public Building[,] BuildFactory(Building[,] map, int x, int y)
        {
            //Run the subprogram in the Maria sim space model
            map = simSpaceTrevor.FactoryBuilding(map, x, y, money);

            //If the building was sucsessfully built (the location is not null)
            if (map[x, y] != null)
            {
                //Subtract the build cost from the player's pool of money 
                SubtractBuildCost(map[x, y].BuildCost);
            }

            //Calculate Stats
            CalculateStats(map);

            //Return the map
            return map;
        }

        /// <summary>
        /// Checks where the player can build enviromental facilities
        /// </summary>
        /// <param name="map">the current map</param>
        /// <returns>a boolean array of where the player can place enviromental facilities</returns>
        public bool[,] BuildCheckResidential(Building[,] map)
        {
            return simSpaceTrevor.BuildCheckResidentialFacilities(map);
        }

        /// <summary>
        /// Constructs the building
        /// </summary>
        /// <param name="map">the current map</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        /// <returns>the new map (will not add the building if the player does not have enough money)</returns>
        public Building[,] BuildComfortableHome(Building[,] map, int x, int y)
        {
            //Run the subprogram in the Tim sim space model
            map = simSpaceTrevor.BuildComfortableHome(map, x, y, money);

            //If the building was sucsessfully built (the location is not null)
            if (map[x, y] != null)
            {
                //Subtract the build cost from the player's pool of money 
                SubtractBuildCost(map[x, y].BuildCost);
            }

            //Calculate Stats
            CalculateStats(map);

            //Return the map
            return map;
        }

        /// <summary>
        /// Constructs the building
        /// </summary>
        /// <param name="map">the current map</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        /// <returns>the new map (will not add the building if the player does not have enough money)</returns>
        public Building[,] BuildAffordableHome(Building[,] map, int x, int y)
        {
            //Run the subprogram in the Tim sim space model
            map = simSpaceTrevor.BuildAffordableHome(map, x, y, money);

            //If the building was sucsessfully built (the location is not null)
            if (map[x, y] != null)
            {
                //Subtract the build cost from the player's pool of money 
                SubtractBuildCost(map[x, y].BuildCost);
            }

            //Calculate Stats
            CalculateStats(map);

            //Return the map
            return map;
        }

        /// <summary>
        /// Constructs the building
        /// </summary>
        /// <param name="map">the current map</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        /// <returns>the new map (will not add the building if the player does not have enough money)</returns>
        public Building[,] BuildLuxuryHome(Building[,] map, int x, int y)
        {
            //Run the subprogram in the Tim sim space model
            map = simSpaceTrevor.BuildLuxuryHome(map, x, y, money);

            //If the building was sucsessfully built (the location is not null)
            if (map[x, y] != null)
            {
                //Subtract the build cost from the player's pool of money 
                SubtractBuildCost(map[x, y].BuildCost);
            }

            //Calculate Stats
            CalculateStats(map);

            //Return the map
            return map;
        }

        /// <summary>
        /// Checks where the player can build enviromental facilities
        /// </summary>
        /// <param name="map">the current map</param>
        /// <returns>a boolean array of where the player can place enviromental facilities</returns>
        public bool[,] BuildCheckRoad(Building[,] map)
        {
            return simSpaceTrevor.BuildCheckRoad(map);
        }

        /// <summary>
        /// Constructs the building
        /// </summary>
        /// <param name="map">the current map</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        /// <returns>the new map (will not add the building if the player does not have enough money)</returns>
        public Building[,] BuildRoad(Building[,] map, int x, int y)
        {
            //Run the subprogram in the Tim sim space model
            map = simSpaceTrevor.BuildRoad(map, x, y);

            //If the building was sucsessfully built (the location is not null)
            if (map[x, y] != null)
            {
                //Subtract the build cost from the player's pool of money 
                SubtractBuildCost(map[x, y].BuildCost);
            }

            //Calculate Stats
            CalculateStats(map);

            //Return the map
            return map;
        }


        /// <summary>
        /// Constructs the building
        /// </summary>
        /// <param name="map">the current map</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        /// <returns>the new map (will not add the building if the player does not have enough money)</returns>
        public Building[,] BuildPark(Building[,] map, int x, int y)
        {
            //Run the subprogram in the trevor sim space model
            map = simSpaceTrevor.BuildPark(map, x, y, money);

            //If the building was sucsessfully built (the location is not null)
            if (map[x, y] != null)
            {
                //Subtract the build cost from the player's pool of money 
                SubtractBuildCost(map[x, y].BuildCost);
            }

            //Calculate Stats
            CalculateStats(map);

            //Return the map
            return map;
        }

        /// <summary>
        /// Constructs the building
        /// </summary>
        /// <param name="map">the current map</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        /// <returns>the new map (will not add the building if the player does not have enough money)</returns>
        public Building[,] BuildEnviromentalFacility(Building[,] map, int x, int y)
        {
            //Run the subprogram in the trevor sim space model
            map = simSpaceTrevor.BuildEnviromentalFacility(map, x, y, money);

            //If the building was sucsessfully built (the location is not null)
            if (map[x, y] != null)
            {
                //Subtract the build cost from the player's pool of money 
                SubtractBuildCost(map[x, y].BuildCost);
            }

            //Calculate Stats
            CalculateStats(map);

            //Return the map
            return map;
        }

        /// <summary>
        /// Constructs the building
        /// </summary>
        /// <param name="map">the current map</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        /// <returns>the new map (will not add the building if the player does not have enough money)</returns>
        public Building[,] BuildMedical(Building[,] map, int x, int y)
        {
            //Run the subprogram in the trevor sim space model
            map = simSpaceTrevor.BuildMedical(map, x, y, money);

            //If the building was sucsessfully built (the location is not null)
            if (map[x, y] != null)
            {
                //Subtract the build cost from the player's pool of money 
                SubtractBuildCost(map[x, y].BuildCost);
            }

            //Calculate Stats
            CalculateStats(map);

            //Return the map
            return map;
        }

        /// <summary>
        /// Constructs the building
        /// </summary>
        /// <param name="map">the current map</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        /// <returns>the new map (will not add the building if the player does not have enough money)</returns>
        public Building[,] BuildEmergencyServices(Building[,] map, int x, int y)
        {
            //Run the subprogram in the trevor sim space model
            map = simSpaceTrevor.BuildEmergencyService(map, x, y, money);

            //If the building was sucsessfully built (the location is not null)
            if (map[x, y] != null)
            {
                //Subtract the build cost from the player's pool of money 
                SubtractBuildCost(map[x, y].BuildCost);
            }

            //Calculate Stats
            CalculateStats(map);

            //Return the map
            return map;
        }

        /// <summary>
        /// Constructs the building
        /// </summary>
        /// <param name="map">the current map</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        /// <returns>the new map (will not add the building if the player does not have enough money)</returns>
        public Building[,] BuildPowerPlant(Building[,] map, int x, int y)
        {
            //Run the subprogram in the trevor sim space model
            map = simSpaceTrevor.BuildPowerPlant(map, x, y, money);

            //If the building was sucsessfully built (the location is not null)
            if (map[x, y] != null)
            {
                //Subtract the build cost from the player's pool of money 
                SubtractBuildCost(map[x, y].BuildCost);
            }

            //Calculate Stats
            CalculateStats(map);

            //Return the map
            return map;
        }

        /// <summary>
        /// Constructs the building
        /// </summary>
        /// <param name="map">the current map</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        /// <returns>the new map (will not add the building if the player does not have enough money)</returns>
        public Building[,] BuildSchool(Building[,] map, int x, int y)
        {
            //Run the subprogram in the trevor sim space model
            map = simSpaceTrevor.BuildSchool(map, x, y, money);

            //If the building was sucsessfully built (the location is not null)
            if (map[x, y] != null)
            {
                //Subtract the build cost from the player's pool of money 
                SubtractBuildCost(map[x, y].BuildCost);
            }

            //Calculate Stats
            CalculateStats(map);

            //Return the map
            return map;
        }

        /// <summary>
        /// Constructs the building
        /// </summary>
        /// <param name="map">the current map</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        /// <returns>the new map (will not add the building if the player does not have enough money)</returns>
        public Building[,] BuildGovernment(Building[,] map, int x, int y)
        {
            //Run the subprogram in the trevor sim space model
            map = simSpaceTrevor.BuildGovernment(map, x, y, money);

            //If the building was sucsessfully built (the location is not null)
            if (map[x, y] != null)
            {
                //Subtract the build cost from the player's pool of money 
                SubtractBuildCost(map[x, y].BuildCost);
            }

            //Calculate Stats
            CalculateStats(map);

            //Return the map
            return map;
        }

        static public bool IsThereARoadAdjacent(Building[,] map, int x, int y)
        {
            return SimSpaceTrevor.CheckRoad(map, x, y);
        }

        /// <summary>
        /// Checks where the player can build enviromental facilities
        /// </summary>
        /// <param name="map">the current map</param>
        /// <returns>a boolean array of where the player can place enviromental facilities</returns>
        public bool[,] BuildCheckEnviromental(Building[,] map)
        {
            return simSpaceTrevor.BuildCheckEnviromental(map);
        }

        /// <summary>
        /// Checks where the player can build enviromental facilities
        /// </summary>
        /// <param name="map">the current map</param>
        /// <returns>a boolean array of where the player can place enviromental facilities</returns>
        public bool[,] BuildCheckEssentialFacilities(Building[,] map)
        {
            return simSpaceTrevor.BuildCheckEssentialFacilities(map);
        }

        /// <summary>
        /// Subtracts the build cost of a newly constructed building
        /// </summary>
        /// <param name="cost"></param>
        private void SubtractBuildCost(long cost)
        {
            money -= cost;
        }

        /// <summary>
        /// Creates a 2d array map of length and height given
        /// </summary>
        /// <param name="length">the length of the array</param>
        /// <param name="height">the height of the array</param>
        /// <returns>the 2d Building array</returns>
        static public Building[,] CreateMap(int length, int height)
        {
            //Create the map (2d building array of length and height)
            Building[,] map = new Building[length, height];
            //Return the map
            return map;
        }

        /// <summary>
        /// Calculates and updates stats
        /// </summary>
        /// <param name="map">the current map</param>
        private void CalculateStats(Building[,] map)
        {
            //variable to calculate the pollution
            int currentPollution = 0;
            long currentRevenue = 0;
            long currentMaintenanceCosts = 0;

            Residential_Facilities temp = new Residential_Facilities();

            //Get the power output
            power = simSpaceTrevor.GetPower(map);

            //Loop through each index in the map array
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    //If there is a building at the current index
                    if (map[row, col] != null)
                    {
                        //If the power is greater than 0
                        if (power > 0)
                        {
                            //Add up the revenue
                            currentRevenue += map[row, col].Revenue;
                        }

                        //Add up the maintenance costs
                        currentMaintenanceCosts += map[row, col].MaintenanceCost;
                        //Add the pollution output
                        currentPollution += map[row, col].PollutionOutput;
                    }
                }
            }

            population = temp.GetTotalPopulation(map);

            //Set the pollution
            pollution = currentPollution;
            //If the pollution is less than 0, set it to 0
            if (pollution < 0)
            {
                pollution = 0;
            }

            //Get the total happiness
            happyPopulation = temp.GetTotalHappiness(map);

            //Set the money
            money += currentRevenue;
            //Set the revenue
            revenue = currentRevenue;

            //Set the maintenance costs
            maintenanceCosts = currentMaintenanceCosts;

            score = CalculateScore();
        }

        /// <summary>
        /// Subprogram for the events that occur each month
        /// </summary>
        /// <param name="map"></param>
        public void advanceMonth(Building[,] map)
        {
            //Run the disaster check if there is a disaster, and if there is run the disaster
            map = randomEvents.DisasterChance(map);

            Residential_Facilities temp = new Residential_Facilities();
            //Increase population
            temp.IncreasePopulation(map);

            //Calculate new stats
            CalculateStats(map);

            //Increase the month
            month++;

            //Add the revenue to the money
            money += revenue;

            //Remove maintenance costs from the money
            money -= maintenanceCosts;

            //If the money is less than 0, set it to 0
            if (money < 0)
            {
                money = 0;
            }
        }

        /// <summary>
        /// Subprogram to calculate the score
        /// </summary>
        /// <returns>the score</returns>
        private int CalculateScore()
        {
            return ((3 * happyPopulation) + population - happyPopulation) - pollution;
        }
    }
}
