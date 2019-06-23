using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeMines.Utils;

namespace EscapeMinesTests
{
    class GamePathTests
    {
        [Test]
        public void GetGamePathTest()
        {
            string gameSettings = GamePath.GetGamePath("test-settings");
        }
    }
}
