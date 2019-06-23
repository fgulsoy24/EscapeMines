using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeMines.Model;
using EscapeMines.Service;
namespace EscapeMines.Service.impl
{
    public class GameSettingsService
    {
        private readonly IReadDataService _readDataService;

        public GameSettingsService(IReadDataService readDataService)
        {
            _readDataService = readDataService;
        }

        public GameContext PopulateGameSettings(string filePath)
        {
            var lines = _readDataService.GetLines(filePath);

            var game = new GameContext
            {
                GameSize = GetGameSize(_readDataService.GetNumbers(lines[0])),
                MineCoordinates = GetMineCoordinates(lines[1]),
                ExitPoint = GetExitPoint(lines[2]),
                StartPosition = GetStartPosition(lines[3])
            };

            return game;
        }
        private static GameSize GetGameSize(IReadOnlyList<int> list)
        {
            var gameSize = new GameSize
            {
                LineSizeX = list[0],
                LineSizeY = list[1]
            };
            return gameSize;
        }
        private ExitPoint GetExitPoint(string line)
        {
            var list = _readDataService.GetNumbers(line);
            var exitPoint = new ExitPoint
            {
                CoordX = list[0],
                CoordY = list[1]
            };
            return exitPoint;
        }
        private StartPosition GetStartPosition(string line)
        {
            var coordinates = _readDataService.GetCharactersFromLine(line);

            var startPosition = new StartPosition
            {
                CoordX = Convert.ToInt16(coordinates[0]),
                CoordY = Convert.ToInt16(coordinates[1]),
                Direction = coordinates[2].ToString()
            };
            return startPosition;

        }
        private List<MineCoordinates> GetMineCoordinates(string line)
        {

            var list = _readDataService.GetNumberList(line);

            var mineCoordinates = new List<MineCoordinates>();

            foreach (var item in list)
            {
                var mine = new MineCoordinates
                {
                    CoordX = item.Item1,
                    CoordY = item.Item2
                };
                mineCoordinates.Add(mine);
            }

            return mineCoordinates;
        }
        public List<List<string>> GetGameData(string gameSettings)
        {
            var lines = _readDataService.GetLines(gameSettings);

            var commandList = new List<List<string>>();
            int i = 0;
            foreach (var line in lines)
            {
                var commands = new List<string>();
                if (i > 3)
                {
                    commands = _readDataService.GetCharactersFromLine(line);
                    commandList.Add(commands);
                }

                i++;
            }

            return commandList;
        }
    }
}
