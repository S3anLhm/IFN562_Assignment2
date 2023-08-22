using System;

namespace Assignment2
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