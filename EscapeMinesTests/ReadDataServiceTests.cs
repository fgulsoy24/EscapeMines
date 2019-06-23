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
            List<string> functionCharacterList =  read.GetCharactersFromLine("M R M M M");
            Assert.True(list.All(functionCharacterList.Contains));
        }
        [Test]
        public void GetLinesTest()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string gameSettings = string.Format(directory + @"game-settings.txt");
            read.GetLines(gameSettings);
        }
        [Test]
        public void GetNumbersTest()
        {
            List<int> list = new List<int>();
            int[] numberList = { 3, 5,
                6, 8};
            list.AddRange(numberList);
            List<int> functionNumberList = read.GetNumbers("3 5 6 8");
            Assert.True(list.All(functionNumberList.Contains));

        }
        [Test]
        public void GetNumberListTest()
        {
            List<Tuple<int, int>> functionNumberList =  read.GetNumberList("1,1 1,3 3,3");

            List<Tuple<int, int>> numberList = new List<Tuple<int, int>>();
            numberList.Add(new Tuple<int, int>(1, 1));
            numberList.Add(new Tuple<int, int>(1, 3));
            numberList.Add(new Tuple<int, int>(3, 3));
            Assert.True(numberList.All(functionNumberList.Contains));

        }
    }
}
