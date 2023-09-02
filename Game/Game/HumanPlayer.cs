using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class HumanPlayer : Player
    {
        public int _PlayerID { get; private set; }

        public HumanPlayer(int _playerID) : base(_playerID)
        {
            _PlayerID = _playerID;
        }


    }


}
