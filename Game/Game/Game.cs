using System;
namespace Game
{
    public abstract class Game
    {
        private int _gameID;

        public abstract int GameID { get; }

        


        protected abstract void createGame();
       


    }

}

