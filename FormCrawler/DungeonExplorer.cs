using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormCrawler
{
    class DungeonExplorer
    {
        Room[,] map;
        public DungeonExplorer(MainGame _mGame, Room[,] _map)
        {
            map = _map;
        }
    }
}
