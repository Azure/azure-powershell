using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Network.Test.ScenarioTests
{
    public class RestartNetworkVirtualApplianceTest : NetworkTestRunner
    {
        public RestartNetworkVirtualApplianceTest(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestNetworkVirtualApplianceRestart()
        {
            TestRunner.RunTestScript(string.Format("Test-NetworkVirtualApplianceRestart"));
        }

    }
}