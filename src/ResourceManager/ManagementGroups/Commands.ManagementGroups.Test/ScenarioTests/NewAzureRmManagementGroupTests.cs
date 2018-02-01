using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.ManagementGroups.Test.ScenarioTests
{
    public class NewAzureRmManagementGroupTests
    {
        private readonly Microsoft.Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor _logger;

        public NewAzureRmManagementGroupTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new Microsoft.Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output);
            Microsoft.Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroup()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, @"Test-NewManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroupWithDisplayName()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, @"Test-NewManagementGroupWithDisplayName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroupWithParentId()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, @"Test-NewManagementGroupWithParentId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroupWithDisplayNameAndParentId()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, @"Test-NewManagementGroupWithDisplayNameAndParentId");
        }
    }
}
