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

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;
using System.Diagnostics;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Storage;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.Management.Storage.Test.ScenarioTests
{
    public class StorageDataPlaneTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;
        private string resourceGroupName;
        private string storageAccountName;

        public StorageDataPlaneTests(ITestOutputHelper output)
        {
            resourceGroupName = TestUtilities.GenerateName();
            storageAccountName = "sto" + resourceGroupName;
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestBlob()
        {
            TestController.NewInstance.RunPsTest(_logger, $"Test-Blob -ResourceGroupName \"{resourceGroupName}\" -StorageAccountName \"{storageAccountName}\"");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestFile()
        {
            TestController.NewInstance.RunPsTest(_logger, $"Test-File -ResourceGroupName \"{resourceGroupName}\" -StorageAccountName \"{storageAccountName}\"");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestBlobFileCopy()
        {
            TestController.NewInstance.RunPsTest(_logger, $"Test-BlobFileCopy -ResourceGroupName \"{resourceGroupName}\" -StorageAccountName \"{storageAccountName}\"");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestTable()
        {
            TestController.NewInstance.RunPsTest(_logger, $"Test-Table -ResourceGroupName \"{resourceGroupName}\" -StorageAccountName \"{storageAccountName}\"");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestQueue()
        {
            TestController.NewInstance.RunPsTest(_logger, $"Test-Queue -ResourceGroupName \"{resourceGroupName}\" -StorageAccountName \"{storageAccountName}\"");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestCommon()
        {
            TestController.NewInstance.RunPsTest(_logger, $"Test-Common -ResourceGroupName \"{resourceGroupName}\" -StorageAccountName \"{storageAccountName}\"");
        }
    }
}
