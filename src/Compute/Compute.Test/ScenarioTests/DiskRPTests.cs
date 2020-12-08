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
    public class DiskRPTests : ComputeTestRunner
    {
        public DiskRPTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisk()
        {
            TestRunner.RunTestScript("Test-Disk");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSnapshot()
        {
            TestRunner.RunTestScript("Test-Snapshot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiskEncrypt()
        {
            TestRunner.RunTestScript("Test-DiskEncrypt");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSnapshotEncrypt()
        {
            TestRunner.RunTestScript("Test-SnapshotEncrypt");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiskUpload()
        {
            TestRunner.RunTestScript("Test-DiskUpload");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiskEncryptionSet()
        {
            TestRunner.RunTestScript("Test-DiskEncryptionSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiskEncryptionSetConfigEncryptionType()
        {
            TestRunner.RunTestScript("Test-DiskEncryptionSetConfigEncryptionType");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiskAccessObject()
        {
            TestRunner.RunTestScript("Test-DiskAccessObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiskConfigDiskAccessNetworkAccess()
        {
            TestRunner.RunTestScript("Test-DiskConfigDiskAccessNetworkAccess");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSnapshotConfigDiskAccessNetworkPolicy()
        {
            TestRunner.RunTestScript("Test-SnapshotConfigDiskAccessNetworkPolicy");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiskConfigTierSectorSizeReadOnly()
        {
            TestRunner.RunTestScript("Test-DiskConfigTierSectorSizeReadOnly");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetDiskEncryptionSetAssociatedResource()
        {
            TestRunner.RunTestScript("Test-GetDiskEncryptionSetAssociatedResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSnapshotDuplicateCreationFails()
        {
            TestRunner.RunTestScript("Test-SnapshotDuplicateCreationFails");
        }
    }
}
