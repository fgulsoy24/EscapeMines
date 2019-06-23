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
        public void GetGamePathAssertDoesNotThrowTest()
        {
            try
            {
                var gameSettings = GamePath.GetGamePath("test-settings");
            }
            catch (Exception ex)
            {
                throw new Exception("expected action not to throw, but it did!", ex);
            }
        }
    }
}
