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
    public class VirtualMachineExtensionTests
    {
        public VirtualMachineExtensionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineExtension()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineExtensionUsingHashTable()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineExtensionUsingHashTable");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtension()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineCustomScriptExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtensionWrongStorage()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineCustomScriptExtensionWrongStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtensionSecureExecution()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineCustomScriptExtensionSecureExecution");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtensionFileUri()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineCustomScriptExtensionFileUri");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineAccessExtension()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineAccessExtension");
        }

        [Fact(Skip = "TODO: only works for live mode")]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAzureDiskEncryptionExtension()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-AzureDiskEncryptionExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineBginfoExtension()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineBginfoExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineExtensionWithSwitch()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineExtensionWithSwitch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineADDomainExtension()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineADDomainExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineADDomainExtensionDomainJoin()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-VirtualMachineADDomainExtensionDomainJoin");
        }
    }
}
