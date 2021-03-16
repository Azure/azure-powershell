using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Network.Test.ScenarioTests
{
    public class RouteServerTests : NetworkTestRunner
    {
        public RouteServerTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestRouteServerCRUD()
        {
            TestRunner.RunTestScript(string.Format("Test-RouteServerCRUD"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestRouteServerPeerCRUD()
        {
            TestRunner.RunTestScript(string.Format("Test-RouteServerPeerCRUD"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestRouteServerPeerRoutes()
        {
            TestRunner.RunTestScript(string.Format("Test-RouteServerPeerRoutes"));
        }
    }
}
