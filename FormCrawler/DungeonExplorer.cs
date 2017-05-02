using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormCrawler
{
    class DungeonExplorer
    {

        MainGame mGame;
        Room[,] map;
        Room curRoom;
        Player curPlayer;
        public DungeonExplorer(MainGame _mGame, Room[,] _map, Player _player)
        {
            mGame = _mGame;
            map = _map;
            curPlayer = _player;

            mGame.roomCom.Text = curPlayer.colPos.ToString();
            curRoom = map[curPlayer.colPos, curPlayer.rowPos];

            curRoom.Visit();
            Communicate(curRoom);
        }

        public void Explore(string _Dir)
        {
            if (curRoom.getAvailablePaths()[_Dir])
            {
                if(_Dir == "north")
                {
                    curPlayer.rowPos -= 1;
                    MovePlayer();
                } else if (_Dir == "east")
                {
                    curPlayer.colPos += 1;
                    MovePlayer();
                }
                else if (_Dir == "south")
                {
                    curPlayer.rowPos += 1;
                    MovePlayer();
                }
                else if (_Dir == "west")
                {
                    curPlayer.colPos -= 1;
                    MovePlayer();
                }
            }
        }

        private void MovePlayer()
        {
            curRoom = map[curPlayer.colPos, curPlayer.rowPos];
            curRoom.Visit();
            Communicate(curRoom);
        }

        private void Communicate(Room _curRoom)
        {
            Dictionary<string, bool> curAvDir = _curRoom.getAvailablePaths();
            int exits = 0;


            foreach (var key in curAvDir)
            {
                if (key.Value)
                {
                    exits++;
                }
            }
            string OutPut = "You have entered the room, the room has " + exits + " exit(s)\n";

            mGame.roomCom.AppendText(OutPut);
        }
    }
}
