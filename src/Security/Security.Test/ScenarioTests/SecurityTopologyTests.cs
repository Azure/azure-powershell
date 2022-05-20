using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Security.Test.ScenarioTests
{
    public class SecurityTopologyTests : SecurityTestRunner
    {
        public SecurityTopologyTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSubscriptionScope()
        {
            TestRunner.RunTestScript("Get-AzureRmSecurityTopology-SubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetResourceGroupLevelResource()
        {
            TestRunner.RunTestScript("Get-AzureRmSecurityTopology-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetResourceId()
        {
            TestRunner.RunTestScript("Get-AzureRmSecurityTopology-ResourceId");
        }
    }
}
