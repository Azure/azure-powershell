using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Blueprint.Test.ScenarioTests
{
    public class BlueprintAssignmentTests
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public BlueprintAssignmentTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBlueprintAssignment()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetBlueprintAssignment");
        }

        [Fact(Skip = "Investigate auto-registration for RP")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewBlueprintAssignmentWithSystemAssignedIdentity()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-NewBlueprintAssignmentWithSystemAssignedIdentity");
        }

        [Fact(Skip="Investigate auto-registration for RP")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewBlueprintAssignment()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-NewBlueprintAssignment");
        }

        [Fact(Skip = "Investigate auto-registration for RP")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetBlueprintAssignment()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-SetBlueprintAssignment");
        }

        [Fact(Skip = "Investigate auto-registration for RP")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveBlueprintAssignment()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-RemoveBlueprintAssignment");
        }

    }
}
