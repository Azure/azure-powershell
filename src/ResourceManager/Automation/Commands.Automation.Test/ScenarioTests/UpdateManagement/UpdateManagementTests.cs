// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.ScenarioTests.UpdateManagement
{
    using Microsoft.Azure.Commands.Automation.Test;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.Azure.ServiceManagemenet.Common.Models;
    using Xunit;

    public class UpdateManagementTests : AutomationScenarioTestsBase
    {
        public XunitTracingInterceptor _logger;

        public UpdateManagementTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateWindowsOneTimeSUCWithDefaults()
        {
            RunPowerShellTest(_logger, "Test-CreateWindowsOneTimeSoftwareUpdateConfigurationWithDefaults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxOneTimeSUCWithDefaults()
        {
            RunPowerShellTest(_logger, "Test-CreateLinuxOneTimeSoftwareUpdateConfigurationWithDefaults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateWindowsOneTimeSUCWithAllOption()
        {
            RunPowerShellTest(_logger, "Test-CreateWindowsOneTimeSoftwareUpdateConfigurationWithAllOption");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxOneTimeSUCWithAllOption()
        {
            RunPowerShellTest(_logger, "Test-CreateLinuxOneTimeSoftwareUpdateConfigurationWithAllOption");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxOneTimeSUCNonAzureOnly()
        {
            RunPowerShellTest(_logger, "Test-CreateLinuxOneTimeSoftwareUpdateConfigurationNonAzureOnly");
        }

        [Fact(Skip = "No recording generated")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxOneTimeSUCNoTarget()
        {
            RunPowerShellTest(_logger, "Test-CreateLinuxOneTimeSoftwareUpdateConfigurationNoTargets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllSUCs()
        {
            RunPowerShellTest(_logger, "Test-GetAllSoftwareUpdateConfigurations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllSUCsForVM()
        {
            RunPowerShellTest(_logger, "Test-GetSoftwareUpdateConfigurationsForVM");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void DeleteSUC()
        {
            RunPowerShellTest(_logger, "Test-DeleteSoftwareUpdateConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllRuns()
        {
            RunPowerShellTest(_logger, "Test-GetAllSoftwareUpdateRuns");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllRunsWithFilters()
        {
            RunPowerShellTest(_logger, "Test-GetAllSoftwareUpdateRunsWithFilters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllRunsWithFiltersNoResults()
        {
            RunPowerShellTest(_logger, "Test-GetAllSoftwareUpdateRunsWithFiltersNoResults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllMachineRuns()
        {
            RunPowerShellTest(_logger, "Test-GetAllSoftwareUpdateMachineRuns");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllMachineRunsWithFilters()
        {
            RunPowerShellTest(_logger, "Test-GetAllSoftwareUpdateMachineRunsWithFilters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllMachineRunsWithFiltersNoResults()
        {
            RunPowerShellTest(_logger, "Test-GetAllSoftwareUpdateMachineRunsWithFiltersNoResults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxWeeklySUC()
        {
            RunPowerShellTest(_logger, "Test-CreateLinuxWeeklySoftwareUpdateConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateWindowsMonthlySUC()
        {
            RunPowerShellTest(_logger, "Test-CreateWindowsMonthlySoftwareUpdateConfiguration");
        }
    }
}
