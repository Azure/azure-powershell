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


using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using ScenarioTests;
using Xunit;
using Xunit.Abstractions;

namespace StorageSyncTests
{
    /// <summary>
    /// Class RegisteredServerTests.
    /// </summary>
    public class RegisteredServerTests : StorageSyncTestRunner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisteredServerTests"/> class.
        /// </summary>
        /// <param name="output">The output.</param>
        public RegisteredServerTests(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Defines the test method TestRegisteredServer.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRegisteredServer()
        {
            TestRunner.RunTestScript("Test-RegisteredServer");
        }

        /// <summary>
        /// Defines the test method TestRegisteredServerPipeline1.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRegisteredServerPipeline1()
        {
            TestRunner.RunTestScript("Test-RegisteredServerPipeline1");
        }

        /// <summary>
        /// Defines the test method TestRegisteredServerPipeline2.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRegisteredServerPipeline2()
        {
            TestRunner.RunTestScript("Test-RegisteredServerPipeline2");
        }

        /// <summary>
        /// Defines the test method TestNewRegisteredServer.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewRegisteredServer()
        {
            var value = HttpMockServer.GetCurrentMode();
            TestRunner.RunTestScript("Test-NewRegisteredServer");
        }

        /// <summary>
        /// Defines the test method TestNewRegisteredServerParentObject.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewRegisteredServerParentObject()
        {
            TestRunner.RunTestScript("Test-NewRegisteredServerParentObject");
        }

        /// <summary>
        /// Defines the test method TestNewRegisteredServerParentResourceId.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewRegisteredServerParentResourceId()
        {
            TestRunner.RunTestScript("Test-NewRegisteredServerParentResourceId");
        }

        /// <summary>
        /// Defines the test method TestGetRegisteredServer.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRegisteredServer()
        {
            TestRunner.RunTestScript("Test-GetRegisteredServer");
        }

        /// <summary>
        /// Defines the test method TestGetRegisteredServerParentObject.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRegisteredServerParentObject()
        {
            TestRunner.RunTestScript("Test-GetRegisteredServerParentObject");
        }

        /// <summary>
        /// Defines the test method TestGetRegisteredServerParentResourceId.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRegisteredServerParentResourceId()
        {
            TestRunner.RunTestScript("Test-GetRegisteredServerParentResourceId");
        }

        /// <summary>
        /// Defines the test method TestGetRegisteredServers.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRegisteredServers()
        {
            TestRunner.RunTestScript("Test-GetRegisteredServers");
        }

        /// <summary>
        /// Defines the test method TestRemoveRegisteredServer.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveRegisteredServer()
        {
            TestRunner.RunTestScript("Test-RemoveRegisteredServer");
        }

        /// <summary>
        /// Defines the test method TestRemoveRegisteredServerResourceId.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveRegisteredServerResourceId()
        {
            TestRunner.RunTestScript("Test-RemoveRegisteredServerResourceId");
        }

        /// <summary>
        /// Defines the test method TestRemoveRegisteredServerInputObject.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveRegisteredServerInputObject()
        {
            TestRunner.RunTestScript("Test-RemoveRegisteredServerInputObject");
        }
    }
}
