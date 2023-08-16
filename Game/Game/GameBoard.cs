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
				bool success = int.TryParse(gameChoice, out gameID);


				if(success && (gameID == 1 || gameID == 2))
				{
                    createGame(gameID);
				}
				else
				{
					Console.WriteLine("Please enter the correct option");
				}
				
               


                //Ask user for gameOption

                // Display everything

                //Startgame

            }
		}

		public void createGame(int gameID)
		{
			if(gameID == 1)
			{
				SOS sos = new SOS();
			}else if(gameID == 2)
			{
				//ConnectFour;
			}
		}
	}
}

//User choose SOS
//Game detects user's game option
//Pulls game from SOS -> Print grid

