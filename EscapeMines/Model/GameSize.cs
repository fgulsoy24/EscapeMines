using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Model
{
    public class GameSize
    {
        private int _lineSizeX;
        private int _lineSizeY;

        public int LineSizeX
        {
            get => _lineSizeX;
            set => _lineSizeX = value;
        }

        public int LineSizeY
        {
            get => _lineSizeY;
            set => _lineSizeY = value;
        }
    }
}
