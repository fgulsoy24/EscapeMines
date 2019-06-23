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
        private static string GameSettingsParameter = "";
        public static string GetGamePath(string args)
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            GameSettingsParameter = string.Format(@"{0}{1}.txt",directory,args);
            string gameSettings = args.Length == 0 ? GameSettingsFilePath : GameSettingsParameter;
            return gameSettings;
        }
    }
}
