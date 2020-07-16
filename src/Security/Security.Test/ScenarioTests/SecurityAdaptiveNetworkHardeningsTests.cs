using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Security.Test.ScenarioTests
{
    public class SecurityAdaptiveNetworkHardeningsTests
    {
        private readonly XunitTracingInterceptor _logger;

        public SecurityAdaptiveNetworkHardeningsTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListByExtendedResource()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzSecurityAdaptiveNetworkHardening-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSingleAdaptiveNetworkHardeningResource()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzSecurityAdaptiveNetworkHardeningResource-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnforceRuleOnNsg()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzSecurityAdaptiveNetworkHardening-ResourceGroupLevelResource");
        }
    }
}

