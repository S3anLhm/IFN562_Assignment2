using System;
namespace Game
{
	public class SOS : Game
	{
		private int _gameID;

		public override int GameID
		{
			get { return _gameID; }
		}

		public void setGameID(int gameID)
		{
            _gameID = gameID;
        }


		protected override void createGame()
		{
			Console.WriteLine("Hello world");
		}
		

	}
}
