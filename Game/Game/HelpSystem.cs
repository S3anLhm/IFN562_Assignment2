using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class HelpSystem
    {
        private int _gameID;

        public HelpSystem(int gameID)
        {
            _gameID = gameID;
        }

        public void displayExampleSOS(int gameID)
        {
            if (gameID == 1)
            {

                Console.WriteLine(displaySOSBoard);

            }
            else
            {
                Console.WriteLine(displayConnectFourBoard);
            }
        }


        public void displaySOSBoard()
        {

            char[] gridNum = { '0', 'S', 'O', 'S', 'S', 'S', 'O', 'S', 'S', 'S' };
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gridNum[1], gridNum[2], gridNum[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gridNum[4], gridNum[5], gridNum[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gridNum[7], gridNum[8], gridNum[9]);
            Console.WriteLine("     |     |      ");

            Console.WriteLine("1.The objective of the game SOS is to create as many SOS sequences as possible by placing S and O letters on a grid.");
            Console.WriteLine("2.Each player decides which letter they will use,S or O.");
            Console.WriteLine("3.Player can make a move again once they have scored a point.");
            Console.WriteLine("4.The game ends when there are no empty cells left on the grid or when a predetermined number of rounds have been played. The player with the most points is declared the winner.");
        }

        public void displayConnectFourBoard()
        {
            Console.WriteLine("- O - - - - -");
            Console.WriteLine("- X X - - - -");
            Console.WriteLine("- X X X - O -");
            Console.WriteLine("- X O O X O -");
            Console.WriteLine("X O O O X O -");
            Console.WriteLine("O X X O O O X");

            Console.WriteLine("1. The objective of the game ConnectFour is to create a sequence with four of your letters faster than your opponent.");
            Console.WriteLine("2. You can only place your letter at the bottom of the grid first.");
            Console.WriteLine("3. The game ends when a player makes four in a row whether vertically, horizontally, top-left descending diagonally and bottom-left ascending diagonally.");
        }
    }
}