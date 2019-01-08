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
    public class VirtualMachineExtensionTests
    {
        XunitTracingInterceptor _logger;

        public VirtualMachineExtensionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineExtension()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineExtensionUsingHashTable()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineExtensionUsingHashTable");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtension()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineCustomScriptExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtensionWrongStorage()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineCustomScriptExtensionWrongStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtensionSecureExecution()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineCustomScriptExtensionSecureExecution");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtensionFileUri()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineCustomScriptExtensionFileUri");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineAccessExtension()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineAccessExtension");
        }

        [Fact(Skip = "TODO: only works for live mode")]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAzureDiskEncryptionExtension()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AzureDiskEncryptionExtension");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDiskEncryptionExtensionSinglePass()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AzureDiskEncryptionExtensionSinglePass");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDiskEncryptionExtensionSinglePassRemove()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AzureDiskEncryptionExtensionSinglePassRemove");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDiskEncryptionExtensionSinglePassDisableAndRemove()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AzureDiskEncryptionExtensionSinglePassDisableAndRemove");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineBginfoExtension()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineBginfoExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineExtensionWithSwitch()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineExtensionWithSwitch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineADDomainExtension()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineADDomainExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineADDomainExtensionDomainJoin()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineADDomainExtensionDomainJoin");
        }
    }
}
