using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.ManagementGroups.Test.ScenarioTests
{
    public class UpdateAzureRmManagementGroupTests
    {
        private readonly Microsoft.Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor _logger;

        public UpdateAzureRmManagementGroupTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new Microsoft.Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output);
            Microsoft.Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateManagementGroup()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, @"Test-UpdateManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateManagementGroupWithDisplayName()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, @"Test-UpdateManagementGroupWithDisplayName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateManagementGroupWithParentId()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, @"Test-UpdateManagementGroupWithParentId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateManagementGroupWithDisplayNameAndParentId()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, @"Test-UpdateManagementGroupWithDisplayNameAndParentId");
        }
    }
}
