using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeMines.Model;
using EscapeMines.Service;
using EscapeMines.Service.impl;

namespace EscapeMinesTests
{
    class GameSettingsServiceTests
    {
        [Test]
        public void PopulateGameSettingsTest()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string gameSettings = string.Format(directory + @"game-settings.txt");
            GameSettingsService gameSettingsService = new GameSettingsService(new ReadDataService());
            GameContext gameContext = gameSettingsService.PopulateGameSettings(gameSettings);
            Assert.True(gameContext.ExitPoint != null && gameContext.GameSize != null && gameContext.MineCoordinates != null && gameContext.StartPosition != null);
        }
    }
}
