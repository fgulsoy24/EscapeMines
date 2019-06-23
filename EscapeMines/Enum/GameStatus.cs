using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Model
{
    public enum GameStatus
    {
        NotStarted = 0,
        Running = 1,
        Succeed = 2,
        MineHit = 3,
        StillInDanger = 4
    }
}
