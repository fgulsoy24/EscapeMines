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
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string gameSettings = string.Format(directory + @"game-settings.txt");
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

            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string gameSettings = string.Format(directory + @"game-settings.txt");
            GameSettingsService gameSettingsService = new GameSettingsService(new ReadDataService());
            GameContext gameContext = gameSettingsService.PopulateGameSettings(gameSettings);
            List<string> data = new List<string>();
            string[] moveList = { "K", "L",
                "S", "L","M","L","M","M","M","M" };
            data.AddRange(moveList);

            List<List<string>> gameData = new List<List<string>>();
            gameData.Add(data);
            GameAlgorithm algorithm = new GameAlgorithm();
            algorithm.CalculateGameResults(gameContext, gameData);

        }
    }
}
