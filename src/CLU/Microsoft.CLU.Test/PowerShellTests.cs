using Microsoft.Azure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.CLU.Test
{
    public class PowerShellTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBasicPipeline()
        {
            var ps = System.Management.Automation.PowerShell.Create();
            //ps.AddCommand()
        }
    }
}
