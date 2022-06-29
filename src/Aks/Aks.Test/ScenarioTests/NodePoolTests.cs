using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Aks.Test.ScenarioTests
{
    public class NodePoolTests : AksTestRunner
    {
        public NodePoolTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAksNodePool()
        {
            TestRunner.RunTestScript("Test-NewNodePool");
        }
    }
}
