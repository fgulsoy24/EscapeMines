using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Service
{
    public interface IReadDataService
    {
        List<Tuple<int, int>> GetPairNumbersList(string line);
        List<string> GetLines(string filePath);
        List<int> GetNumbers(string line);
        List<string> GetCharactersFromLine(string line);
    }
}
