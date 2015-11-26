﻿// ----------------------------------------------------------------------------------
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
        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachine()
        {
            ComputeTestController.NewInstance.RunPsTest(@"Test-VirtualMachine $null");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePiping()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachinePiping");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLinuxVirtualMachine()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-LinuxVirtualMachine");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithVMAgentAutoUpdate()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineWithVMAgentAutoUpdate");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineImageList()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineImageList");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineList()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineList");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineSizeAndUsage()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineSizeAndUsage");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCapture()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineCapture");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineDataDisk()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineDataDisk");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineDataDiskNegative()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineDataDiskNegative");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePIRv2()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachinePIRv2");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePlan()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachinePlan");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePlan2()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachinePlan2");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineTags()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineTags");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMImageCmdletOutputFormat()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VMImageCmdletOutputFormat");
        }

        [Fact(Skip = "Rerecord tests")]
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
        
        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithDifferentStorageResource()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineWithDifferentStorageResource");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithEmptyAuc()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineWithEmptyAuc");
        }

    }
}
