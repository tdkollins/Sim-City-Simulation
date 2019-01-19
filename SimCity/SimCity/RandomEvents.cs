using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    class RandomEvents
    {
        const int EARTHQUAKE_CHANCE = 2;
        const int TORNADO_CHANCE = 5;
        const int FLOOD_CHANCE = 3;
        const int ICE_STORM_CHANCE = 1;
        const int PLAGUE_CHANCE = 4;
        const int DROUGHT_CHANCE = 5;

        Random numberGenerator = new Random();

        public Building[,] DisasterChance(Building[,] map)
        {
            //Generate a random number between 1 and 100
            int number = numberGenerator.Next(0, 100);
            //If there is a disaster, run the disaster and return
            if (number < EARTHQUAKE_CHANCE)
            {
                map = Earthquake(map);
                return map;
            }

            //Generate a random number between 1 and 100
            number = numberGenerator.Next(0, 100);
            //If there is a disaster, run the disaster and return
            if (number < TORNADO_CHANCE)
            {
                map =Tornado(map);
                return map;
            }

            //Generate a random number between 1 and 100
            number = numberGenerator.Next(0, 100);
            //If there is a disaster, run the disaster and return
            if (number < FLOOD_CHANCE)
            {
                map =Flood(map);
                return map;
            }

            //Generate a random number between 1 and 100
            number = numberGenerator.Next(0, 100);
            //If there is a disaster, run the disaster and return
            if (number < ICE_STORM_CHANCE)
            {
                map = IceStorm(map);
                return map;
            }

            //Generate a random number between 1 and 100
            number = numberGenerator.Next(0, 100);
            //If there is a disaster, run the disaster and return
            if (number < PLAGUE_CHANCE)
            {
                map =Plague(map);
                return map;
            }

            //Generate a random number between 1 and 100
            number = numberGenerator.Next(0, 100);
            //If there is a disaster, run the disaster and return
            if (number < DROUGHT_CHANCE)
            {
                map = Drought(map);
                return map;
            }

            //No diaster occured return original map
            return map;
        }

        /// <summary>
        /// Destroys a 5x5 section of the world randomly
        /// </summary>
        /// <param name="map"></param>
        public Building[,] Earthquake(Building[,] map)
        {
            //Choose a random number at least 3 spaces form the edge of the mapp
            int x = numberGenerator.Next(2, (map.GetLength(0) - 2));
            int y = numberGenerator.Next(2, (map.GetLength(1) - 2));

            //For the area 5x5 around the x,y location
            for (int row = x - 2; row <= x + 2; row++)
            {
                for (int col = y - 2; col <= y + 2; col++)
                {
                    //Set the building there to nothing
                    map[x, y] = null;
                }
            }

            //Return the map
            return map;
        }

        /// <summary>
        /// Destroys a 3x1 section of the world randomly
        /// </summary>
        /// <param name="map"></param>
        public Building[,] Tornado(Building[,] map)
        {
            //Choose a random number at least 3 spaces form the right side of the map
            int x = numberGenerator.Next(0, (map.GetLength(0) - 2));
            //Choose a random number within the map
            int y = numberGenerator.Next(0, map.GetLength(1));

            //For the area 3x1 around the x,y location
            for (int row = x; row <= x + 2; row++)
            {
                //Set the building there to nothing
                map[x, y] = null;
            }

            //Return the map
            return map;
        }

        /// <summary>
        /// Destroys a 5x1 or 1x5 section of the world randomly and the edge of the map
        /// </summary>
        /// <param name="map"></param>
        public Building[,] Flood(Building[,] map)
        {
            const int LEFT = 0;
            const int TOP = 1;
            const int BOTTOM = 2;
            const int RIGHT = 3;

            int x = 0;
            int y = 0;

            //Choose a random edge of the map
            int edge = numberGenerator.Next(0, 4);

            //If the edge is left or right
            if (edge == LEFT || edge == RIGHT)
            {
                //Choose a random number between the top and 5 from the bottom of the map
                y = numberGenerator.Next(0, map.GetLength(1) - 5);

                //If the edge is the left section
                if (edge == LEFT)
                {
                    //Set the x value to 0
                    x = 0;
                }

                //Else edge is right
                else
                {
                    //Set the x vlaue to the right side of the map
                    x = map.GetLength(0) - 1;
                }

                for (int row = y; row < y + 5; row++)
                {
                    //Set the building there to nothing
                    map[x, y] = null;
                }
            }

            //Else the edge is top or bottom
            else
            {
                //Choose a random number between the top and 5 from the bottom of the map
                x = numberGenerator.Next(0, map.GetLength(0) - 5);

                //If the edge is the top section
                if (edge == TOP)
                {
                    //Set the y value to 0
                    y = 0;
                }

                //Else edge is bottom
                else
                {
                    //Set the y vlaue to the bottom of the map
                    y = map.GetLength(0) - 1;
                }

                for (int row = x; row < x + 5; row++)
                {
                    //Set the building there to nothing
                    map[x, y] = null;
                }
            }

            //Return the map
            return map;
        }

        /// <summary>
        /// Destroys a 1x1 section of the world randomly
        /// </summary>
        /// <param name="map"></param>
        public Building[,] IceStorm(Building[,] map)
        {
            //Choose a random number on the lenght of the map
            int x = numberGenerator.Next(0, map.GetLength(0));
            //Choose a random number within the map
            int y = numberGenerator.Next(0, map.GetLength(1));

            //Set that tile to null
            map[x, y] = null;

            //Return the map
            return map;
        }

        /// <summary>
        /// Drops a 5x5 section of the world's population by 90%
        /// </summary>
        /// <param name="map"></param>
        public Building[,] Plague(Building[,] map)
        {
            //Choose a random number at least 3 spaces form the edge of the mapp
            int x = numberGenerator.Next(2, (map.GetLength(0) - 2));
            int y = numberGenerator.Next(2, (map.GetLength(1) - 2));

            //For the area 5x5 around the x,y location
            for (int row = x - 2; row <= x + 2; row++)
            {
                for (int col = y - 2; col <= y + 2; col++)
                {
                    //If the building there is a residential building
                    if (map[row, col] is Residential_Facilities)
                    {
                        //Drop the population by 90%
                        map[row, col].CurrentPopulation = map[row, col].CurrentPopulation / 10;
                    }
                }
            }

            //Return the map
            return map;
        }

        /// <summary>
        /// Drops a 5x5 section of the world's population by 90%
        /// </summary>
        /// <param name="map"></param>
        public Building[,] Drought(Building[,] map)
        {
            //For each index in the array
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    //If the building there is a residential building
                    if (map[row, col] is Residential_Facilities)
                    {
                        //Drop the population by 50%
                        map[row, col].CurrentPopulation = map[row, col].CurrentPopulation / 2;
                    }
                }
            }

            //Return the map
            return map;
        }
    }
}
