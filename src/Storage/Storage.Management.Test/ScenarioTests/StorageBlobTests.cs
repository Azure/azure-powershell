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
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Management.Storage.Test.ScenarioTests
{
    public class StorageBlobTests : StorageTestRunner
    {
        public StorageBlobTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobIsVersioningEnabled()
        {
            TestRunner.RunTestScript("Test-StorageBlobIsVersioningEnabled");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobContainer()
        {
            TestRunner.RunTestScript("Test-StorageBlobContainer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobContainerEncryptionScope()
        {
            TestRunner.RunTestScript("Test-StorageBlobContainerEncryptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobContainerLegalHold()
        {
            TestRunner.RunTestScript("Test-StorageBlobContainerLegalHold");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobContainerImmutabilityPolicy()
        {
            TestRunner.RunTestScript("Test-StorageBlobContainerImmutabilityPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobServiceProperties()
        {
            TestRunner.RunTestScript("Test-StorageBlobServiceProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobORS()
        {
            TestRunner.RunTestScript("Test-StorageBlobORS");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobRestore()
        {
            TestRunner.RunTestScript("Test-StorageBlobRestore");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobChangeFeed()
        {
            TestRunner.RunTestScript("Test-StorageBlobChangeFeed");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobContainerSoftDelete()
        {
            TestRunner.RunTestScript("Test-StorageBlobContainerSoftDelete");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobLastAccessTimeTracking()
        {
            TestRunner.RunTestScript("Test-StorageBlobLastAccessTimeTracking");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobContainerVLW()
        {
            TestRunner.RunTestScript("Test-StorageBlobContainerVLW");
        }
    }
}
