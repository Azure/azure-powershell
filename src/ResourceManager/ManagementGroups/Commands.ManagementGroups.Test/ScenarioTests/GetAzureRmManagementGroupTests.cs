using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.ManagementGroups.Test.ScenarioTests
{
    public class GetAzureRmManagementGroupTests
    {
        private readonly Microsoft.Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor _logger;

        public GetAzureRmManagementGroupTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new Microsoft.Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output);
            Microsoft.Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListManagementGroups()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, @"Test-ListManagementGroups");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroup()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, @"Test-GetManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroupWithExpand()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, @"Test-GetManagementGroupWithExpand");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroupWithExpandAndRecurse()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, @"Test-GetManagementGroupWithExpandAndRecurse");
        }

    }
}
