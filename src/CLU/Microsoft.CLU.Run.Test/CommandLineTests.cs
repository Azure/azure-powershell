using Microsoft.Azure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.CLU.Run;

namespace Microsoft.CLU.Run.Test
{
    public class CommandLineTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBasicCommandLineExecution()
        {
            CLURun.Execute(new string[] { "-r", "az env" });
        }
    }
}
