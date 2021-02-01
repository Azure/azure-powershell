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

using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.ScenarioTests
{
    public partial class ItemTests : RMTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMGetItems()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.IaasVm, "Test-AzureVMGetItems");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMProtection()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.IaasVm, "Test-AzureVMProtection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMBackup()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.IaasVm, "Test-AzureVMBackup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMGetRPs()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.IaasVm, "Test-AzureVMGetRPs");
        }



        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMFullRestore()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.IaasVm, "Test-AzureVMFullRestore");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureUnmanagedVMFullRestore()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.IaasVm, "Test-AzureUnmanagedVMFullRestore");
        }

        [Fact(Skip = "To be fixed in upcoming release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMSoftDelete()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.IaasVm, "Test-AzureVMSoftDelete");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMRPMountScript()
        {
            Collection<PSObject> psObjects = TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.IaasVm, "Test-AzureVMRPMountScript");

            AzureVmRPMountScriptDetails mountScriptDetails = (AzureVmRPMountScriptDetails)psObjects.First(
                psObject => psObject.BaseObject.GetType() == typeof(AzureVmRPMountScriptDetails)).BaseObject;

            Assert.True(AzureSession.Instance.DataStore.FileExists(mountScriptDetails.FilePath));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMSetVaultContext()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.IaasVm, "Test-AzureVMSetVaultContext");
        }

        [Fact(Skip = "To be fixed in upcoming release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMSetVaultProperty()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.IaasVm, "Test-AzureVMSetVaultProperty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMDiskExclusion()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.IaasVm, "Test-AzureVMDiskExclusion");
        }

        [Fact(Skip = "CCY region is down and the testing for DS Move is restricted")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureBackupDataMove()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.IaasVm, "Test-AzureBackupDataMove");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureRSVaultMSI()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.IaasVm, "Test-AzureRSVaultMSI");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMCrossRegionRestore()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.IaasVm, "Test-AzureVMCrossRegionRestore");
        }
    }
}
