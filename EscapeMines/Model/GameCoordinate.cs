using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Model
{
    public class GameCoordinate
    {
        private int _coordX;
        private int _coordY;

        public int CoordX
        {
            get => _coordX;
            set => _coordX = value;
        }

        public int CoordY
        {
            get => _coordY;
            set => _coordY = value;
        }
      
    }
}
