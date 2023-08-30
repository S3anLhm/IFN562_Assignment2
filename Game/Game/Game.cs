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
        //work now?
        public string player;
        public Player player1;
        public Player player2;
        public void playGame()
        {
            chooseOpponent(out player1, out player2);
            displayGame(player1, player2);
            checkWin(player);
            getRemainingMoves();
            resetAll();
        }
        protected abstract void chooseOpponent(out Player player1, out Player player2);
        protected abstract void displayGame(Player player1, Player player2);
        protected abstract int checkWin(string player);
        protected abstract int getRemainingMoves();
        protected abstract void resetAll();
    }
}
