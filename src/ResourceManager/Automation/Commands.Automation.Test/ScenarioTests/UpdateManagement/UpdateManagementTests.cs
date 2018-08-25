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
    using Xunit;

    public class UpdateManagementTests : AutomationScenarioTestsBase
    {
        public UpdateManagementTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateWindowsOneTimeSUCWithDefaults()
        {
            RunPowerShellTest("Test-CreateWindowsOneTimeSoftwareUpdateConfigurationWithDefaults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxOneTimeSUCWithDefaults()
        {
            RunPowerShellTest("Test-CreateLinuxOneTimeSoftwareUpdateConfigurationWithDefaults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateWindowsOneTimeSUCWithAllOption()
        {
            RunPowerShellTest("Test-CreateWindowsOneTimeSoftwareUpdateConfigurationWithAllOption");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxOneTimeSUCWithAllOption()
        {
            RunPowerShellTest("Test-CreateLinuxOneTimeSoftwareUpdateConfigurationWithAllOption");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxOneTimeSUCNonAzureOnly()
        {
            RunPowerShellTest("Test-CreateLinuxOneTimeSoftwareUpdateConfigurationNonAzureOnly");
        }

        [Fact(Skip = "No recording generated")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxOneTimeSUCNoTarget()
        {
            RunPowerShellTest("Test-CreateLinuxOneTimeSoftwareUpdateConfigurationNoTargets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllSUCs()
        {
            RunPowerShellTest("Test-GetAllSoftwareUpdateConfigurations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllSUCsForVM()
        {
            RunPowerShellTest("Test-GetSoftwareUpdateConfigurationsForVM");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void DeleteSUC()
        {
            RunPowerShellTest("Test-DeleteSoftwareUpdateConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllRuns()
        {
            RunPowerShellTest("Test-GetAllSoftwareUpdateRuns");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllRunsWithFilters()
        {
            RunPowerShellTest("Test-GetAllSoftwareUpdateRunsWithFilters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllRunsWithFiltersNoResults()
        {
            RunPowerShellTest("Test-GetAllSoftwareUpdateRunsWithFiltersNoResults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllMachineRuns()
        {
            RunPowerShellTest("Test-GetAllSoftwareUpdateMachineRuns");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllMachineRunsWithFilters()
        {
            RunPowerShellTest("Test-GetAllSoftwareUpdateMachineRunsWithFilters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllMachineRunsWithFiltersNoResults()
        {
            RunPowerShellTest("Test-GetAllSoftwareUpdateMachineRunsWithFiltersNoResults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxWeeklySUC()
        {
            RunPowerShellTest("Test-CreateLinuxWeeklySoftwareUpdateConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateWindowsMonthlySUC()
        {
            RunPowerShellTest("Test-CreateWindowsMonthlySoftwareUpdateConfiguration");
        }
    }
}
