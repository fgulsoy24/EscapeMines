using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Model
{
    public class TurtlePosition : GameCoordinate
    {
        private string _direction;

        public string Direction
        {
            get => _direction;
            set => _direction = value;
        }
    }
    public class CurrentlyPositionAndStatus : TurtlePosition
    {
        private int _status;
        public int Status
        {
            get => _status; set => _status = value;
        }
    }
}
