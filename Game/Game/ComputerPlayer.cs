using PlayerToWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerToWork
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
            ConsoleKey[] arrowKeys = { ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.Enter };
            int randomIndex = random.Next(arrowKeys.Length);
            return new ConsoleKeyInfo('\0', arrowKeys[randomIndex], false, false, false);
        }
    }
}
