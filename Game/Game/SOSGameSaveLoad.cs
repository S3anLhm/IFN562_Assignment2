using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class SOSGameSaveLoad : GameSaveLoad
    {
        public SOSGameSaveLoad(SOSGameState gameState) : base(gameState)
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
            SOSGameState loadedGameState = JsonConvert.DeserializeObject<SOSGameState>(jsonGameState);
            if (gameState is SOSGameState sosGameState)
            {
                sosGameState.gridNum = loadedGameState.gridNum;
                sosGameState.combinationsChecked = loadedGameState.combinationsChecked;
                sosGameState.player = loadedGameState.player;
                sosGameState.p1Score = loadedGameState.p1Score;
                sosGameState.p2Score = loadedGameState.p2Score;
            }
            //Update the properties of the existing gameState object
            Console.WriteLine("Game loaded successfully from " + fileName);
        }
    }
}
