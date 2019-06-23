using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EscapeMines.Service.impl
{
    public class ReadDataService : IReadDataService
    {
        public List<Tuple<int, int>> GetNumberList(string line)
        {

            var tuples = new List<Tuple<int, int>>();
            var matches = Regex.Matches(line, @"\d{1,2}[,.]\d{1,2}");
            foreach (Match match in matches)
            {
                foreach (Capture capture in match.Captures)
                {
                    var parts = capture.Value.Split(',').ToList<string>();
                    var tuple = new Tuple<int, int>(int.Parse(parts[0]), int.Parse(parts[1]));
                    tuples.Add(tuple);
                }
            }
            return tuples;
        }
        public List<string> GetLines(string filePath)
        {
            return File.ReadAllLines(filePath, Encoding.UTF8).ToList();
        }
        public List<int> GetNumbers(string line)
        {
            var list = new List<int>();
            var numbers = Regex.Split(line, @"\D+");

            foreach (var item in numbers)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    list.Add(int.Parse(item));
                }
            }
            return list;
        }
        public List<string> GetCharactersFromLine(string line)
        {
            var characters = new List<string>();
            var regex = new Regex(@"\S");
            var result = regex.Match(line);
            if (result.Success)
            {
                while (result.Success)
                {
                    characters.Add(result.Value);
                    result = result.NextMatch();
                }
            }
            return characters;
        }
    }
}
