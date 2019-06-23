using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Model
{
    public class GameContext
    {
        public GameSize GameSize { get; set; }
        public List<MineCoordinates> MineCoordinates { get; set; }
        public ExitPoint ExitPoint { get; set; }
        public StartPosition StartPosition { get; set; }
    }

}

