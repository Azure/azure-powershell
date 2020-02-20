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
    public partial class VirtualMachineScaleSetTests : ComputeTestRunner
    {
        public VirtualMachineScaleSetTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSet()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSet_ManagedDisks()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSet-ManagedDisks");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetUpdate()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetReimageUpdate()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetReimageUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetReimageTempDisk()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetReimageTempDisk");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetLB()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetLB");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetNextLink()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetNextLink");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetBootDiagnostics()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetBootDiagnostics");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetIdentity()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetUserIdentity()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetUserIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetNetworking()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetNetworking");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetRollingUpgrade()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetRollingUpgrade");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetPriority()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetPriority");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetWriteAcceleratorUpdate()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetWriteAcceleratorUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetForceUDWalk()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetForceUDWalk");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetRedeploy()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetRedeploy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetVMUpdate()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetVMUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetAutoRollback()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetAutoRollback");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetScaleInPolicy()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetScaleInPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetAutoRepair()
        {
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetAutoRepair");
        }
    }
}
