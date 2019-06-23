using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Utils
{
    public static class GamePath
    {
        private static readonly string GameSettingsFilePath = ConfigurationManager.AppSettings["GameSettingsFilePath"];
        private static string _gameSettingsParameter = "";
        public static string GetGamePath(string args)
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            _gameSettingsParameter = $@"{directory}{args}.txt";
            var gameSettings = args.Length == 0 ? GameSettingsFilePath : _gameSettingsParameter;
            return gameSettings;
        }
    }
}
