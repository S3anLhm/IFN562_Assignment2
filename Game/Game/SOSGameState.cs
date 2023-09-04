using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class SOSGameState : GameState
    {
        public char[] gridNum { get; set; }
        public bool[] combinationsChecked { get; set; }
        public int player { get; set; }
        public int p1Score { get; set; }
        public int p2Score { get; set; }
        public SOSGameState()
        {
            gridNum = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            combinationsChecked = new bool[] { false, false, false, false, false, false, false, false };
            player = 1;
            p1Score = 0;
            p2Score = 0;
        }
    }
}
