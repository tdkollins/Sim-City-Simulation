using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimCity
{
    public partial class Trevor_Form : Form
    {
        const int GAME_RUNNING = 0;
        const int GAME_OVER = 1;
        int gameState = GAME_RUNNING;

        //Store a simspace
        SimSpace simSpace = new SimSpace();

        //Create a map 2d array which stores buildings
        Building[,] map;

        //Create a 2d array which stores where buildings can be built
        bool[,] availableBuildLocations;

        //Pen object for drawing lines
        Pen linePen = new Pen(Color.Black, 2);

        //Size object for image sizes
        Size imageSize = new Size(40, 40);

        //Instance variable to store the currently selected building
        Building selectedBuilding = null;

        public Trevor_Form()
        {
            InitializeComponent();

            Setup();
        }

        //Setup subprogram for when the form starts
        private void Setup()
        {
            //Set the form width and height
            this.Width = 1100;
            this.Height = 1050;

            DoubleBuffered = true;

            //Set the location of the labels
            lblPlayer.Location = new Point(850, this.Height / 15);
            lblBuilding.Location = new Point(850, this.Height / 7 * 3);

            //Set the width height and location of the picture boxes
            picEnviromental.Width = 80;
            picEnviromental.Height = 80;
            picEnviromental.Location = new Point(this.Width / 20, 32 * 22 - 10);

            picEssentialServices.Width = 80;
            picEssentialServices.Height = 80;
            picEssentialServices.Location = new Point(this.Width / 20 * 4, 32 * 22 - 10);

            picIndustrial.Width = 80;
            picIndustrial.Height = 80;
            picIndustrial.Location = new Point(this.Width / 20 * 7, 32 * 22 - 10);

            picResidential.Width = 80;
            picResidential.Height = 80;
            picResidential.Location = new Point(this.Width / 20 * 10 + 10, 32 * 22 - 10);

            picCommerical.Width = 80;
            picCommerical.Height = 80;
            picCommerical.Location = new Point(this.Width / 20 * 14 - 15, 32 * 22 - 10);

            picRoad.Width = 80;
            picRoad.Height = 80;
            picRoad.Location = new Point(this.Width / 20 * 17 - 5, 32 * 22 - 10);

            picPark.Width = 80;
            picPark.Height = 80;
            picPark.Location = new Point(this.Width / 20, 32 * 32 - 10);

            picEnviromentalFacility.Width = 80;
            picEnviromentalFacility.Height = 80;
            picEnviromentalFacility.Location = new Point(this.Width / 20 * 4, 32 * 22 - 10);

            picSchool.Width = 80;
            picSchool.Height = 80;
            picSchool.Location = new Point(this.Width / 20, 32 * 22 - 10);

            picMedical.Width = 80;
            picMedical.Height = 80;
            picMedical.Location = new Point(this.Width / 20 * 4, 32 * 22 - 10);

            picGovernment.Width = 80;
            picGovernment.Height = 80;
            picGovernment.Location = new Point(this.Width / 20 * 7, 32 * 22 - 10);

            picEmergencyService.Width = 80;
            picEmergencyService.Height = 80;
            picEmergencyService.Location = new Point(this.Width / 20 * 10 + 10, 32 * 22 - 10);

            picPowerPlant.Width = 80;
            picPowerPlant.Height = 80;
            picPowerPlant.Location = new Point(this.Width / 20 * 14 - 15, 32 * 22 - 10);

            picFactory.Width = 80;
            picFactory.Height = 80;
            picFactory.Location = new Point(this.Width / 20, 32 * 22 - 10);

            picRestaurant.Width = 80;
            picRestaurant.Height = 80;
            picRestaurant.Location = new Point(this.Width / 20, 32 * 22 - 10);

            picStore.Width = 80;
            picStore.Height = 80;
            picStore.Location = new Point(this.Width / 20 * 4, 32 * 22 - 10);

            picOffice.Width = 80;
            picOffice.Height = 80;
            picOffice.Location = new Point(this.Width / 20 * 7, 32 * 22 - 10);

            picAffordableHome.Width = 80;
            picAffordableHome.Height = 80;
            picAffordableHome.Location = new Point(this.Width / 20, 32 * 22 - 10);

            picComfortableHome.Width = 80;
            picComfortableHome.Height = 80;
            picComfortableHome.Location = new Point(this.Width / 20 * 4, 32 * 22 - 10);

            picLuxaryHome.Width = 80;
            picLuxaryHome.Height = 80;
            picLuxaryHome.Location = new Point(this.Width / 20 * 7, 32 * 22 - 10);

            picBack.Width = 80;
            picBack.Height = 80;
            picBack.Location = new Point(this.Width / 20 * 17 - 5, 32 * 22 - 10);

            //Hide picture boxes which are not on the inital menu
            picPark.Visible = false;
            picBack.Visible = false;
            picEnviromentalFacility.Visible = false;
            picSchool.Visible = false;
            picGovernment.Visible = false;
            picPowerPlant.Visible = false;
            picEmergencyService.Visible = false;
            picMedical.Visible = false;
            picFactory.Visible = false;
            picOffice.Visible = false;
            picRestaurant.Visible = false;
            picStore.Visible = false;
            picComfortableHome.Visible = false;
            picAffordableHome.Visible = false;
            picLuxaryHome.Visible = false;
            lblGameOver.Visible = false;

            //Create and store the map
            map = SimSpace.CreateMap(15, 15);

            //Set the game over text
            lblGameOver.Text = "Game over! Thanks for playing!";
        }

        /// <summary>
        /// Onpaint subprogram, used to draw graphics
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //If the game is running
            if (gameState == GAME_RUNNING)
            {
                //Divide the map into a grid and draw the grid
                for (int row = 0; row <= map.GetLength(0); row++)
                {
                    e.Graphics.DrawLine(linePen, 0, row * 40, this.Width - 500, row * 40);
                }
                for (int col = 0; col <= map.GetLength(1); col++)
                {
                    e.Graphics.DrawLine(linePen, col * 40, 0, col * 40, this.Height - 285);
                }

                //If there is a building selected
                if (selectedBuilding != null)
                {
                    //For each location on the grid where the user can build, draw a green square to indicate so to the user
                    for (int row = 0; row < availableBuildLocations.GetLength(0); row++)
                    {
                        for (int col = 0; col < availableBuildLocations.GetLength(1); col++)
                        {
                            //If the row and column is flagged that the user can build there
                            if (availableBuildLocations[row, col])
                            {
                                //Draw the location in green
                                e.Graphics.FillRectangle(Brushes.Green, new Rectangle(new Point(row * 40 + 1, col * 40 + 1), new Size(38, 38)));
                            }
                        }
                    }
                }

                //For each location on the grid
                for (int row = 0; row < map.GetLength(0); row++)
                {
                    for (int col = 0; col < map.GetLength(1); col++)
                    {
                        //If there is a building at the selected location, draw it at the appropriate location
                        if (map[row, col] != null)
                        {
                            if (map[row, col] is Park)
                            {
                                e.Graphics.DrawImage(Properties.Resources.Park, new Rectangle(new Point(row * 40, col * 40), imageSize));
                            }

                            else if (map[row, col] is EnviromentalFacility)
                            {
                                e.Graphics.DrawImage(Properties.Resources.EnviromentalFacility, new Rectangle(new Point(row * 40, col * 40), imageSize));
                            }

                            else if (map[row, col] is Government)
                            {
                                e.Graphics.DrawImage(Properties.Resources.Government, new Rectangle(new Point(row * 40, col * 40), imageSize));
                            }

                            else if (map[row, col] is School)
                            {
                                e.Graphics.DrawImage(Properties.Resources.School, new Rectangle(new Point(row * 40, col * 40), imageSize));
                            }

                            else if (map[row, col] is Medical)
                            {
                                e.Graphics.DrawImage(Properties.Resources.Medical, new Rectangle(new Point(row * 40, col * 40), imageSize));
                            }

                            else if (map[row, col] is EmergencyServices)
                            {
                                e.Graphics.DrawImage(Properties.Resources.Emergency_service, new Rectangle(new Point(row * 40, col * 40), imageSize));
                            }

                            else if (map[row, col] is PowerPlant)
                            {
                                e.Graphics.DrawImage(Properties.Resources.Powerplant, new Rectangle(new Point(row * 40, col * 40), imageSize));
                            }

                            else if (map[row, col] is Factory)
                            {
                                e.Graphics.DrawImage(Properties.Resources.Factory, new Rectangle(new Point(row * 40, col * 40), imageSize));
                            }

                            else if (map[row, col] is AffordableHomes)
                            {
                                e.Graphics.DrawImage(Properties.Resources.Affordable_home, new Rectangle(new Point(row * 40, col * 40), imageSize));
                            }

                            else if (map[row, col] is comfortableHomes)
                            {
                                e.Graphics.DrawImage(Properties.Resources.Comfortable_house, new Rectangle(new Point(row * 40, col * 40), imageSize));
                            }

                            else if (map[row, col] is luxuryHomes)
                            {
                                e.Graphics.DrawImage(Properties.Resources.Luxoury_house, new Rectangle(new Point(row * 40, col * 40), imageSize));
                            }

                            else if (map[row, col] is Store)
                            {
                                e.Graphics.DrawImage(Properties.Resources.Store, new Rectangle(new Point(row * 40, col * 40), imageSize));
                            }

                            else if (map[row, col] is Restaurant)
                            {
                                e.Graphics.DrawImage(Properties.Resources.Restaurant, new Rectangle(new Point(row * 40, col * 40), imageSize));
                            }

                            else if (map[row, col] is Office)
                            {
                                e.Graphics.DrawImage(Properties.Resources.Office, new Rectangle(new Point(row * 40, col * 40), imageSize));
                            }

                            else
                            {
                                e.Graphics.DrawImage(Properties.Resources.Road, new Rectangle(new Point(row * 40, col * 40), imageSize));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Subprogram which hides or shows all the building pictures
        /// </summary>
        private void ToggleBuildingPictures()
        {
            //Check if the pictures are visibile or not
            //If pictures are visible
            if (picEnviromental.Visible)
            {
                //Hide all the building pictures
                picEnviromental.Visible = false;
                picEssentialServices.Visible = false;
                picIndustrial.Visible = false;
                picResidential.Visible = false;
                picCommerical.Visible = false;
                picRoad.Visible = false;

                //Show the back button
                picBack.Visible = true;

                //Return
                return;
            }

            //Else toggle all the building pictures to visible
            picEnviromental.Visible = true;
            picEssentialServices.Visible = true;
            picIndustrial.Visible = true;
            picResidential.Visible = true;
            picCommerical.Visible = true;
            picRoad.Visible = true;

            //Hide the back button
            picBack.Visible = false;
        }

        /// <summary>
        /// Subprogram which hides or shows all the enviromental facility pictures
        /// </summary>
        private void ToggleEnviromentalPictures()
        {
            //Check if the pictures are visibile or not
            //If pictures are visible
            if (picPark.Visible)
            {
                //Set to not be visible
                picPark.Visible = false;
                picEnviromentalFacility.Visible = false;

                //Return
                return;
            }

            //Else set pictures to visible
            picPark.Visible = true;
            picEnviromentalFacility.Visible = true;
        }

        /// <summary>
        /// Subprogram which hides or shows all the industrial facility pictures
        /// </summary>
        private void ToggleIndustrialPictures()
        {
            //Check if the pictures are visibile or not
            //If pictures are visible
            if (picFactory.Visible)
            {
                //Set to not be visible
                picFactory.Visible = false;

                //Return
                return;
            }

            //Else set pictures to visible
            picFactory.Visible = true;
        }

        /// <summary>
        /// Subprogram which hides or shows all the Essential facility pictures
        /// </summary>
        private void ToggleEssentialServicePictures()
        {
            //Check if the pictures are visibile or not
            //If pictures are visible
            if (picSchool.Visible)
            {
                //Set to not be visible
                picSchool.Visible = false;
                picMedical.Visible = false;
                picEmergencyService.Visible = false;
                picGovernment.Visible = false;
                picPowerPlant.Visible = false;

                //Return
                return;
            }

            //Else set pictures to visible
            picSchool.Visible = true;
            picMedical.Visible = true;
            picEmergencyService.Visible = true;
            picGovernment.Visible = true;
            picPowerPlant.Visible = true;
        }

        /// <summary>
        /// Subprogram which hides or shows all the Residential facility pictures
        /// </summary>
        private void ToggleResidentialPictures()
        {
            //Check if the pictures are visibile or not
            //If pictures are visible
            if (picAffordableHome.Visible)
            {
                //Set to not be visible
                picAffordableHome.Visible = false;
                picComfortableHome.Visible = false;
                picLuxaryHome.Visible = false;

                //Return
                return;
            }

            //Else set pictures to visible
            picAffordableHome.Visible = true;
            picComfortableHome.Visible = true;
            picLuxaryHome.Visible = true;
        }

        /// <summary>
        /// Subprogram which hides or shows all the Commerical facility pictures
        /// </summary>
        private void ToggleCommercialPictures()
        {
            //Check if the pictures are visibile or not
            //If pictures are visible
            if (picStore.Visible)
            {
                //Set to not be visible
                picStore.Visible = false;
                picOffice.Visible = false;
                picRestaurant.Visible = false;

                //Return
                return;
            }

            //Else set pictures to visible
            picStore.Visible = true;
            picOffice.Visible = true;
            picRestaurant.Visible = true;
        }

        //When the enviroment picture is clicked on
        private void picEnviromental_Click_1(object sender, EventArgs e)
        {
            //Find the avilable locations for building
            availableBuildLocations = simSpace.BuildCheckEnviromental(map);

            //Hide all of the building catagory pictures and show the enviromental facility pictures
            ToggleBuildingPictures();
            ToggleEnviromentalPictures();
        }

        //When the Essential services picture is clicked on
        private void picEssentialServices_Click_1(object sender, EventArgs e)
        {
            //Find all available locations for building
            availableBuildLocations = simSpace.BuildCheckEssentialFacilities(map);

            //Hide all of the building catagory pictures and show the essential service facility pictures
            ToggleBuildingPictures();
            ToggleEssentialServicePictures();
        }

        //When the Industrial picture is clicked on
        private void picIndustrial_Click_1(object sender, EventArgs e)
        {
            //Find all available locations for building
            availableBuildLocations = simSpace.BuildCheckIndustrial(map);

            //Hide all of the building catagory pictures and show the industrial facility pictures
            ToggleBuildingPictures();
            ToggleIndustrialPictures();
        }

        //When the residential picture is clicked on
        private void picResidential_Click_1(object sender, EventArgs e)
        {
            //Find all available locations for building
            availableBuildLocations = simSpace.BuildCheckResidential(map);

            //Hide all of the building catagory pictures and show the residential facility pictures
            ToggleBuildingPictures();
            ToggleResidentialPictures();
        }

        //When the commercial picture is clicked on
        private void picCommerical_Click_1(object sender, EventArgs e)
        {
            //Find all available locations for building
            availableBuildLocations = simSpace.BuildCheckCommercial(map);

            //Hide all of the building catagory pictures and show the commercial facility pictures
            ToggleBuildingPictures();
            ToggleCommercialPictures();
        }

        //When the road picture is clicked on
        private void picRoad_Click_1(object sender, EventArgs e)
        {
            //Find all available locations for building
            availableBuildLocations = simSpace.BuildCheckRoad(map);

            //Set road to be the selected building
            selectedBuilding = new Road();

            //Update building label
            UpdateBuildingLabel();

            //Hide all of the building catagory pictures
            ToggleBuildingPictures();

            //Refresh the graphics
            Refresh();
        }

        //Subprogram for when the back button is clicked
        private void picBack_Click_1(object sender, EventArgs e)
        {
            //If there is something selected
            if (selectedBuilding != null)
            {
                //If there is an enviromental building currently selected
                if (selectedBuilding is Enviromental)
                {
                    //Toggle to show those buildings
                    ToggleEnviromentalPictures();
                }

                //Else if there is a residential building currently selected
                else if (selectedBuilding is Residential_Facilities)
                {
                    //Toggle to show those buildings
                    ToggleResidentialPictures();
                }

                //Else if there is an industrial building selected
                else if (selectedBuilding is Industrial)
                {
                    //Toggle to show that building
                    ToggleIndustrialPictures();
                }

                //Else if there is a commercial building selected
                else if (selectedBuilding is Commercial)
                {
                    //Toggle to show those buildings
                    ToggleCommercialPictures();
                }

                //Else if there is an essential building selected
                else if (selectedBuilding is EssentialServices)
                {
                    //Toggle to show those buildings
                    ToggleEssentialServicePictures();
                }

                //Else there is a road selected
                else
                {
                    //Toggle to show the building selection once again
                    ToggleBuildingPictures();
                }

                //Set there to be nothing selected
                selectedBuilding = null;

                //Update the label to be null
                lblBuilding.Text = null;

                //Refresh the graphics
                Refresh();

                //Return
                return;
            }

            //Else the gamestate is not in selection mode and the user wishes to go back to the building selection (and not the facility selection)
            //Toggle the building picture visiblity
            ToggleBuildingPictures();

            //If it is the enviromental pictures showing
            if (picPark.Visible)
            {
                //Toggle to not be visible anymore
                ToggleEnviromentalPictures();
            }

            //Else if it is the essential facility pictures showing
            else if (picSchool.Visible)
            {
                //Toggle to not be visible anymore
                ToggleEssentialServicePictures();
            }

            //Else if it is the residential pictures showing
            else if (picAffordableHome.Visible)
            {
                //Toggle to not be visible anymore
                ToggleResidentialPictures();
            }

            //Else if it is the commerical pictures showing
            else if (picStore.Visible)
            {
                //Toggle to not be visible anymore
                ToggleCommercialPictures();
            }

            //Else it is the industrial pictures showing
            else if (picFactory.Visible)
            {
                //Toggle to not be visible anymore
                ToggleIndustrialPictures();
            }
        }

        //Subprogram that runs when the user clicks on the form
        private void Trevor_Form_MouseClick_1(object sender, MouseEventArgs e)
        {
            //If the user has a building selected
            if (selectedBuilding != null)
            {
                //If the user clicked somewhere on the grid
                if (e.Location.X < map.GetLength(0) * 40 && e.Location.Y < map.GetLength(1) * 40)
                {
                    //Store the x location and the y location of the click
                    double x = e.Location.X;
                    double y = e.Location.Y;

                    //Convert the x and y location of the mouse into grid corridnates
                    x = Math.Floor(x / 40);
                    y = Math.Floor(y / 40);

                    //If the user can build at the location they clicked
                    if (availableBuildLocations[(int)x, (int)y] == true)
                    {
                        //Attempt to build whatever facility they are trying to build at the location x and y:

                        if (selectedBuilding is Park)
                        {
                            map = simSpace.BuildPark(map, (int)x, (int)y);
                            //if the building was not sucsessfully built (due to not having enough money)
                            if (map[(int)x, (int)y] == null)
                            {
                                //Let the user know so and the reason why
                                lblBuilding.Text = "Building Can't Be Built.\r\nDo you have enough money?";
                            }
                        }

                        else if (selectedBuilding is EnviromentalFacility)
                        {
                            map = simSpace.BuildEnviromentalFacility(map, (int)x, (int)y);
                            //if the building was not sucsessfully built (due to not having enough money)
                            if (map[(int)x, (int)y] == null)
                            {
                                //Let the user know so and the reason why
                                lblBuilding.Text = "Building Can't Be Built.\r\nDo you have enough money?";
                            }
                        }

                        else if (selectedBuilding is Government)
                        {
                            map = simSpace.BuildGovernment(map, (int)x, (int)y);
                            //if the building was not sucsessfully built (due to not having enough money)
                            if (map[(int)x, (int)y] == null)
                            {
                                //Let the user know so and the reason why
                                lblBuilding.Text = "Building Can't Be Built.\r\nDo you have enough money?";
                            }
                        }

                        else if (selectedBuilding is EmergencyServices)
                        {
                            map = simSpace.BuildEmergencyServices(map, (int)x, (int)y);
                            //if the building was not sucsessfully built (due to not having enough money)
                            if (map[(int)x, (int)y] == null)
                            {
                                //Let the user know so and the reason why
                                lblBuilding.Text = "Building Can't Be Built.\r\nDo you have enough money?";
                            }
                        }

                        else if (selectedBuilding is Medical)
                        {
                            map = simSpace.BuildMedical(map, (int)x, (int)y);
                            //if the building was not sucsessfully built (due to not having enough money)
                            if (map[(int)x, (int)y] == null)
                            {
                                //Let the user know so and the reason why
                                lblBuilding.Text = "Building Can't Be Built.\r\nDo you have enough money?";
                            }
                        }

                        else if (selectedBuilding is PowerPlant)
                        {
                            map = simSpace.BuildPowerPlant(map, (int)x, (int)y);
                            //if the building was not sucsessfully built (due to not having enough money)
                            if (map[(int)x, (int)y] == null)
                            {
                                //Let the user know so and the reason why
                                lblBuilding.Text = "Building Can't Be Built.\r\nDo you have enough money?";
                            }
                        }

                        else if (selectedBuilding is School)
                        {
                            map = simSpace.BuildSchool(map, (int)x, (int)y);
                            //if the building was not sucsessfully built (due to not having enough money)
                            if (map[(int)x, (int)y] == null)
                            {
                                //Let the user know so and the reason why
                                lblBuilding.Text = "Building Can't Be Built.\r\nDo you have enough money?";
                            }
                        }

                        else if (selectedBuilding is Road)
                        {
                            map = simSpace.BuildRoad(map, (int)x, (int)y);
                            //if the building was not sucsessfully built (due to not having enough money)
                            if (map[(int)x, (int)y] == null)
                            {
                                //Let the user know so and the reason why
                                lblBuilding.Text = "Building Can't Be Built.\r\nDo you have enough money?";
                            }
                        }

                        else if (selectedBuilding is luxuryHomes)
                        {
                            map = simSpace.BuildLuxuryHome(map, (int)x, (int)y);
                            //if the building was not sucsessfully built (due to not having enough money)
                            if (map[(int)x, (int)y] == null)
                            {
                                //Let the user know so and the reason why
                                lblBuilding.Text = "Building Can't Be Built.\r\nDo you have enough money?";
                            }
                        }

                        else if (selectedBuilding is comfortableHomes)
                        {
                            map = simSpace.BuildComfortableHome(map, (int)x, (int)y);
                            //if the building was not sucsessfully built (due to not having enough money)
                            if (map[(int)x, (int)y] == null)
                            {
                                //Let the user know so and the reason why
                                lblBuilding.Text = "Building Can't Be Built.\r\nDo you have enough money?";
                            }
                        }

                        else if (selectedBuilding is AffordableHomes)
                        {
                            map = simSpace.BuildAffordableHome(map, (int)x, (int)y);
                            //if the building was not sucsessfully built (due to not having enough money)
                            if (map[(int)x, (int)y] == null)
                            {
                                //Let the user know so and the reason why
                                lblBuilding.Text = "Building Can't Be Built.\r\nDo you have enough money?";
                            }
                        }

                        else if (selectedBuilding is Office)
                        {
                            map = simSpace.BuildOffice(map, (int)x, (int)y);
                            //if the building was not sucsessfully built (due to not having enough money)
                            if (map[(int)x, (int)y] == null)
                            {
                                //Let the user know so and the reason why
                                lblBuilding.Text = "Building Can't Be Built.\r\nDo you have enough money?";
                            }
                        }

                        else if (selectedBuilding is Store)
                        {
                            map = simSpace.BuildStore(map, (int)x, (int)y);
                            //if the building was not sucsessfully built (due to not having enough money)
                            if (map[(int)x, (int)y] == null)
                            {
                                //Let the user know so and the reason why
                                lblBuilding.Text = "Building Can't Be Built.\r\nDo you have enough money?";
                            }
                        }

                        else if (selectedBuilding is Restaurant)
                        {
                            map = simSpace.BuildRestaurant(map, (int)x, (int)y);
                            //if the building was not sucsessfully built (due to not having enough money)
                            if (map[(int)x, (int)y] == null)
                            {
                                //Let the user know so and the reason why
                                lblBuilding.Text = "Building Can't Be Built.\r\nDo you have enough money?";
                            }
                        }

                        else
                        {
                            map = simSpace.BuildFactory(map, (int)x, (int)y);
                            //if the building was not sucsessfully built (due to not having enough money)
                            if (map[(int)x, (int)y] == null)
                            {
                                //Let the user know so and the reason why
                                lblBuilding.Text = "Building Can't Be Built.\r\nDo you have enough money?";
                            }
                        }

                        //Deselect the selected building
                        selectedBuilding = null;

                        //Refresh the form
                        Refresh();

                        //Toggle the building visiblility
                        ToggleBuildingPictures();
                    }
                }
            }
        }

        //Subprogram for when the picture of the park is clicked on
        private void picPark_Click_1(object sender, EventArgs e)
        {
            //Set the selected building to park
            selectedBuilding = new Park();

            //Update the label to show selected building information to the user
            UpdateBuildingLabel();

            //Toggle the enviromental buildings to no longer show
            ToggleEnviromentalPictures();

            //Refresh the graphics
            Refresh();
        }

        //Subprogram for when the picture of an enviromental facility is clicked on
        private void picEnviromentalFacility_Click_1(object sender, EventArgs e)
        {
            //Set the selected building to enviromental facility
            selectedBuilding = new EnviromentalFacility();

            //Update the label to show selected building information to the user
            UpdateBuildingLabel();

            //Toggle the enviromental buildings to no longer show
            ToggleEnviromentalPictures();

            //Refresh the graphics
            Refresh();
        }

        //Subprogram for when the picture of a school is clicked on
        private void picSchool_Click_1(object sender, EventArgs e)
        {
            //Set the selected building to school
            selectedBuilding = new School();

            //Update the label to show selected building information to the user
            UpdateBuildingLabel();

            //Toggle the essential service to no longer show
            ToggleEssentialServicePictures();

            //Refresh the graphics
            Refresh();
        }

        //Subprogram for when the picture of a medical building is clicked
        private void picMedical_Click_1(object sender, EventArgs e)
        {
            //Set the selected building to medical
            selectedBuilding = new Medical();

            //Update the label to show selected building information to the user
            UpdateBuildingLabel();

            //Toggle the essential service to no longer show
            ToggleEssentialServicePictures();

            //Refresh the graphics
            Refresh();
        }

        //Subprogram for when the picture of a government building is clicked on
        private void picGovernment_Click_1(object sender, EventArgs e)
        {
            //Set the selected building to government building
            selectedBuilding = new Government();

            //Update the label to show selected building information to the user
            UpdateBuildingLabel();

            //Toggle the essential service to no longer show
            ToggleEssentialServicePictures();

            //Refresh the graphics
            Refresh();
        }

        private void picPowerPlant_Click_1(object sender, EventArgs e)
        {
            //Set the selected building to a power plant
            selectedBuilding = new PowerPlant();

            //Update the label to show selected building information to the user
            UpdateBuildingLabel();

            //Toggle the essential service to no longer show
            ToggleEssentialServicePictures();

            //Refresh the graphics
            Refresh();
        }

        //Subprogram for when the picture of an emergency service is clicked on
        private void picEmergencyService_Click_1(object sender, EventArgs e)
        {
            //Set the selected building to an emergency service building
            selectedBuilding = new EmergencyServices();

            //Update the label to show selected building information to the user
            UpdateBuildingLabel();

            //Toggle the essential service to no longer show
            ToggleEssentialServicePictures();

            //Refresh the graphics
            Refresh();
        }

        //Subprogram for when the picture of an affordable home is clicked on
        private void picAffordableHome_Click_1(object sender, EventArgs e)
        {
            //Set the selected building to an affordable home
            selectedBuilding = new AffordableHomes();

            //Update the label to show selected building information to the user
            UpdateBuildingLabel();

            //Toggle the residential pictures to no longer show
            ToggleResidentialPictures();

            //Refresh the graphics
            Refresh();
        }

        //Subprogram for when the picture of a comfortable home is clicked on
        private void picComfortableHome_Click_1(object sender, EventArgs e)
        {
            //Set the selected building to a comfortable home
            selectedBuilding = new comfortableHomes();

            //Update the label to show selected building information to the user
            UpdateBuildingLabel();

            //Toggle the residential pictures to no longer show
            ToggleResidentialPictures();

            //Refresh the graphics
            Refresh();
        }

        //Subprogram for when the picture of a luxary home is clicked on
        private void picLuxaryHome_Click_1(object sender, EventArgs e)
        {
            //Set the selected building to a luxary home
            selectedBuilding = new luxuryHomes();

            //Update the label to show selected building information to the user
            UpdateBuildingLabel();

            //Toggle the residential pictures to no longer show
            ToggleResidentialPictures();

            //Refresh the graphics
            Refresh();
        }

        //Subprogram for when the picture of an office is clicked on
        private void picOffice_Click_1(object sender, EventArgs e)
        {
            //Set the selected building to an office
            selectedBuilding = new Office();

            //Update the label to show selected building information to the user
            UpdateBuildingLabel();

            //Toggle the Commercial pictures to no longer show
            ToggleCommercialPictures();

            //Refresh the graphics
            Refresh();
        }

        //Subprogram for when the picture of a resutaurant is clicked on
        private void picRestaurant_Click_1(object sender, EventArgs e)
        {
            //Set the selected building to a restaurant
            selectedBuilding = new Restaurant();

            //Toggle the Commercial pictures to no longer show
            ToggleCommercialPictures();

            //Update the label to show selected building information to the user
            UpdateBuildingLabel();

            //Refresh the graphics
            Refresh();
        }

        //Subprogram for when the picture of a store is clicked on
        private void picStore_Click_1(object sender, EventArgs e)
        {
            //Set the selected building to a store
            selectedBuilding = new Store();

            //Update the label to show selected building information to the user
            UpdateBuildingLabel();

            //Toggle the Commercial pictures to no longer show
            ToggleCommercialPictures();

            //Refresh the graphics
            Refresh();
        }

        //Subprogram for when the picture of a factory is clicked on
        private void picFactory_Click_1(object sender, EventArgs e)
        {
            //Set the selected building to a factory
            selectedBuilding = new Factory();

            //Update the label to show selected building information to the user
            UpdateBuildingLabel();

            //Toggle the industrial pictures to no longer show
            ToggleIndustrialPictures();

            //Refresh the graphics
            Refresh();
        }

        private void UpdateBuildingLabel()
        {
            lblBuilding.Text = "Building Name: " + selectedBuilding.BuildingName;
            lblBuilding.Text = lblBuilding.Text + "\r\nBuild Cost: " + selectedBuilding.BuildCost;
            lblBuilding.Text = lblBuilding.Text + "\r\nMaintenance Cost: " + selectedBuilding.MaintenanceCost;
            lblBuilding.Text = lblBuilding.Text + "\r\nPower Cost: " + selectedBuilding.PowerCost;
            lblBuilding.Text = lblBuilding.Text + "\r\nPollution Output: " + selectedBuilding.PollutionOutput;
            //If the selected building is a comfortable home
            if (selectedBuilding is comfortableHomes)
            {
                lblBuilding.Text = lblBuilding.Text + "\r\nRevenue Per Thousand People: 100000000";
            }

            //If the selected building is a comfortable home
            else if (selectedBuilding is AffordableHomes)
            {
                lblBuilding.Text = lblBuilding.Text + "\r\nRevenue Per Thousand People: 10000";
            }

            else
            {
                lblBuilding.Text = lblBuilding.Text + "\r\nRevenue: " + selectedBuilding.Revenue;
            }
        }

        private void tmrUpdateLabel_Tick_1(object sender, EventArgs e)
        {
            //Update the labels on the form
            lblPlayer.Text = "Money: " + simSpace.Money;
            lblPlayer.Text = lblPlayer.Text + "\r\nMonth: " + simSpace.Month;
            lblPlayer.Text = lblPlayer.Text + "\r\nPollution: " + simSpace.Pollution;
            lblPlayer.Text = lblPlayer.Text + "\r\nPopulation: " + simSpace.Population;
            lblPlayer.Text = lblPlayer.Text + "\r\nPower: " + simSpace.Power;
            lblPlayer.Text = lblPlayer.Text + "\r\nRevenue: " + simSpace.Revenue;
            lblPlayer.Text = lblPlayer.Text + "\r\nMaintenance Costs: " + simSpace.MaintenanceCosts;
            lblPlayer.Text = lblPlayer.Text + "\r\nHappy Population: " + simSpace.HappyPopulation;
            lblPlayer.Text = lblPlayer.Text + "\r\nScore: " + simSpace.Score;
        }

        private void tmrUpdate_Tick_1(object sender, EventArgs e)
        {
            simSpace.advanceMonth(map);

            //Check if the 60 months has passed
            if (simSpace.Month >= 60)
            {
                //Check if score is less than 0, and if it is, run the end game
                if (simSpace.Score < 0)
                {
                    gameState = GAME_OVER;

                    //Set the form size to 200 x 200
                    this.Width = 200;
                    this.Height = 200;

                    //Set the game over text location and set it to visible
                    lblGameOver.Location = (new Point(this.Width / 30 * 2, this.Height / 3));
                    lblGameOver.Visible = true;

                    //Refresh the graphics
                    Refresh();
                }
            }
        }
    }
}
