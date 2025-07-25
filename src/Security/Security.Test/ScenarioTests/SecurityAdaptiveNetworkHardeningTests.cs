using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Security.Test.ScenarioTests
{
    public class SecurityAdaptiveNetworkHardeningTests : SecurityTestRunner
    {
        public SecurityAdaptiveNetworkHardeningTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListByExtendedResource()
        {
            TestRunner.RunTestScript("Get-AzSecurityAdaptiveNetworkHardening-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSingleAdaptiveNetworkHardeningResource()
        {
            TestRunner.RunTestScript("Get-AzSecurityAdaptiveNetworkHardening-ResourceGroupLevelResource");
        }
    }
}
