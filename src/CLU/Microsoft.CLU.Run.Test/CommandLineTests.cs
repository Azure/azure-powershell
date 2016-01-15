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
            //CLUEnvironment.Console = new MemoryConsoleInputOutput();
            //CLURun.Execute(new string[] { "-s", "az", "-r", "C:\\azure-powershell\\drop\\clurun\\win7-x64\\\\azure.lx", "env", "ls" });

            
        }
    }
}
