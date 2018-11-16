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

namespace Commands.Automation.Test
{
    using Microsoft.Azure.Commands.Automation.Test;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.Azure.ServiceManagemenet.Common.Models;
    using Xunit;

    public class UpdateManagementTests : AutomationScenarioTestsBase
    {
        public XunitTracingInterceptor logger;

        public UpdateManagementTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateWindowsOneTimeSUCWithDefaults()
        {
            RunPowerShellTest(logger, "Test-CreateWindowsOneTimeSoftwareUpdateConfigurationWithDefaults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxOneTimeSUCWithDefaults()
        {
            RunPowerShellTest(logger, "Test-CreateLinuxOneTimeSoftwareUpdateConfigurationWithDefaults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateWindowsOneTimeSUCWithAllOption()
        {
            RunPowerShellTest(logger, "Test-CreateWindowsOneTimeSoftwareUpdateConfigurationWithAllOption");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxOneTimeSUCWithAllOption()
        {
            RunPowerShellTest(logger, "Test-CreateLinuxOneTimeSoftwareUpdateConfigurationWithAllOption");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxOneTimeSUCNonAzureOnly()
        {
            RunPowerShellTest(logger, "Test-CreateLinuxOneTimeSoftwareUpdateConfigurationNonAzureOnly");
        }

        [Fact(Skip = "No recording generated")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxOneTimeSUCNoTarget()
        {
            RunPowerShellTest(logger, "Test-CreateLinuxOneTimeSoftwareUpdateConfigurationNoTargets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllSUCs()
        {
            RunPowerShellTest(logger, "Test-GetAllSoftwareUpdateConfigurations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllSUCsForVM()
        {
            RunPowerShellTest(logger, "Test-GetSoftwareUpdateConfigurationsForVM");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void DeleteSUC()
        {
            RunPowerShellTest(logger, "Test-DeleteSoftwareUpdateConfiguration");
        }

        [Fact(Skip = "Test needs to be re-recorded after issue https://github.com/Azure/azure-powershell/issues/7705 is fixed.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllRuns()
        {
            RunPowerShellTest(logger, "Test-GetAllSoftwareUpdateRuns");
        }

        [Fact(Skip = "Test needs to be re-recorded after issue https://github.com/Azure/azure-powershell/issues/7705 is fixed.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllRunsWithFilters()
        {
            RunPowerShellTest(logger, "Test-GetAllSoftwareUpdateRunsWithFilters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllRunsWithFiltersNoResults()
        {
            RunPowerShellTest(logger, "Test-GetAllSoftwareUpdateRunsWithFiltersNoResults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllMachineRuns()
        {
            RunPowerShellTest(logger, "Test-GetAllSoftwareUpdateMachineRuns");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllMachineRunsWithFilters()
        {
            RunPowerShellTest(logger, "Test-GetAllSoftwareUpdateMachineRunsWithFilters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllMachineRunsWithFiltersNoResults()
        {
            RunPowerShellTest(logger, "Test-GetAllSoftwareUpdateMachineRunsWithFiltersNoResults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxWeeklySUC()
        {
            RunPowerShellTest(logger, "Test-CreateLinuxWeeklySoftwareUpdateConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateWindowsMonthlySUC()
        {
            RunPowerShellTest(logger, "Test-CreateWindowsMonthlySoftwareUpdateConfiguration");
        }
    }
}