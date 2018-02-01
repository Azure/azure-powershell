using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.ManagementGroups.Test.ScenarioTests
{
    public class GroupSubscriptionOperationsTests
    {
        private readonly Microsoft.Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor _logger;

        public GroupSubscriptionOperationsTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new Microsoft.Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output);
            Microsoft.Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroupSubscription()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, @"Test-NewManagementGroupSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveManagementGroupSubscription()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, @"Test-RemoveManagementGroupSubscription");
        }
    }
}
