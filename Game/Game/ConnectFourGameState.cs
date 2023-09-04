using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class ConnectFourGameState : GameState
    {
        public string[,] board { get; set; }
        public string currentPlayer { get; set; }
        public int currentRow { get; set; }
        public int currentColumn { get; set; }
        public ConnectFourGameState()
        {
            board = new string[6, 7]
            {
                {"-", "-", "-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-", "-", "-"},
            };
            currentPlayer = "O";
            currentRow = 0;
            currentColumn = 0;
        }
    }
}
