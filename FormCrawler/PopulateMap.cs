using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormCrawler
{
    class PopulateMap
    {
        private Room[,] map;

        Random rnd = new Random();

        public PopulateMap(Room[,] _map)
        {
            map = _map;

            AssignRoomsToMap();
        }

        private void AssignRoomsToMap()
        {
            //variables to hold columns and rows of the map, used to loop through the array and assign rooms.
            int columns = map.GetLength(0);
            int rows = map.GetLength(1);

            //where we are in the "map".
            int colPos = 0;
            int rowPos = 0;

            //variables to hold the current and next rooms, the current room is the one being 
            //the new room is the next room to be created.
            Room currentRoom;
            Room newRoom;

            //bool that is true while rooms are being placed
            bool placingRooms = true;

            //amount of rooms made
            int roomID = 0;

            //holder variable for the neighbours
            Dictionary<string, Room> neighbours = new Dictionary<string, Room>();

            
            //sets the first room.
            currentRoom = new Room(roomID, "The First Room", null);
            currentRoom.isEntry = true;
            
            //main loop of the method, this loop runs until it is impossible to place more rooms on the map.
            while (placingRooms)
            {
                //eligible directions for a new room, needs to be within the loop because it needs to be reset every time the placement loops
                List<string> validDirections = new List<string>();

                //holds the chosen dir
                string chosenDir;

                //returns a dictionary of directions and what is in the direction. The direction is not entered if it is out of bounds of the map array
                neighbours = LookThroughWalls(colPos, rowPos, map);

                //add Null directions to a list
                foreach(var item in neighbours)
                {
                    if(item.Value == null)
                    {
                        validDirections.Add(item.Key);
                    }
                }

                if(validDirections.Count == 0)
                {
                    placingRooms = false;
                    currentRoom.isExit = true;
                    map[colPos, rowPos] = currentRoom;
                    break;
                }

                //chooses a direction
                chosenDir = validDirections[rnd.Next(0, validDirections.Count)];

                //sets the exit path of the current room
                currentRoom.setAvailableDirection(chosenDir);
                
                //adds a new room
                map[colPos, rowPos] = currentRoom;

                //increments the colPos and rowPos values to reflect what direction was chosen for the next room (to be used in the next loopthrough)
                if (chosenDir == "east" || chosenDir == "west")
                {
                    colPos += dirStringToValue(chosenDir);
                }
                else if (chosenDir == "north" || chosenDir == "south")
                {
                    rowPos += dirStringToValue(chosenDir);
                }

                //sets the entry direction of the new room, gives it a name and ID
                newRoom = new Room(roomID+1, roomID.ToString(), InvertDirection(chosenDir));
                
                // sets the current room to the new room
                currentRoom = newRoom;
                
                //i'm incrementing lastly, because otherwise the game would break when reaching the ends of the arrays
                roomID++;

            }
        }

        //return method, returns the map, with added rooms, to the main class
        public Room[,] getPopulatedMap()
        {
            return map;
        }

        //invert method to invert direction string, used for making an entrance in a new room.
        private string InvertDirection(string _dir)
        {
            switch (_dir)
            {
                case "north":
                    return "south";
                case "east":
                    return "west";
                case "south":
                    return "north";
                case "west":
                    return "east";
                default:
                    return _dir;
            }
        }

        //this method is a bit obscure, but basically what it does, is that it looks around, and returns a dictionary of neighbouring rooms, 
        //what the direction is, and what the contents are
        public Dictionary<string,Room> LookThroughWalls(int __colPos, int __rowPos, Room[,] _map)
        {
            string[] directions = { "north", "east", "south", "west" };

            Dictionary<string, Room> nextDoorRooms = new Dictionary<string, Room>();

            List<string> dirList = new List<string>();

            //loops through all directions
            for(int i = 0; i < directions.Length; i++)
            {
                int _colPos = __colPos;
                int _rowPos = __rowPos;
                
                string curDir = directions[i];

                //if sentences decides whether you use the column or the row variable as direction.
                if(curDir == "east" || curDir == "west")
                {
                    _colPos += dirStringToValue(curDir);
                } else if (curDir == "north" || curDir == "south")
                {
                    _rowPos += dirStringToValue(curDir);
                }

                //sees if the returned direction is within bounds of the 2d-array.
                if(_colPos >= 0 && _rowPos >= 0 && _colPos < _map.GetLength(0) && _rowPos < _map.GetLength(1))
                {
                    //checks if the room is null or not.
                    if(_map[_colPos,_rowPos] == null)
                    {
                        nextDoorRooms.Add(curDir, null);
                    }
                    else
                    {
                        nextDoorRooms.Add(curDir, _map[_colPos, _rowPos]);
                    } 
                }

            }
            
            return nextDoorRooms;
        }



        private int dirStringToValue(string _dir)
        {
            if (_dir == "north" || _dir == "west")
            {
                return -1;
            } else if (_dir == "south"|| _dir == "east")
            {
                return 1;
            }
            return 0;
        }
    }
}
