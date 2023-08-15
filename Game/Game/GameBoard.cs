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
				Console.WriteLine("Please enter the game you want to play:");
				string gameChoice = Console.ReadLine();

				Console.WriteLine("Thank you");
				break;
			}
		}
	}
}

