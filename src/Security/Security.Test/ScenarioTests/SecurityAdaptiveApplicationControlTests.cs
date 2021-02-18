using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Security.Test.ScenarioTests
{
    public class SecurityAdaptiveApplicationControlTests
    {
        private readonly XunitTracingInterceptor _logger;

        public SecurityAdaptiveApplicationControlTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAdaptiveApplicationControlGroup()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzSecurityAdaptiveApplicationControlGroup-ResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAdaptiveApplicationControlList()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzSecurityAdaptiveApplicationControl-SubscriptionScope");
        }
    }
}

