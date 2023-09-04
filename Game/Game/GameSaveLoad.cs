using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class GameSaveLoad : IGameSaveLoad
    {
        protected GameState gameState;

        public GameSaveLoad(GameState gameState)
        {
            this.gameState = gameState;
        }

        public virtual void Save(string fileName)
        {
            // Common save logic
        }

        public virtual void Load(string fileName)
        {
            // Common load logic
        }
    }

}
