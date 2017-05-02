using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormCrawler
{
    class Player
    {
        public int colPos { get; set; }
        public int rowPos { get; set; }

        public string playerName { get; set; }
        public int money { get; set; }

        public Player(string _name)
        {
            playerName = _name;
            colPos = 0;
            rowPos = 0;
        }
    }
}
