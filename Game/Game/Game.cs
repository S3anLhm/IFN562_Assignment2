using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public abstract class Game
    {
        public int _GameID { get; private set; }

        public Game(int _gameID)
        {
            _GameID = _gameID;
        }

        public void playGame()
        {
            displayGame();
        }

        protected abstract void displayGame();
    }
}
