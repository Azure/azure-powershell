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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Automation.Test
{
    public class UpdateManagementTests : AutomationTestRunner
    {
        public UpdateManagementTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateWindowsOneTimeSUCWithDefaults()
        {
            TestRunner.RunTestScript("Test-CreateWindowsOneTimeSoftwareUpdateConfigurationWithDefaults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxOneTimeSUCWithDefaults()
        {
            TestRunner.RunTestScript("Test-CreateLinuxOneTimeSoftwareUpdateConfigurationWithDefaults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateWindowsOneTimeSUCWithAllOption()
        {
            TestRunner.RunTestScript("Test-CreateWindowsOneTimeSoftwareUpdateConfigurationWithAllOption");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxOneTimeSUCWithAllOption()
        {
            TestRunner.RunTestScript("Test-CreateLinuxOneTimeSoftwareUpdateConfigurationWithAllOption");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxOneTimeSUCNonAzureOnly()
        {
            TestRunner.RunTestScript("Test-CreateLinuxOneTimeSoftwareUpdateConfigurationNonAzureOnly");
        }

        [Fact(Skip = "No recording generated")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxOneTimeSUCNoTarget()
        {
            TestRunner.RunTestScript("Test-CreateLinuxOneTimeSoftwareUpdateConfigurationNoTargets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllSUCs()
        {
            TestRunner.RunTestScript("Test-GetAllSoftwareUpdateConfigurations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllSUCsForVM()
        {
            TestRunner.RunTestScript("Test-GetSoftwareUpdateConfigurationsForVM");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void DeleteSUC()
        {
            TestRunner.RunTestScript("Test-DeleteSoftwareUpdateConfiguration");
        }

        [Fact(Skip = "Test needs to be re-recorded after issue https://github.com/Azure/azure-powershell/issues/7705 is fixed.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllRuns()
        {
            TestRunner.RunTestScript("Test-GetAllSoftwareUpdateRuns");
        }

        [Fact(Skip = "Test needs to be re-recorded after issue https://github.com/Azure/azure-powershell/issues/7705 is fixed.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllRunsWithFilters()
        {
            TestRunner.RunTestScript("Test-GetAllSoftwareUpdateRunsWithFilters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllRunsWithFiltersNoResults()
        {
            TestRunner.RunTestScript("Test-GetAllSoftwareUpdateRunsWithFiltersNoResults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllMachineRuns()
        {
            TestRunner.RunTestScript("Test-GetAllSoftwareUpdateMachineRuns");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllMachineRunsWithFilters()
        {
            TestRunner.RunTestScript("Test-GetAllSoftwareUpdateMachineRunsWithFilters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllMachineRunsWithFiltersNoResults()
        {
            TestRunner.RunTestScript("Test-GetAllSoftwareUpdateMachineRunsWithFiltersNoResults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxWeeklySUC()
        {
            TestRunner.RunTestScript("Test-CreateLinuxWeeklySoftwareUpdateConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateWindowsMonthlySUC()
        {
            TestRunner.RunTestScript("Test-CreateWindowsMonthlySoftwareUpdateConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateWindowsIncludeKbNumbersSUC()
        {
            TestRunner.RunTestScript("Test-CreateWindowsIncludeKbNumbersSoftwareUpdateConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateLinuxIncludePackageNameMasksSUC()
        {
            TestRunner.RunTestScript("Test-CreateLinuxIncludedPackageNameMasksSoftwareUpdateConfiguration");
        }
    }
}