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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.ScenarioTests
{
    public partial class ItemTests : RMTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadProtectableItem()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.AzureWorkload, "Test-AzureVmWorkloadProtectableItem");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadInitializeProtectableItem()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.AzureWorkload, "Test-AzureVmWorkloadInitializeProtectableItem");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadEnableProtectableItem()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.AzureWorkload, "Test-AzureVmWorkloadEnableProtectableItem");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadEnableAutoProtectableItem()
        {
            AzureSession.Instance.RegisterComponent("GetGuidComponent", () => "29e3f4dc-6407-4a9a-99cf-ea910639ba19", true);
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.AzureWorkload, "Test-AzureVmWorkloadEnableAutoProtectableItem");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadBackupProtectionItem()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.AzureWorkload, "Test-AzureVmWorkloadBackupProtectionItem");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadGetRPs()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.AzureWorkload, "Test-AzureVmWorkloadGetRPs");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadGetLogChains()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.AzureWorkload, "Test-AzureVmWorkloadGetLogChains");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestAzureVmWorkloadFullRestore()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.AzureWorkload, "Test-AzureVmWorkloadFullRestore");
        }
    }
}