using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerToWork
{
    public abstract class Player
    {
        public int _PlayerID { get; set; }
        public Player(int _playerID)
        {
            _PlayerID = _playerID;
        }
    }
}
