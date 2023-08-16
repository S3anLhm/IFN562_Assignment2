using System;
namespace Game
{
    internal abstract class Game
    {
        public void game()
        {
            CreateGame();
        }

        protected abstract void CreateGame();
    }
  

}

