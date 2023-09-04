using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public interface IGameSaveLoad
    {
        void Save(string fileName);
        void Load(string fileName);
    }

}
