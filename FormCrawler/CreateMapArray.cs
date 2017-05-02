using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormCrawler
{
    class CreateMapArray
    {
        private Room[,] roomMap { get; }

        //Constructor for the class, creates a map array 
        public CreateMapArray(int _col, int _row)
        {
            roomMap = new Room[_col, _row];
        }

        //return method
        public Room[,] ReturnRoomMap()
        {
            return roomMap;
        }
    }
}
