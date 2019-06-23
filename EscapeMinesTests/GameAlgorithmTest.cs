using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeMines;
using EscapeMines.Model;
using EscapeMines.Service;
using EscapeMines.Service.impl;

namespace EscapeMinesTests
{
    public class GameAlgorithmTest
    {
        [Test]
        public void CalculateGameResultsTest()
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            var gameSettings = string.Format(directory + @"game-settings.txt");
            GameSettingsService gameSettingsService = new GameSettingsService(new ReadDataService());
            GameContext gameContext = gameSettingsService.PopulateGameSettings(gameSettings);
            Assert.True(gameContext.ExitPoint != null && gameContext.GameSize != null && gameContext.MineCoordinates != null && gameContext.StartPosition != null);
        }
        [Test]
        public void CalculateGameResultsTest_WrongCommandTest()
        {
            /* This test checking, what make program, when will send the wrong command, 
             * When send wrong data, It should show "Unknown movement" message.
             * It will do nothing and pass another character
             */

            var directory = AppDomain.CurrentDomain.BaseDirectory;
            var gameSettings = string.Format(directory + @"game-settings.txt");
            var gameSettingsService = new GameSettingsService(new ReadDataService());
            var gameContext = gameSettingsService.PopulateGameSettings(gameSettings);
            var data = new List<string>();
            var moveList = new List<string> {"k", "M", "L"};
            data.AddRange(moveList);
            gameContext.CommandList.Add(moveList);

            var algorithm = new GameAlgorithm(gameContext);
            Assert.False(algorithm.CalculateGameResults(gameContext));
        }
        [Test]
        public void IfGameContextNullTest()
        {
            /* This test checking, what make program, when will send the wrong command, 
             * When send wrong data, It should show "Unknown movement" message.
             * It will do nothing and pass another character
             */
         
            var algorithm = new GameAlgorithm(null);
            Assert.False(algorithm.CalculateGameResults(null));
        }
    }
}
