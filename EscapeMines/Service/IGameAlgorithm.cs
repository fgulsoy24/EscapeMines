using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeMines.Model;

namespace EscapeMines.Service
{
    internal interface IGameAlgorithm
    {
        bool CalculateGameResults(GameContext gameContext);
    }
}
