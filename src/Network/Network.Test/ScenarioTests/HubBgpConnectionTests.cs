using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Network.Test.ScenarioTests
{
    public class HubBgpConnectionTests : NetworkTestRunner
    {
        public HubBgpConnectionTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
    {
    }

    [Fact]
    [Trait(Category.AcceptanceType, Category.CheckIn)]
    [Trait(Category.Owner, NrpTeamAlias.pgtm)]
    public void TestHubBgpConnectionCRUDMinimalParameters()
    {
        TestRunner.RunTestScript(string.Format("Test-HubBgpConnectionCRUD"));
    }
}
}
