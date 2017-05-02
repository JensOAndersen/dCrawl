using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormCrawler
{

    public partial class PickMapSize : Form
    {
        //make lists to populate comboboxes
        List<int> mapSize = new List<int>();

        MainGame mGame;

        //constructor
        public PickMapSize(MainGame _mGame)
        {
            InitializeComponent();

            //puts the window on top.
            this.TopMost = true;

            //initilializes the map-combobox lists, they dont have any values before this code is run
            InitializeMaplists();

            //"this" is passed from "MainGame.cs"
            mGame = _mGame;
        }

        public void InitializeMaplists()
        {
            //the for loop populates a list with numbers, from 3 to 10, to avoid people making a map that is either to small or too large
            for(int i = 3; i < 10; i++)
            {
                mapSize.Add(i);
            }

            //foreach loop that loops through the list above, and adds the "key" column of the list to the combobox.
            foreach(int map in mapSize)
            {
                MapColumns.Items.Add(map);
                MapRows.Items.Add(map);
            }

            //sets the default selected index of the combobox
            MapColumns.SelectedIndex = 0;
            MapRows.SelectedIndex = 0;
        }

        private void PickSizeLabel_Click(object sender, EventArgs e)
        {

        }

        private void PickMapSize_Load(object sender, EventArgs e)
        {

        }

        //this event is fired when the submit button is clicked.
        private void SizeSubmit_Click(object sender, EventArgs e)
        {
            //uses a static variable of the maingame.cs class to set the amount of rows and columns of the map.
            mGame.mCol = int.Parse(MapColumns.Text);
            mGame.mRow = int.Parse(MapRows.Text);

            //fires the createmap method in 
            mGame.CreateMap();

            //closes the pickmapsize form after submit is clicked, and makes it possible for the player to continue with the game.
            mGame.mapIsSet = true;
            this.Close();
        }

        private void MapColumns_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MapRows_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
