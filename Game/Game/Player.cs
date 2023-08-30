using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public abstract class Player
    {
        public int _PlayerID { get; set; }
        public string Symbol { get; set; }
        public Player(int _playerID)
        {
            _PlayerID = _playerID;
        }
        public abstract void moveRightConnectFour(ref int currentColumn);
        public abstract void moveLeftConnectFour(ref int currentColumn);
        public abstract void makeMoveConnectFour(ref int currentColumn, ref string[,] board, ref string currentPlayer);
    }
}
