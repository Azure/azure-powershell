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

using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public partial class VirtualMachineTests
    {
        XunitTracingInterceptor _logger;

        public VirtualMachineTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachine()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, @"Test-VirtualMachine $null");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachine_Managed()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, @"Test-VirtualMachine $null $true");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePiping()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachinePiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineUpdateWithoutNic()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineUpdateWithoutNic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLinuxVirtualMachine()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-LinuxVirtualMachine");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithVMAgentAutoUpdate()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineWithVMAgentAutoUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineImageList()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineImageList");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineList()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineList");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineSizeAndUsage()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineSizeAndUsage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCapture()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineCapture");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCaptureNegative()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineCaptureNegative");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineDataDisk()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineDataDisk");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineDataDiskNegative()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineDataDiskNegative");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePIRv2()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachinePIRv2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePlan()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachinePlan");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePlan2()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachinePlan2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineTags()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineTags");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMImageCmdletOutputFormat()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VMImageCmdletOutputFormat");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVMSizeFromAllLocations()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-GetVMSizeFromAllLocations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineListWithPaging()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineListWithPaging");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithDifferentStorageResource()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineWithDifferentStorageResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithPremiumStorageAccount()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineWithPremiumStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithEmptyAuc()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineWithEmptyAuc");
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
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineWithBYOL");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineRedeploy()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineRedeploy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineGetStatus()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineGetStatus");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineManagedDiskConversion()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineManagedDiskConversion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePerformanceMaintenance()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachinePerformanceMaintenance");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineIdentity()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineIdentityUpdate()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineIdentityUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWriteAcceleratorUpdate()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineWriteAcceleratorUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineManagedDisk()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineManagedDisk");
        }
    }
}
