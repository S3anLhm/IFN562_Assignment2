using System;
namespace Game
{
	public class GameBoard
	{
		private static GameBoard instance = null;

		private GameBoard()
		{

		}

		public static GameBoard Instance
		{
			get {
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
				Console.WriteLine("Please enter the game you want to play 1.SOS 2.ConnectFour :");
				string gameChoice = Console.ReadLine();

				//Create GameID
				int gameID;
				dynamic x = null;
				bool success = int.TryParse(gameChoice, out gameID);


				if(success && (gameID == 1))
				{
					x = new SOS();
					Console.WriteLine("Thank you for choosing to play SOS!");


				}else if (success && (gameID == 2)){
					x = new Connect4();
                    Console.WriteLine("Thank you for choosing to play Connect 4!");
                }

                else
				{
					Console.WriteLine("Please enter the correct option");
				}

				x.game();
				
            }
		}

	}
}

//User choose SOS
//Game detects user's game option
//Pulls game from SOS -> Print grid

