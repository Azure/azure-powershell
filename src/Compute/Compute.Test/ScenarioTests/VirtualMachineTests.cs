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
    public partial class VirtualMachineTests : ComputeTestRunner
    {
        public VirtualMachineTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact(Skip = "Fails on Linux/macOS. Needs investigation.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachine()
        {
            TestRunner.RunTestScript("Test-VirtualMachine $null");
        }

        [Fact(Skip = "Fails on Linux/macOS. Needs investigation.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachine_Managed()
        {
            TestRunner.RunTestScript("Test-VirtualMachine $null $true");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePiping()
        {
            TestRunner.RunTestScript("Test-VirtualMachinePiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineUpdateWithoutNic()
        {
            TestRunner.RunTestScript("Test-VirtualMachineUpdateWithoutNic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLinuxVirtualMachine()
        {
            TestRunner.RunTestScript("Test-LinuxVirtualMachine");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithVMAgentAutoUpdate()
        {
            TestRunner.RunTestScript("Test-VirtualMachineWithVMAgentAutoUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineImageList()
        {
            TestRunner.RunTestScript("Test-VirtualMachineImageList");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineList()
        {
            TestRunner.RunTestScript("Test-VirtualMachineList");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineSizeAndUsage()
        {
            TestRunner.RunTestScript("Test-VirtualMachineSizeAndUsage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCapture()
        {
            TestRunner.RunTestScript("Test-VirtualMachineCapture");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCaptureNegative()
        {
            TestRunner.RunTestScript("Test-VirtualMachineCaptureNegative");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineDataDisk()
        {
            TestRunner.RunTestScript("Test-VirtualMachineDataDisk");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineDataDiskNegative()
        {
            TestRunner.RunTestScript("Test-VirtualMachineDataDiskNegative");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePIRv2()
        {
            TestRunner.RunTestScript("Test-VirtualMachinePIRv2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePlan()
        {
            TestRunner.RunTestScript("Test-VirtualMachinePlan");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePlan2()
        {
            TestRunner.RunTestScript("Test-VirtualMachinePlan2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineTags()
        {
            TestRunner.RunTestScript("Test-VirtualMachineTags");
        }

        [Fact(Skip = "Fails on Linux/macOS. Needs investigation.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMImageCmdletOutputFormat()
        {
            TestRunner.RunTestScript("Test-VMImageCmdletOutputFormat");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVMSizeFromAllLocations()
        {
            TestRunner.RunTestScript("Test-GetVMSizeFromAllLocations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineListWithPaging()
        {
            TestRunner.RunTestScript("Test-VirtualMachineListWithPaging");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithDifferentStorageResource()
        {
            TestRunner.RunTestScript("Test-VirtualMachineWithDifferentStorageResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithPremiumStorageAccount()
        {
            TestRunner.RunTestScript("Test-VirtualMachineWithPremiumStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithEmptyAuc()
        {
            TestRunner.RunTestScript("Test-VirtualMachineWithEmptyAuc");
        }

#if NETSTANDARD
        [Fact(Skip = "Unknown issue/update, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact(Skip = "CRP needs to re-record the test")]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithBYOL()
        {
            TestRunner.RunTestScript("Test-VirtualMachineWithBYOL");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineRedeploy()
        {
            TestRunner.RunTestScript("Test-VirtualMachineRedeploy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineGetStatus()
        {
            TestRunner.RunTestScript("Test-VirtualMachineGetStatus");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineManagedDiskConversion()
        {
            TestRunner.RunTestScript("Test-VirtualMachineManagedDiskConversion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePerformanceMaintenance()
        {
            TestRunner.RunTestScript("Test-VirtualMachinePerformanceMaintenance");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineIdentity()
        {
            TestRunner.RunTestScript("Test-VirtualMachineIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineIdentityUpdate()
        {
            TestRunner.RunTestScript("Test-VirtualMachineIdentityUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWriteAcceleratorUpdate()
        {
            TestRunner.RunTestScript("Test-VirtualMachineWriteAcceleratorUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineManagedDisk()
        {
            TestRunner.RunTestScript("Test-VirtualMachineManagedDisk");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineReimage()
        {
            TestRunner.RunTestScript("Test-VirtualMachineReimage");
        }
    }
}
