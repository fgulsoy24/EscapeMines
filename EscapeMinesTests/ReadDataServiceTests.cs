using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeMines.Service;
using EscapeMines.Service.impl;

namespace EscapeMinesTests
{
    public class ReadDataServiceTests
    {
        public ReadDataService read = new ReadDataService();
        [Test]
        public void GetCharactersFromLineTest()
        {
            List<string> list = new List<string>();
            string[] characterList = { "M", "R",
                "M", "M","M"};
            list.AddRange(characterList);
            var functionCharacterList =  read.GetCharactersFromLine("M R M M M");
            Assert.True(list.All(functionCharacterList.Contains));
        }
        [Test]
        public void GetLinesTest()
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            var gameSettings = string.Format(directory + @"game-settings.txt");
            var lines = read.GetLines(gameSettings);
            Assert.True(lines != null);
        }
        [Test]
        public void GetNumbersTest()
        {
            List<int> list = new List<int>();
            int[] numberList = { 3, 5,
                6, 8};
            list.AddRange(numberList);
            var functionNumberList = read.GetNumbers("3 5 6 8");
            Assert.True(list.All(functionNumberList.Contains));

        }
        [Test]
        public void GetPairNumbersListTest()
        {
            var functionNumberList =  read.GetPairNumbersList("1,1 1,3 3,3");

            var numberList = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 1), new Tuple<int, int>(1, 3), new Tuple<int, int>(3, 3)
            };
            Assert.True(numberList.All(functionNumberList.Contains));
        }
        [Test]
        public void GetPairNumbersListIsNullTest()
        {
            var functionNumberList = read.GetPairNumbersList(null);     
            Assert.True(functionNumberList == null);
        }
    }
}
