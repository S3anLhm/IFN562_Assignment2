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
        public char[] grid;
        public void playGame()
        {
            displayGame();
     
            //getRemainingMoves(grid);
            //resetAll();
        }
        protected abstract void displayGame();
        //protected abstract int checkWin(string player, char[] grid);
        //protected abstract int getRemainingMoves(char[] grid);
       // protected abstract void resetAll();
    }
}
