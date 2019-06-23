using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeMines.Model;
using EscapeMines.Service;
namespace EscapeMines.Service.impl
{
    public class GameSettingsService : IGameSettingsService
    {
        private readonly IReadDataService _readDataService;

        /// <summary>
        /// Game settings class constructor
        /// </summary>
        /// <param name="readDataService">Construct readDataService for get data from file</param>
        public GameSettingsService(IReadDataService readDataService)
        {
            _readDataService = readDataService;
        }
        /// <summary>
        /// Get file and fill the objects.
        /// </summary>
        /// <param name="filePath">It is the game settings file path</param>
        public GameContext PopulateGameSettings(string filePath)
        {
            if (filePath.Equals(string.Empty))
            {
                return null;
            }
            var lines = _readDataService.GetLines(filePath);

            var game = new GameContext
            {
                GameSize = GetGameSize(_readDataService.GetNumbers(lines[0])),
                MineCoordinates = GetMineCoordinates(lines[1]),
                ExitPoint = GetExitPoint(_readDataService.GetNumbers(lines[2])),
                StartPosition = GetStartPosition(lines[3]),
                CommandList = GetGameCommandList(filePath)
            };

            return game;
        }
        private GameSize GetGameSize(IReadOnlyList<int> list)
        {
            var gameSize = new GameSize
            {
                LineSizeX = list[0],
                LineSizeY = list[1]
            };
            return gameSize;
        }
        private GameCoordinate GetExitPoint(IReadOnlyList<int> list)
        {
            var exitPoint = new GameCoordinate
            {
                CoordX = list[0],
                CoordY = list[1]
            };
            return exitPoint;
        }
        private TurtlePosition GetStartPosition(string line)
        {
            var coordinates = _readDataService.GetCharactersFromLine(line);

            var startPosition = new TurtlePosition
            {
                CoordX = Convert.ToInt16(coordinates[0]),
                CoordY = Convert.ToInt16(coordinates[1]),
                Direction = coordinates[2]
            };
            return startPosition;

        }
        private List<GameCoordinate> GetMineCoordinates(string line)
        {

            var list = _readDataService.GetPairNumbersList(line);

            var mineCoordinates = new List<GameCoordinate>();

            foreach (var item in list)
            {
                var mine = new GameCoordinate
                {
                    CoordX = item.Item1,
                    CoordY = item.Item2
                };
                mineCoordinates.Add(mine);
            }

            return mineCoordinates;
        }
        private List<List<string>> GetGameCommandList(string gameSettings)
        {
            var lines = _readDataService.GetLines(gameSettings);

            var commandList = new List<List<string>>();
            var i = 0;
            foreach (var line in lines)
            {
                if (i > 3)
                {
                    var commands = _readDataService.GetCharactersFromLine(line);
                    commandList.Add(commands);
                }

                i++;
            }

            return commandList;
        }
    }
}
