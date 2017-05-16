using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace FormCrawler
{
    public partial class MainGame : Form
    {
        //position starts for the map and player characters.
        public int topPosStart { get; set; } = 40;
        public int leftPosStart { get; set; } = 340;

        //holds the variables to declare the map-size, set when the game opens
        public int mCol { get; set; } = 0;
        public int mRow { get; set; } = 0;

        //tilesize for the map, UNTIL FURTHER NOTICE, DONT CHANGE, YOU WILL HAVE TO CHANGE THE PNG SIZE TOO
        public int tileSize { get; set; } = 64;

        public bool mapIsSet { get; set; }

        //variable to hold the "CreateMap class", if the main game is to refer to the map, refer to this variable.
        Room[,] map { get; set; }

        //reference to the dungeon explorer class, allows movement in the rooms
        DungeonExplorer dExplorer {get; set;}

        //player variable
        Player curPlayer = new Player("The Hero");

        //variable to hold the textbox component, exposes it to other classes so they can send messages to the main window.
        public TextBox roomCom;

        //dictionary to match open paths with 
        Dictionary<string, string> pngNames = new Dictionary<string, string> {
            { "east","East.png" },
            { "west","West.png" },
            { "north","North.png" },
            { "south","South.png" },
            { "northeast","NorthEast.png" },
            { "northsouth","NorthSouth.png" },
            { "northwest","NorthWest.png" },
            { "eastwest","EastWest.png" },
            { "southwest","SouthWest.png" },
            { "eastsouth","SouthEast.png" },
            { "", "black.png" }
        };

        public MainGame()
        {
            //if the values for rows and columns of the map arent set, a new window is opened 
            //which asks you to to set the columns and rows of the map
            PickMapSize mapSizeForm = new PickMapSize(this);
            if(mCol == 0 && mRow == 0)
            {
                mapSizeForm.Show();
            }

            InitializeComponent();
        }

        //Runs methods that creates the map.
        public void CreateMap()
        {
            roomCom = RoomCommunication;

            map = new CreateMapArray(mCol,mRow).ReturnRoomMap();

            //runs the PopulateMap function, which populates the map
            map = new PopulateMap(map).getPopulatedMap();

            //generate the view of the map
            PlaceMapOnForm();

            //starts the exploration
            dExplorer = new DungeonExplorer(this, map, curPlayer);

            //this is a hack, its the players "icon", it brings it to the front, 
            Control[] pBox = Controls.Find("player",true);
            pBox[0].BringToFront();
            pBox[0].BackColor = Color.Transparent;
        }

        private void PlaceMapOnForm()
        {
            PictureBox pBox;

            //these two values needs to be changed if you want the map to spawn elsewhere

            var exeDir = AppDomain.CurrentDomain.BaseDirectory;
            var imgDir = Path.Combine(exeDir, "../../Img");
            var imgPath = Path.Combine(imgDir, "north.png");
            var emptyPath = Path.Combine(imgDir, "black.png");

            //loops through the entire array and places images based on the content of the room
            for(int row = 0; row < map.GetLength(1); row++)
            {
                for (int col = 0; col < map.GetLength(0); col++)
                {
                    string RoomID = "";
                    string whatImg = "";
                    Image roomImg;
                    Image emptyImg = Image.FromFile(emptyPath);
                    
                    
                    if (map[col, row] == null)
                    {
                        //not used
                    } else
                    {
                        //loops through available directions in the room, and adds them to a string as they match
                        Room CurRoom = map[col, row];

                        RoomID = CurRoom.roomID.ToString();

                        //this loop breaks completely if you change the file names, or the names in the dictionary where the filenames are listed
                        foreach (var key in CurRoom.getAvailablePaths())
                        {
                            if (key.Value == true)
                            {
                                whatImg += key.Key;
                            }
                        }
                    }

                    //creates an imagepath
                    imgPath = Path.Combine(imgDir, pngNames[whatImg]);

                    roomImg = Image.FromFile(imgPath);

                    //creates the new pictureBox
                    pBox = new PictureBox {
                        Name = RoomID,
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(leftPosStart + (col * tileSize), topPosStart + (row * tileSize)),
                        BackgroundImage = Image.FromFile(emptyPath)
                    };

                    this.Controls.Add(pBox);

                    //adds reference to the picture box in the corresponding room.
                    if (map[col,row] != null)
                    {
                        map[col, row].RoomImg = roomImg;
                        map[col, row].setPBoxReference(pBox);
                    }
                }
            }

        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            dExplorer.Explore("east");
        }

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            dExplorer.Explore("west");
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            dExplorer.Explore("north");
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            dExplorer.Explore("south");
        }

        private void MapPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void LookForItems_Click(object sender, EventArgs e)
        {
            dExplorer.LookForItems();
        }
    }
}
