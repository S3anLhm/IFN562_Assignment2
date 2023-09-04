using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class ConnectFourGameSaveLoad : GameSaveLoad
    {
        public ConnectFourGameSaveLoad(ConnectFourGameState gameState) : base(gameState)
        {
        }

        public override void Save(string fileName)
        {
            string jsonGameState = JsonConvert.SerializeObject(gameState);

            // Write the JSON data to the specified file
            File.WriteAllText(fileName, jsonGameState);
            Console.WriteLine("Game saved successfully to " + fileName);
        }

        public override void Load(string fileName)
        {
            // Read the JSON data from the specified file
            string jsonGameState = File.ReadAllText(fileName);

            // Deserialize the JSON data into gameState
            ConnectFourGameState loadedGameState = JsonConvert.DeserializeObject<ConnectFourGameState>(jsonGameState);
            if (gameState is ConnectFourGameState connectFourGameState)
            {
                connectFourGameState.board = loadedGameState.board;
                connectFourGameState.currentPlayer = loadedGameState.currentPlayer;
                connectFourGameState.currentRow = loadedGameState.currentRow;
                connectFourGameState.currentColumn = loadedGameState.currentColumn;
            }
            //Update the properties of the existing gameState object
            Console.WriteLine("Game loaded successfully from " + fileName);
        }
    }
}
