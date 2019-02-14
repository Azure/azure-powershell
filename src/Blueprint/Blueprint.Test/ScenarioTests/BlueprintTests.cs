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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBlueprint()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetBlueprint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBlueprintWithDefinitionLocation()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetBlueprintWithDefinitionLocation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBlueprintWithDefinitionLocationAndName()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetBlueprintWithDefinitionLocationAndName");
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
