using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.ManagementGroups.Test.ScenarioTests
{
    public class RemoveAzureRmManagementGroupTests
    {
        private readonly Microsoft.Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor _logger;

        public RemoveAzureRmManagementGroupTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new Microsoft.Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output);
            Microsoft.Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveManagementGroup()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, @"Test-RemoveManagementGroup");
        }
    }
}
