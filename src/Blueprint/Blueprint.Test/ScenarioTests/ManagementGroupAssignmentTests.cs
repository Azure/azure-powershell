namespace Microsoft.Azure.Commands.Blueprint.Test.ScenarioTests
{
    using Microsoft.Azure.Commands.ScenarioTest;
    using Microsoft.Azure.ServiceManagement.Common.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using Xunit.Abstractions;

    public class ManagementGroupAssignmentTests
    {
        private XunitTracingInterceptor logger;

        public ManagementGroupAssignmentTests(ITestOutputHelper output)
        {

            this.logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(this.logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAssignmentsInManagementGroup()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-GetAssignmentsInManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSingleAssignmentInManagementGroup()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-GetSingleAssignmentInManagementGroup");
        }

        [Fact(Skip = "Investigate auto-registration for RP")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAssignmentInManagementGroup()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-CreateAssignmentInManagementGroup");
        }

        [Fact(Skip = "Investigate auto-registration for RP")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateAssignmentInManagementGroup()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-UpdateAssignmentInManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAssignmentInManagementGroup()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-RemoveAssignmentInManagementGroup");
        }
    }
}
