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

using Xunit;
using Xunit.Abstractions;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.Management.Storage.Test.ScenarioTests
{
    public class StorageDataPlaneTests : StorageTestRunner
    {
        private string resourceGroupName;
        private string storageAccountName;

        public StorageDataPlaneTests(ITestOutputHelper output)
            : base(output)
        {
            resourceGroupName = TestUtilities.GenerateName();
            storageAccountName = "sto" + resourceGroupName;
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestBlob()
        {
            TestRunner.RunTestScript($"Test-Blob -ResourceGroupName \"{resourceGroupName}\" -StorageAccountName \"{storageAccountName}\"");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestFile()
        {
            TestRunner.RunTestScript($"Test-File -ResourceGroupName \"{resourceGroupName}\" -StorageAccountName \"{storageAccountName}\"");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestBlobFileCopy()
        {
            TestRunner.RunTestScript($"Test-BlobFileCopy -ResourceGroupName \"{resourceGroupName}\" -StorageAccountName \"{storageAccountName}\"");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestTable()
        {
            TestRunner.RunTestScript($"Test-Table -ResourceGroupName \"{resourceGroupName}\" -StorageAccountName \"{storageAccountName}\"");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestQueue()
        {
            TestRunner.RunTestScript($"Test-Queue -ResourceGroupName \"{resourceGroupName}\" -StorageAccountName \"{storageAccountName}\"");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestCommon()
        {
            TestRunner.RunTestScript($"Test-Common -ResourceGroupName \"{resourceGroupName}\" -StorageAccountName \"{storageAccountName}\"");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestDatalakeGen2()
        {
            TestRunner.RunTestScript($"Test-DatalakeGen2 -ResourceGroupName \"{resourceGroupName}\" -StorageAccountName \"{storageAccountName}\"");
        }
    }
}
