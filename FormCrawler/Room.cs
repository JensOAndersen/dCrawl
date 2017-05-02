using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FormCrawler
{
    
    class Room
    {
        public PictureBox pBoxReference { get; set; }
        //defines whether the room is an exit or an entry, in the entire map, there is only one entrance and one exit.
        public bool isEntry { get; set; }
        public bool isExit { get; set; }
        public bool isVisited { get; set; }
        public bool visited { get; set; } = false;
        public int roomID { get; }
        public string roomName { get; }
        public Image RoomImg { get; set; }

        Dictionary<string, bool> neighbours = new Dictionary<string, bool>();

        public Room(int _roomID, string _RoomName, string _incomingDirection)
        {
            //initializes the dictionary for directions
            InitializeDictionary();

            //constructor sets name and ID for the room
            roomID = _roomID;
            roomName = _RoomName;

            //sets the direction of which the former room was
            setAvailableDirection(_incomingDirection);
        }

        private void InitializeDictionary()
        {
            neighbours.Add("north", false);
            neighbours.Add("east", false);
            neighbours.Add("south", false);
            neighbours.Add("west", false);
        }

        //variable to set available directions.
        public void setAvailableDirection(string _direction)
        {
            if(_direction != null)
            {
                neighbours[_direction] = true;
            }
        }

        //returns available paths to the requester
        public Dictionary<string, bool> getAvailablePaths()
        {
            return neighbours;
        }

        public void Visit()
        {
            pBoxReference.BackgroundImage = RoomImg;
        }

        public void setPBoxReference(PictureBox _pBox)
        {
            pBoxReference = _pBox;
        }
    }
}
