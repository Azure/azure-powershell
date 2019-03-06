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
using Xunit.Abstractions;

namespace ScenarioTests
{
    /// <summary>
    /// Class StorageSyncTests.
    /// </summary>
    public class StorageSyncTests
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly XunitTracingInterceptor _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageSyncTests"/> class.
        /// </summary>
        /// <param name="output">The output.</param>
        public StorageSyncTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        /// <summary>
        /// Defines the test method TestStorageSync.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageSync()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-StorageSync");
        }
    }
}
