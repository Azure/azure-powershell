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
    public class VirtualMachineExtensionTests : ComputeTestRunner
    {
        public VirtualMachineExtensionTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineExtension()
        {
            TestRunner.RunTestScript("Test-VirtualMachineExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineExtensionUsingHashTable()
        {
            TestRunner.RunTestScript("Test-VirtualMachineExtensionUsingHashTable");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtension()
        {
            TestRunner.RunTestScript("Test-VirtualMachineCustomScriptExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtensionPiping()
        {
            TestRunner.RunTestScript("Test-VirtualMachineCustomScriptExtensionPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtensionWrongStorage()
        {
            TestRunner.RunTestScript("Test-VirtualMachineCustomScriptExtensionWrongStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtensionSecureExecution()
        {
            TestRunner.RunTestScript("Test-VirtualMachineCustomScriptExtensionSecureExecution");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtensionFileUri()
        {
            TestRunner.RunTestScript("Test-VirtualMachineCustomScriptExtensionFileUri");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtensionLinuxVM()
        {
            TestRunner.RunTestScript("Test-VirtualMachineCustomScriptExtensionLinuxVM");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtensionManagedDisk()
        {
            TestRunner.RunTestScript("Test-VirtualMachineCustomScriptExtensionManagedDisk");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtensionSubstatuses()
        {
            TestRunner.RunTestScript("Test-VirtualMachineCustomScriptExtensionSubstatuses");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineAccessExtension()
        {
            TestRunner.RunTestScript("Test-VirtualMachineAccessExtension");
        }

        [Fact(Skip = "TODO: only works for live mode")]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAzureDiskEncryptionExtension()
        {
            TestRunner.RunTestScript("Test-AzureDiskEncryptionExtension");
        }

        [Fact(Skip = "TODO: only works for live mode")]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAzureDiskEncryptionExtensionDualPassToSinglePassMigration()
        {
            TestRunner.RunTestScript("Test-AzureDiskEncryptionExtensionDualPassToSinglePassMigration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDiskEncryptionExtensionSinglePass()
        {
            TestRunner.RunTestScript("Test-AzureDiskEncryptionExtensionSinglePass");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
#endif
        public void TestAzureDiskEncryptionExtensionSinglePassRemove()
        {
            TestRunner.RunTestScript("Test-AzureDiskEncryptionExtensionSinglePassRemove");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDiskEncryptionExtensionSinglePassDisableAndRemove()
        {
            TestRunner.RunTestScript("Test-AzureDiskEncryptionExtensionSinglePassDisableAndRemove");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDiskEncryptionExtensionNonDefaultParams()
        {
            TestRunner.RunTestScript("Test-AzureDiskEncryptionExtensionNonDefaultParams");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDiskEncryptionLnxManagedDisk()
        {
            TestRunner.RunTestScript("Test-AzureDiskEncryptionLnxManagedDisk");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineBginfoExtension()
        {
            TestRunner.RunTestScript("Test-VirtualMachineBginfoExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineExtensionWithSwitch()
        {
            TestRunner.RunTestScript("Test-VirtualMachineExtensionWithSwitch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineADDomainExtension()
        {
            TestRunner.RunTestScript("Test-VirtualMachineADDomainExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineADDomainExtensionDomainJoin()
        {
            TestRunner.RunTestScript("Test-VirtualMachineADDomainExtensionDomainJoin");
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineExtensionEnableAutomaticUpgrade()
        {
            TestRunner.RunTestScript("Test-VirtualMachineExtensionEnableAutomaticUpgrade");
        }
    }
}
