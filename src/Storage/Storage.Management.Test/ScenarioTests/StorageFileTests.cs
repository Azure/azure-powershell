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
    public class StorageFileTests : StorageTestRunner
    {
        public StorageFileTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageFileShare()
        {
            TestRunner.RunTestScript("Test-StorageFileShare");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageFileShareGetUsage()
        {
            TestRunner.RunTestScript("Test-StorageFileShareGetUsage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestShareSoftDeletee()
        {
            TestRunner.RunTestScript("Test-ShareSoftDelete");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestShareSnapshot()
        {
            TestRunner.RunTestScript("Test-ShareSnapshot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFileServiceProperties()
        {
            TestRunner.RunTestScript("Test-FileServiceProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureStorageShareNFS()
        {
            TestRunner.RunTestScript("Test-AzureStorageShareNFS");
        }
    }
}
