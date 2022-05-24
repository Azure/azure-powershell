using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Security.Test.ScenarioTests
{
    public class SecurityAdaptiveApplicationControlTests : SecurityTestRunner
    {
        public SecurityAdaptiveApplicationControlTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAdaptiveApplicationControlGroup()
        {
            TestRunner.RunTestScript("Get-AzSecurityAdaptiveApplicationControlGroup-ResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAdaptiveApplicationControlList()
        {
            TestRunner.RunTestScript("Get-AzSecurityAdaptiveApplicationControl-SubscriptionScope");
        }
    }
}
