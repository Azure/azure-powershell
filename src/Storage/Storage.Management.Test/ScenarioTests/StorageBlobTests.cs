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


using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Management.Storage.Test.ScenarioTests
{
    public class StorageBlobTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public StorageBlobTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobIsVersioningEnabled()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-StorageBlobIsVersioningEnabled");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobContainer()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-StorageBlobContainer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobContainerEncryptionScope()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-StorageBlobContainerEncryptionScope");
        }        

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobContainerLegalHold()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-StorageBlobContainerLegalHold");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobContainerImmutabilityPolicy()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-StorageBlobContainerImmutabilityPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobServiceProperties()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-StorageBlobServiceProperties");
        }    

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobORS()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-StorageBlobORS");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobRestore()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-StorageBlobRestore");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageBlobChangeFeed()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-StorageBlobChangeFeed");
        }        
    }
}
