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


using ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace StorageSyncTests
{
    /// <summary>
    /// Class CloudEndpointTests.
    /// </summary>
    public class CloudEndpointTests : StorageSyncTestRunner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudEndpointTests"/> class.
        /// </summary>
        /// <param name="output">The output.</param>
        public CloudEndpointTests(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Defines the test method TestCloudEndpoint.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCloudEndpoint()
        {
            TestRunner.RunTestScript("Test-CloudEndpoint");
        }

        /// <summary>
        /// Defines the test method TestNewCloudEndpoint.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewCloudEndpoint()
        {
            TestRunner.RunTestScript("Test-NewCloudEndpoint");
        }

        /// <summary>
        /// Defines the test method TestGetCloudEndpoint.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetCloudEndpoint()
        {
            TestRunner.RunTestScript("Test-GetCloudEndpoint");
        }

        /// <summary>
        /// Defines the test method TestGetCloudEndpointParentObject.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetCloudEndpointParentObject()
        {
            TestRunner.RunTestScript("Test-GetCloudEndpointParentObject");
        }

        /// <summary>
        /// Defines the test method TestGetCloudEndpointParentResourceId.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetCloudEndpointParentResourceId()
        {
            TestRunner.RunTestScript("Test-GetCloudEndpointParentResourceId");
        }


        /// <summary>
        /// Defines the test method TestGetCloudEndpoints.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetCloudEndpoints()
        {
            TestRunner.RunTestScript("Test-GetCloudEndpoints");
        }

        /// <summary>
        /// Defines the test method TestRemoveCloudEndpoint.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveCloudEndpoint()
        {
            TestRunner.RunTestScript("Test-RemoveCloudEndpoint");
        }

        /// <summary>
        /// Defines the test method TestRemoveCloudEndpointResourceId.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveCloudEndpointResourceId()
        {
            TestRunner.RunTestScript("Test-RemoveCloudEndpointResourceId");
        }

        /// <summary>
        /// Defines the test method TestRemoveCloudEndpointInputObject.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveCloudEndpointInputObject()
        {
            TestRunner.RunTestScript("Test-RemoveCloudEndpointInputObject");
        }

    }
}
