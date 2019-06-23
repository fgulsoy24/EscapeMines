using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using EscapeMines.Model;
using EscapeMines.Service;
using EscapeMines.Service.impl;
using EscapeMines.Utils;

namespace EscapeMines
{
    /// <summary>
    /// This class does execute program.
    /// Program get game settings and data, It writes objects
    /// Calculate Game Results function is getting data,
    /// It is calculating turtle position and giving results.
    /// </summary>
    internal class Program
    {
    
        private static void Main(string[] args)
        {
            
            var gameSettings =  GamePath.GetGamePath(args[0]);
         
            ExecuteGame(gameSettings);
        
        }


        /// <summary>
        /// Get game settings from file
        /// Populate game settings to objects
        /// Calculate 
        /// </summary>
        /// <param name="gameSettings">Game settings file path</param>
        private static void ExecuteGame(string gameSettings)
        {
            var gameContext = new GameSettingsService(new ReadDataService()).PopulateGameSettings(gameSettings);  
            new GameAlgorithm(gameContext);
        }
    }
}
