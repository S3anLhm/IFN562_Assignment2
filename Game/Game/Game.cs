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

        public string player;
        public void playGame()
        {
            displayGame();
            checkWin(player);
            getRemainingMoves();
            resetAll();
        }
        protected abstract void displayGame();
        protected abstract int checkWin(string player);
        protected abstract int getRemainingMoves();
        protected abstract void resetAll();
    }
}
