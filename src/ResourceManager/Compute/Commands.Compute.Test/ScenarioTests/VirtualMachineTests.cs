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
    public partial class VirtualMachineTests
    {
        public VirtualMachineTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachine()
        {
            ComputeTestController.NewInstance.RunPsTest(@"Test-VirtualMachine $null");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePiping()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachinePiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineUpdateWithoutNic()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineUpdateWithoutNic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLinuxVirtualMachine()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-LinuxVirtualMachine");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithVMAgentAutoUpdate()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineWithVMAgentAutoUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineImageList()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineImageList");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineList()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineList");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineSizeAndUsage()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineSizeAndUsage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCapture()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineCapture");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCaptureNegative()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineCaptureNegative");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineDataDisk()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineDataDisk");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineDataDiskNegative()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineDataDiskNegative");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePIRv2()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachinePIRv2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePlan()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachinePlan");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePlan2()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachinePlan2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineTags()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineTags");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMImageCmdletOutputFormat()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VMImageCmdletOutputFormat");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVMSizeFromAllLocations()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-GetVMSizeFromAllLocations");
        }

        [Fact(Skip = "TODO: OOM issue when writing the result")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineListWithPaging()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineListWithPaging");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithDifferentStorageResource()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineWithDifferentStorageResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithPremiumStorageAccount()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineWithPremiumStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithEmptyAuc()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineWithEmptyAuc");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithBYOL()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineWithBYOL");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineRedeploy()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineRedeploy");
        }
    }
}
