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
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            var gameSettings = string.Format(directory + @"game-settings.txt");
            var gameSettingsService = new GameSettingsService(new ReadDataService());
            var gameContext = gameSettingsService.PopulateGameSettings(gameSettings);
            Assert.True(gameContext.ExitPoint != null && gameContext.GameSize != null && gameContext.MineCoordinates != null && gameContext.StartPosition != null);
        }
        [Test]
        public void PopulateGameSettingsNullValueTest()
        {
            var gameSettings = string.Empty;
            var gameSettingsService = new GameSettingsService(new ReadDataService());
            var gameContext = gameSettingsService.PopulateGameSettings(gameSettings);
            Assert.True(gameContext == null);
        }

    }
}
