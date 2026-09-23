using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Network.Test.ScenarioTests
{
    public class NetworkVirtualApplianceBootDiagnosticsTest : NetworkTestRunner
    {
        public NetworkVirtualApplianceBootDiagnosticsTest(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestNetworkVirtualApplianceBootDiagnostics()
        {
            TestRunner.RunTestScript(string.Format("Test-NetworkVirtualApplianceBootDiagnostics"));
        }

    }
}