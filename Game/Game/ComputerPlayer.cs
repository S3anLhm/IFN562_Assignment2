using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class ComputerPlayer : Player
    {
        //storing an instance of the game
        public int _PlayerID { get; private set; }
        public string Symbol { get; private set; }
        public ComputerPlayer(int _playerID) : base(_playerID)
        {
            _PlayerID = _playerID;
        }
        public ConsoleKeyInfo SimulateRandomKeyPress()
        {
            Random random = new Random();
            ConsoleKey[] arrowKeys = { ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.Enter };
            int randomIndex = random.Next(arrowKeys.Length);
            return new ConsoleKeyInfo('\0', arrowKeys[randomIndex], false, false, false);
        }
        public override void moveRightConnectFour(ref int currentColumn)
        {
            currentColumn++;
            currentColumn = (currentColumn >= 7) ? 0 : currentColumn;
        }
        public override void moveLeftConnectFour(ref int currentColumn)
        {
            currentColumn--;
            currentColumn = (currentColumn < 0) ? 6 : currentColumn;
        }
        public override void makeMoveConnectFour(ref int currentColumn, ref string[,] board, ref string currentPlayer)
        {
            for (int row = 5; row >= 0; row--)
            {
                if (board[row, currentColumn] != "X" && board[row, currentColumn] != "O")
                {
                    board[row, currentColumn] = currentPlayer;
                }
                else if (row == 0 && (board[0, currentColumn] == "X" || board[0, currentColumn] == "O"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This already filled");
                    Console.ResetColor();
                    Task.Delay(2000).Wait();
                }
            }
        }
    }
}
