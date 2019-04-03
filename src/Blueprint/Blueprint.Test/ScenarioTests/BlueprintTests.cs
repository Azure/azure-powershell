using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Blueprint.Test.ScenarioTests;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Blueprint.Test.ScenarioTests
{
    public class BlueprintTests
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;


        public BlueprintTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact(Skip = "There is a framework issue where HttpClient calls are not recorded in session records causing tests to fail in playback mode")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBlueprint()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetBlueprint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBlueprintWithDefinitionLocationNameAndVersion()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetBlueprintWithDefinitionLocationNameAndVersion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBlueprintWithDefinitionLocationNameAndLatestPublished()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetBlueprintWithDefinitionLocationNameAndLatestPublished");
        }
    }
}
