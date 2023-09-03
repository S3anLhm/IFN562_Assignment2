using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class ComputerPlayer : Player
    {
        public int _PlayerID { get; private set; }
        public ComputerPlayer(int _playerID) : base(_playerID)
        {
            _PlayerID = _playerID;
        }
        public ConsoleKeyInfo randomMoveConnectFour()
        {
            Random random = new Random();
            ConsoleKey[] arrowKeys = { ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.Enter };
            int randomIndex = random.Next(arrowKeys.Length);
            //(Unicode character that corresponds to the pressed key, ConsoleKey enumeration, bool Shift, bool Alt, bool Ctrl)
            return new ConsoleKeyInfo('\0', arrowKeys[randomIndex], false, false, false);
        }
        public void randomMoveSOS(char[] gridNum)
        {
            Random random = new Random();
            char randomChar = random.Next(2) == 0 ? 'S' : 'O';
            int move;

            while (true)
            {
                move = random.Next(1, 10);
                if ((gridNum[move] != 'S' && gridNum[move] != 'O'))
                {
                    gridNum[move] = randomChar;
                    break;
                }
            }

            Console.WriteLine("Computer has placed {0} at {1}.", randomChar, move);
            Console.WriteLine("\n");
        }
    }
}
