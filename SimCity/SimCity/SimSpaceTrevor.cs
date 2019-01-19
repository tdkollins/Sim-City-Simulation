using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class SimSpaceTrevor
    {
        /// <summary>
        /// //Check where the player can build enviromental facilities (any tile that isn't already occupied)
        /// </summary>
        /// <param name="map">The current state of the map</param>
        /// <returns>a 2d boolean array which flags areas where buildings can be built</returns>
        public bool[,] BuildCheckEnviromental(Building[,] map)
        {
            //Call build check in the enviromental class
            Enviromental temp = new Enviromental();
            return temp.BuildCheck(map);
        }

        /// <summary>
        /// Constructs a EnviromentalFacility
        /// </summary>
        /// <param name="map">The current state of the map</param>
        /// <param name="x">The X Location of the grid</param>
        /// <param name="y">The Y Location of the grid</param>
        /// <param name="money">The current amount of money the player owns</param>
        ///  <param name="isThereRoad">Is there a road tile beside the tile the player is trying to build at</param>
        /// <returns>The new updated map</returns>
        public Building[,] BuildEnviromentalFacility(Building[,] map, int x, int y, long money)
        {
            //Check for any residential facilities and increase happiness by 1

            //Make a EnviromentalFacility object
            Building EnviromentalFacility = new EnviromentalFacility();

            //Check if the player has enough money to build the EnviromentalFacility and that there is a road tile beside the tile
            if (money < EnviromentalFacility.BuildCost)
            {
                //Return the map as is
                return map;
            }

            //Else the player has enough money, add the EnviromentalFacility to the map
            map[x, y] = EnviromentalFacility;

            //Return map
            return map;
        }

        /// <summary>
        /// Constructs a School
        /// </summary>
        /// <param name="map">The current state of the map</param>
        /// <param name="x">The X Location of the grid</param>
        /// <param name="y">The Y Location of the grid</param>
        /// <param name="money">The current amount of money the player owns</param>
        ///  <param name="isThereRoad">Is there a road tile beside the tile the player is trying to build at</param>
        /// <returns>The new updated map</returns>
        public Building[,] BuildSchool(Building[,] map, int x, int y, long money)
        {
            //Check for any residential facilities and increase happiness by 1

            //Make a School object
            Building School = new School();

            //Check if the player has enough money to build the School and that there is a road tile beside the tile
            if (money < School.BuildCost)
            {
                //Return the map as is
                return map;
            }

            //Else the player has enough money, add the School to the map
            map[x, y] = School;

            //Return map
            return map;
        }

        /// <summary>
        /// //Check where the player can build essential facilities (any tile that isn't already occupied)
        /// </summary>
        /// <param name="map">The current state of the map</param>
        /// <returns>a 2d boolean array which flags areas where buildings can be built</returns>
        public bool[,] BuildCheckEssentialFacilities(Building[,] map)
        {
            //Call build check in the essential services class
            EssentialServices temp = new EssentialServices();
            return temp.BuildCheck(map);
        }

        /// <summary>
        /// Constructs a Medical
        /// </summary>
        /// <param name="map">The current state of the map</param>
        /// <param name="x">The X Location of the grid</param>
        /// <param name="y">The Y Location of the grid</param>
        /// <param name="money">The current amount of money the player owns</param>
        ///  <param name="isThereRoad">Is there a road tile beside the tile the player is trying to build at</param>
        /// <returns>The new updated map</returns>
        public Building[,] BuildMedical(Building[,] map, int x, int y, long money)
        {
            //Check for any residential facilities and increase happiness by 1

            //Make a Medical object
            Building Medical = new Medical();

            //Check if the player has enough money to build the Medical and that there is a road tile beside the tile
            if (money < Medical.BuildCost)
            {
                //Return the map as is
                return map;
            }

            //Else the player has enough money, add the Medical to the map
            map[x, y] = Medical;

            //Return map
            return map;
        }

        /// <summary>
        /// Constructs a EmergencyService
        /// </summary>
        /// <param name="map">The current state of the map</param>
        /// <param name="x">The X Location of the grid</param>
        /// <param name="y">The Y Location of the grid</param>
        /// <param name="money">The current amount of money the player owns</param>
        ///  <param name="isThereRoad">Is there a road tile beside the tile the player is trying to build at</param>
        /// <returns>The new updated map</returns>
        public Building[,] BuildEmergencyService(Building[,] map, int x, int y, long money)
        {
            //Check for any residential facilities and increase happiness by 1

            //Make a EmergencyService object
            Building EmergencyService = new EmergencyServices();

            //Check if the player has enough money to build the EmergencyService and that there is a road tile beside the tile
            if (money < EmergencyService.BuildCost)
            {
                //Return the map as is
                return map;
            }

            //Else the player has enough money, add the EmergencyService to the map
            map[x, y] = EmergencyService;

            //Return map
            return map;
        }

        /// <summary>
        /// Constructs a Government
        /// </summary>
        /// <param name="map">The current state of the map</param>
        /// <param name="x">The X Location of the grid</param>
        /// <param name="y">The Y Location of the grid</param>
        /// <param name="money">The current amount of money the player owns</param>
        ///  <param name="isThereRoad">Is there a road tile beside the tile the player is trying to build at</param>
        /// <returns>The new updated map</returns>
        public Building[,] BuildGovernment(Building[,] map, int x, int y, long money)
        {
            //Check for any residential facilities and increase happiness by 1

            //Make a Government object
            Building Government = new Government();

            //Check if the player has enough money to build the Government and that there is a road tile beside the tile
            if (money < Government.BuildCost)
            {
                //Return the map as is
                return map;
            }

            //Else the player has enough money, add the Government to the map
            map[x, y] = Government;

            //Return map
            return map;
        }

        /// <summary>
        /// Constructs a PowerPlant
        /// </summary>
        /// <param name="map">The current state of the map</param>
        /// <param name="x">The X Location of the grid</param>
        /// <param name="y">The Y Location of the grid</param>
        /// <param name="money">The current amount of money the player owns</param>
        ///  <param name="isThereRoad">Is there a road tile beside the tile the player is trying to build at</param>
        /// <returns>The new updated map</returns>
        public Building[,] BuildPowerPlant(Building[,] map, int x, int y, long money)
        {
            //Check for any residential facilities and increase happiness by 1

            //Make a PowerPlant object
            Building PowerPlant = new PowerPlant();

            //Check if the player has enough money to build the PowerPlant and that there is a road tile beside the tile
            if (money < PowerPlant.BuildCost)
            {
                //Return the map as is
                return map;
            }

            //Else the player has enough money, add the PowerPlant to the map
            map[x, y] = PowerPlant;

            //Return map
            return map;
        }

        /// <summary>
        /// Constructs a park
        /// </summary>
        /// <param name="map">The current state of the map</param>
        /// <param name="x">The X Location of the grid</param>
        /// <param name="y">The Y Location of the grid</param>
        /// <param name="money">The current amount of money the player owns</param>
        ///  <param name="isThereRoad">Is there a road tile beside the tile the player is trying to build at</param>
        /// <returns>The new updated map</returns>
        public Building[,] BuildPark(Building[,] map, int x, int y, long money)
        {
            //Make a park object
            Building park = new Park();

            //Check if the player has enough money to build the park and that there is a road tile beside the tile
            if (money < park.BuildCost)
            {
                //Return the map as is
                return map;
            }

            //Else the player has enough money, add the park to the map
            map[x, y] = park;

            //Check the area around the corrdinates
            //If there is a tile to the left
            if (x > 0)
            {
                //If that tile is a residential facility
                if (map[x - 1, y] is Residential_Facilities)
                {
                    //Increase that residential facilities happiness by 10%
                    map[x - 1, y].GetPercentHappiness += 10;
                }
            }

            //Of there is a tile above
            if (y > 0)
            {
                //If that tile is a residential facility
                if (map[x, y - 1] is Residential_Facilities)
                {
                    //Increase that residential facilities happiness by 10%
                    map[x, y - 1].GetPercentHappiness += 10;
                }
            }

            //If there is a tile to the right
            if (x < (map.GetLength(1) - 1))
            {
                //If that tile is a residential facility
                if (map[x + 1, y] is Residential_Facilities)
                {
                    //Increase that residential facilities happiness by 10%
                    map[x + 1, y].GetPercentHappiness += 10;
                }
            }

            //If there is a tile below
            if (y < (map.GetLength(1) - 1))
            {
                //If that tile is a residential facility
                if (map[x, y + 1] is Residential_Facilities)
                {
                    //Increase that residential facilities happiness by 10%
                    map[x, y + 1].GetPercentHappiness += 10;
                }
            }

            //Return map
            return map;
        }

        public int GetPower(Building[,] map)
        {
            //Have a variable to store the power
            int currentPower = 0;

            //Loop through each index in the map array
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    //If there is a building at the current index
                    if (map[row, col] != null)
                    {
                        //Add the power output/cost to current power
                        currentPower -= map[row, col].PowerCost;
                    }
                }
            }

            //Return the total power
            return currentPower;
        }

        //Will check if there is a road beside the place the player is trying to build at
        static public bool CheckRoad(Building[,] map, int x, int y)
        {
            //If there is a tile to the left
            if (x > 0)
            {
                //If the tile to the left is a road
                if (map[x - 1, y] is Road)
                {
                    //Return true
                    return true;
                }
            }

            //If there is a tile to the right
            if (x < map.GetLength(0) - 1)
            {
                //If the tile to the right is a road
                if (map[x + 1, y] is Road)
                {
                    //Return true
                    return true;
                }
            }

            //If there is a tile above
            if (y > 0)
            {
                //If the tile above is a road
                if (map[x, y - 1] is Road)
                {
                    //Return true
                    return true;
                }
            }

            //If there is a tile below
            if (y < map.GetLength(1) - 1)
            {
                //If the tile below is a road
                if (map[x, y + 1] is Road)
                {
                    //Return true
                    return true;
                }
            }

            //Else return false
            return false;
        }

        /// <summary>
        /// Checks where the player can build an Industrial facility
        /// </summary>
        /// <param name="map">Current map.</param>
        /// <returns>2d array that checks where the buildings can be build</returns>
        public bool[,] IndustrialCheck(Building[,] map)
        {
            // Build check in the industrial class.
            Industrial temp = new Industrial();
            return temp.BuildCheck(map);
        }

        /// <summary>
        /// Checks where the player can build a Commercial facility
        /// </summary>
        /// <param name="map">Current map.</param>
        /// <returns>2d array that chacks where the buildings can be build.</returns>
        public bool[,] CommercialCheck(Building[,] map)
        {
            // Build check in the commertial class.
            Commercial temp = new Commercial();
            return temp.BuildCheck(map);
        }

        /// <summary>
        /// Constructs a Store building.
        /// </summary>
        /// <param name="map">Current map.</param>
        /// <param name="row">The row location on the grid.</param>
        /// <param name="col">The column location on the grid.</param>
        /// <param name="money">Corrent money.</param>
        /// <returns>Updated map.</returns>
        public Building[,] StoreBuilding(Building[,] map, int row, int col, long money)
        {
            // Creates a Store object.
            Building store = new Store();
            // Checks to see if the player has enough money to get a store building 
            if (money < store.BuildCost)
            {
                // current map.
                return map;
            }
            // The player has enough money, store is placed at particular row and column.
            map[row, col] = store;
            // Map is returned.
            return map;
        }

        /// <summary>
        /// Constructs an Office building.
        /// </summary>
        /// <param name="map">Current map.</param>
        /// <param name="row">The row location on the grid.</param>
        /// <param name="col">The column location on the grid.</param>
        /// <param name="money">Corrent money.</param>
        /// <returns>Updated map.</returns>
        public Building[,] OfficeBuilding(Building[,] map, int row, int col, long money)
        {
            // Creates an Office object.
            Building office = new Office();
            // Checks to see if the player has enough money to get a store building 
            if (money < office.BuildCost)
            {
                // current map.
                return map;
            }
            // The player has enough money, Office is placed at particular row and column.
            map[row, col] = office;
            // Map is returned.
            return map;
        }

        /// <summary>
        /// Constructs a Restaurant building.
        /// </summary>
        /// <param name="map">Current map.</param>
        /// <param name="row">The row location on the grid.</param>
        /// <param name="col">The column location on the grid.</param>
        /// <param name="money">Corrent money.</param>
        /// <returns>Updated map.</returns>
        public Building[,] RestaurantBuilding(Building[,] map, int row, int col, long money)
        {
            // Creates a Restaurant object.
            Building restaurant = new Restaurant();
            // Checks to see if the player has enough money to get a store building
            if (money < restaurant.BuildCost)
            {
                // current map.
                return map;
            }
            // The player has enough money, Restaurant is placed at particular row and column.
            map[row, col] = restaurant;
            // Map is returned.
            return map;
        }

        /// <summary>
        /// Constructs a Factory building.
        /// </summary>
        /// <param name="map">Current map.</param>
        /// <param name="row">The row location on the grid.</param>
        /// <param name="col">The column location on the grid.</param>
        /// <param name="money">Corrent money.</param>
        /// <returns>Updated map.</returns>
        public Building[,] FactoryBuilding(Building[,] map, int row, int col, long money)
        {
            // Creates a Factory object.
            Building factory = new Factory();
            // Checks to see if the player has enough money to get a store building
            if (money < factory.BuildCost)
            {
                // current map.
                return map;
            }
            // The player has enough money, Restaurant is placed at particular row and column.
            map[row, col] = factory;
            // Map is returned.
            return map;
        }

        /// <summary>
        /// Stores the total power of all the ficilities on the map.
        /// </summary>
        /// <param name="map">Current map</param>
        public int GetTotalPower(Building[,] map, int totalPower)
        {
            // set a variable for the total power.
            totalPower = 0;
            // Loops throught indexes in the map.
            for (int row = 0; row < map.GetLength(1); row++)
            {
                for (int col = 0; col < map.GetLength(0); col++)
                {
                    // If the building is defined at a current index
                    if (map[row, col] != null)
                    {
                        // Then add the power to the total power.
                        totalPower = totalPower + map[row, col].PowerCost;
                    }
                }
            }
            return totalPower;
        }

        /// <summary>
        /// Stores the total pollution of all the ficilities on the map.
        /// </summary>
        /// <param name="map">Current map</param>
        public int GetTotalPollution(Building[,] map, int totalPollution)
        {
            totalPollution = 0;
            for (int row = 0; row < map.GetLength(1); row++)
            {
                for (int col = 0; col < map.GetLength(0); col++)
                {
                    // If the building is defined at a current index
                    if (map[row, col] != null)
                    {
                        // Then add the pollution to the total pollution.
                        totalPollution = totalPollution + map[row, col].PollutionOutput;
                    }
                }
            }
            return totalPollution;
        }

        /// <summary>
        /// Determines if there is a/are park(s) adjacent to a building and returns how many parks
        /// </summary>
        /// <param name="map">the map</param>
        /// <returns>the number of parks that are adjacent</returns>
        public int IsThereParkAdjacent(Building[,] map, int x, int y)
        {
            int numberOfParks = 0;

            //Check the area around the corrdinates
            //If there is a tile to the left
            if (x > 0)
            {
                //If that tile is a park
                if (map[x - 1, y] is Park)
                {
                    //Increase the number of parks
                    numberOfParks++;
                }
            }

            //Of there is a tile above
            if (y > 0)
            {
                //If that tile is a park
                if (map[x, y - 1] is Park)
                {
                    //Increase the number of parks
                    numberOfParks++;
                }
            }

            //If there is a tile to the right
            if (x < (map.GetLength(1) - 1))
            {
                //If that tile is a park
                if (map[x + 1, y] is Park)
                {
                    //Increase the number of parks
                    numberOfParks++;
                }
            }

            //If there is a tile below
            if (y < (map.GetLength(1) - 1))
            {
                //If that tile is a park
                if (map[x, y + 1] is Park)
                {
                    //Increase the number of parks
                    numberOfParks++;
                }
            }

            //Return the number of parks
            return numberOfParks;
        }

        /// <summary>
        /// Build check road
        /// </summary>
        /// <param name="map"></param>
        /// <returns>new map</returns>
        public bool[,] BuildCheckRoad(Building[,] map)
        {
            Road temp = new Road();
            return temp.BuildCheck(map);
        }

        /// <summary>
        /// Build check residential facilities
        /// </summary>
        /// <param name="map"></param>
        /// <returns>new map</returns>
        public bool[,] BuildCheckResidentialFacilities(Building[,] map)
        {
            Residential_Facilities temp = new Residential_Facilities();
            return temp.BuildCheck(map);
        }

        /// <summary>
        /// Construct a road
        /// </summary>
        /// <param name="map"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>        
        /// <returns>new map</returns>
        public Building[,] BuildRoad(Building[,] map, int x, int y)
        {
            Building road = new Road();
            map[x, y] = road;
            return map;
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

            //Increase the percent happiness according to the number of parks adjacent
            comfortableHome.GetPercentHappiness += 10 * IsThereParkAdjacent(map, x, y);
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

            //Increase the percent happiness according to the number of parks adjacent
            affordableHome.GetPercentHappiness += 10 * IsThereParkAdjacent(map, x, y);
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

            //Increase the percent happiness according to the number of parks adjacent
            luxuryHome.GetPercentHappiness += 10 * IsThereParkAdjacent(map, x, y);
            map[x, y] = luxuryHome;
            return map;
        }
    }
}
