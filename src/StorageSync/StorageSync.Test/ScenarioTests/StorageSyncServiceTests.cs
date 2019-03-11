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


using ScenarioTests;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace StorageSyncTests
{
    /// <summary>
    /// Class StorageSyncServiceTests.
    /// </summary>
    public class StorageSyncServiceTests
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly XunitTracingInterceptor _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageSyncServiceTests"/> class.
        /// </summary>
        /// <param name="output">The output.</param>
        public StorageSyncServiceTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(_logger = new XunitTracingInterceptor(output));
        }

        /// <summary>
        /// Defines the test method TestStorageSyncService.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageSyncService()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-StorageSyncService");
        }

        /// <summary>
        /// Defines the test method TestNewStorageSyncService.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewStorageSyncService()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-NewStorageSyncService");
        }

        /// <summary>
        /// Defines the test method TestGetStorageSyncService.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetStorageSyncService()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetStorageSyncService");
        }

        /// <summary>
        /// Defines the test method TestGetStorageSyncServices.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetStorageSyncServices()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetStorageSyncServices");
        }

        /// <summary>
        /// Defines the test method TestRemoveStorageSyncService.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveStorageSyncService()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveStorageSyncService");
        }

        /// <summary>
        /// Defines the test method TestRemoveStorageSyncServiceInputObject.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveStorageSyncServiceInputObject()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveStorageSyncServiceInputObject");
        }

        /// <summary>
        /// Defines the test method TestRemoveStorageSyncServiceResourceId.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveStorageSyncServiceResourceId()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveStorageSyncServiceResourceId");
        }

    }
}
