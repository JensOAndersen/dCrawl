using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace FormCrawler
{
    class DungeonExplorer
    {
        PictureBox playerBox;
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
            CreatePlayer();
            CommunicateAvailableDirections(curRoom);
        }

        public void CreatePlayer()
        {
            //variables to get the player image
            var exeDir = AppDomain.CurrentDomain.BaseDirectory;
            var imgDir = Path.Combine(exeDir, "../../Img");
            var imgPath = Path.Combine(imgDir, "player.png");

            Image player = Image.FromFile(imgPath);

            playerBox = new PictureBox
            {
                Name = "player",
                Size = new Size(32, 32),
                Location = new Point(mGame.leftPosStart + 16 + (curPlayer.colPos*mGame.tileSize), mGame.topPosStart + 16 + (curPlayer.rowPos * mGame.tileSize)),
                //Location = new Point(30,30),
                BackgroundImage = player,
                
                //Doesnt work? V
                //BackColor = Color.Transparent
            };
            mGame.Controls.Add(playerBox);

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
            playerBox.Location = new Point(mGame.leftPosStart + 16 + (curPlayer.colPos * mGame.tileSize), mGame.topPosStart + 16 + (curPlayer.rowPos * mGame.tileSize));
            CommunicateAvailableDirections(curRoom);
        }

        private void CommunicateAvailableDirections(Room _curRoom)
        {
            Dictionary<string, bool> curAvDir = _curRoom.getAvailablePaths();
            List<string> availableDir = new List<string>();

            string OutPut = "";

            int exits = 0;

            //Makes a list of available exits from the room
            foreach (var key in curAvDir)   
            {
                if (key.Value)
                {
                    exits++;
                    availableDir.Add(key.Key);
                }
            }

            //makes a string that is later sent to the room communication textbox
            OutPut = "You have entered the room, the room has " + exits + " exit(s)\n";
            OutPut += "To the ";
            if (exits > 1)
            {
                OutPut += availableDir[0];
                for(int i = 0; i < availableDir.Count; i++)
                {
                    if(i != 0)
                    {
                        OutPut += " and to the " + availableDir[i];
                    }
                }
            } else
            {
                OutPut += availableDir[0] + ".";
            }
            
            //the string with available directions is added to the room communication
            mGame.roomCom.Text = OutPut;
        }

        public void LookForItems()
        {
            string output = "";
            if(curRoom.goldInRoom > 0)
            {
                output = $"You picked up {curRoom.goldInRoom} gold, it was added to your wallet";
                curPlayer.money += curRoom.goldInRoom;
                curRoom.goldInRoom = 0;
            } else
            {
                output = "\nThere was no gold in the room";
            }
            mGame.roomCom.Text += output;
        }
    }
}
