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

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class VirtualMachineScaleSetExtensionTests : ComputeTestRunner
    {
        public VirtualMachineScaleSetExtensionTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact(Skip = "TODO: only works for live mode")]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestVirtualMachineScaleSetDiskEncryptionExtension()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetDiskEncryptionExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableVirtualMachineScaleSetDiskEncryption()
        {
            TestRunner.RunTestScript("Test-DisableVirtualMachineScaleSetDiskEncryption");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableVirtualMachineScaleSetDiskEncryption2()
        {
            TestRunner.RunTestScript("Test-DisableVirtualMachineScaleSetDiskEncryption2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVirtualMachineScaleSetDiskEncryptionStatus()
        {
            TestRunner.RunTestScript("Test-GetVirtualMachineScaleSetDiskEncryptionStatus");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVirtualMachineScaleSetDiskEncryptionDataDisk()
        {
            TestRunner.RunTestScript("Test-GetVirtualMachineScaleSetDiskEncryptionDataDisk");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDiskEncryptionWithEncryptionIdentityAddedInAzVmssConfig()
        {
            TestRunner.RunTestScript("Test-AzureDiskEncryptionWithEncryptionIdentityAddedInAzVmssConfig");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDiskEncryptionWithEncryptionIdentityAddedInSetADEVMssCmdlet()
        {
            TestRunner.RunTestScript("Test-AzureDiskEncryptionWithEncryptionIdentityAddedInSetADEVMssCmdlet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDiskEncryptionWithIdentityNotSetInVirtualMachineScaleSet()
        {
            TestRunner.RunTestScript("Test-AzureDiskEncryptionWithIdentityNotSetInVirtualMachineScaleSet");
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureVmssDiskEncryptionWithIdentityNotAckledInKeyVault()
        {
            TestRunner.RunTestScript("Test-AzureVmssDiskEncryptionWithIdentityNotAckledInKeyVault");
        }
    }
}
