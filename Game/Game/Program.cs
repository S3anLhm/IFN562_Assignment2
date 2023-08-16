using System;

namespace Game
{
    class Program
    {
        static void Main(String[] args)
        {
            GameBoard mySingleton = GameBoard.Instance;
            mySingleton.startGame();


    

        }
    }
}