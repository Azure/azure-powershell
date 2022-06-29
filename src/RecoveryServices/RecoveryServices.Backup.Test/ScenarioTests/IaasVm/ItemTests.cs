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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.ScenarioTests
{
    public partial class ItemTests : RecoveryServicesBackupTestRunner
    {
        private readonly string _IaasVmcommonModule = $"ScenarioTests/{PsBackupProviderTypes.IaasVm}/Common.ps1";
        private readonly string _IaasVmtestModule = $"ScenarioTests/{PsBackupProviderTypes.IaasVm}/ItemTests.ps1";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMGetItems()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMGetItems"
             );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMProtection()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMProtection"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMBackup()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMBackup"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMGetRPs()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMGetRPs"
            );
        }



        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMFullRestore()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMFullRestore"
            );
        }

        [Fact(Skip = "To re-record in next release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureUnmanagedVMFullRestore()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureUnmanagedVMFullRestore"
            );
        }

        [Fact(Skip = "To be fixed in upcoming release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMSoftDelete()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMSoftDelete"
            );
        }

        [Fact(Skip = "To re-record in next release. Need to move assertion to ps1 file if possible.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMRPMountScript()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMRPMountScript");

            //AzureVmRPMountScriptDetails mountScriptDetails = (AzureVmRPMountScriptDetails)psObjects.First(
            //    psObject => psObject.BaseObject.GetType() == typeof(AzureVmRPMountScriptDetails)).BaseObject;

            //Assert.True(AzureSession.Instance.DataStore.FileExists(mountScriptDetails.FilePath));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMSetVaultContext()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMSetVaultContext"
            );
        }

        [Fact(Skip = "To be fixed in upcoming release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMSetVaultProperty()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMSetVaultProperty"
            );
        }

        [Fact(Skip = "To re-record in next release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMDiskExclusion()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMDiskExclusion"
            );
        }

        [Fact(Skip = "CCY region is down and the testing for DS Move is restricted")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureBackupDataMove()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureBackupDataMove"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureRSVaultMSI()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureRSVaultMSI"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMCrossRegionRestore()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMCrossRegionRestore"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMRestoreWithMSI()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMRestoreWithMSI"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureRSVaultCMK()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureRSVaultCMK"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureManagedVMRestore()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureManagedVMRestore"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMMUA()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMMUA"
            );
        }        
    }
}
