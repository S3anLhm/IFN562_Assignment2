using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class GameBoard
    {
        private GameBoard()
        {

        }

        private static GameBoard instance;

        public static GameBoard Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameBoard();
                }
                return instance;
            }
        }

        public void startGame()
        {   
            while (true)
            {
                Console.WriteLine("Please enter the game you want to play 1.SOS 2.ConnectFour:");
                string gameChoice = Console.ReadLine();

                //Create GameID
                int gameID;
                bool success = int.TryParse(gameChoice, out gameID);

                Game game = null;

                if (success && (gameID == 1))
                {
                    game = new SOS(gameID);
                }
                else
                {
                    Console.WriteLine("Please enter the correct option");
                }

                //Startgame and display everything
                if (game != null)
                {
                    Console.Clear();
                    game.playGame();
                }
                else
                {
                    Console.WriteLine("Game not selected.");
                }
            }
        }
    }
}
