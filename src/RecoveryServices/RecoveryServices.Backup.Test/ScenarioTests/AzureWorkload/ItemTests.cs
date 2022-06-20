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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.ScenarioTests
{
    public partial class ItemTests : RecoveryServicesBackupTestRunner
    {
        private readonly string _AzureWorkloadcommonModule = $"ScenarioTests/{PsBackupProviderTypes.AzureWorkload}/Common.ps1";
        private readonly string _AzureWorkloadtestModule = $"ScenarioTests/{PsBackupProviderTypes.AzureWorkload}/ItemTests.ps1";

        [Fact(Skip = "To be fixed in upcoming release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadProtectableItem()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_AzureWorkloadcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_AzureWorkloadtestModule.AsAbsoluteLocation()}",
                "Test-AzureVmWorkloadProtectableItem"
            );
        }

        [Fact(Skip = "To be fixed in upcoming release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadInitializeProtectableItem()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_AzureWorkloadcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_AzureWorkloadtestModule.AsAbsoluteLocation()}",
                "Test-AzureVmWorkloadInitializeProtectableItem"
            );
        }

        [Fact(Skip = "To be fixed in upcoming release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadEnableProtectableItem()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_AzureWorkloadcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_AzureWorkloadtestModule.AsAbsoluteLocation()}",
                "Test-AzureVmWorkloadEnableProtectableItem"
            );
        }

        [Fact(Skip = "To be fixed in upcoming release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadEnableAutoProtectableItem()
        {
            AzureSession.Instance.RegisterComponent("GetGuidComponent", () => "29e3f4dc-6407-4a9a-99cf-ea910639ba19", true);
            TestRunner.RunTestScript(
                $"Import-Module {_AzureWorkloadcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_AzureWorkloadtestModule.AsAbsoluteLocation()}",
                "Test-AzureVmWorkloadEnableAutoProtectableItem"
            );
        }

        [Fact(Skip = "To be fixed in upcoming release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadBackupProtectionItem()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_AzureWorkloadcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_AzureWorkloadtestModule.AsAbsoluteLocation()}",
                "Test-AzureVmWorkloadBackupProtectionItem"
            );
        }

        [Fact(Skip = "To be fixed in upcoming release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadGetRPs()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_AzureWorkloadcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_AzureWorkloadtestModule.AsAbsoluteLocation()}",
                "Test-AzureVmWorkloadGetRPs"
            );
        }

        [Fact(Skip = "To be fixed in upcoming release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadGetLogChains()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_AzureWorkloadcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_AzureWorkloadtestModule.AsAbsoluteLocation()}",
                "Test-AzureVmWorkloadGetLogChains"
            );
        }

        [Fact(Skip = "To be fixed in upcoming release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadFullRestore()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_AzureWorkloadcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_AzureWorkloadtestModule.AsAbsoluteLocation()}",
                "Test-AzureVmWorkloadFullRestore"
            );
        }

        [Fact(Skip = "To be fixed in upcoming release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadFullRestoreWithFiles()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_AzureWorkloadcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_AzureWorkloadtestModule.AsAbsoluteLocation()}",
                "Test-AzureVmWorkloadFullRestoreWithFiles"
            );
        }

        [Fact(Skip = "To be fixed in upcoming release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadRestoreAsFiles()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_AzureWorkloadcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_AzureWorkloadtestModule.AsAbsoluteLocation()}",
                "Test-AzureVmWorkloadRestoreAsFiles"
            );
        }
    }
}