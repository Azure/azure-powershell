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


using Microsoft.Azure.Commands.StorageSync.Test.ScenarioTests;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace StorageSync.Test.ScenarioTests
{
    public class RegisteredServerTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public RegisteredServerTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(_logger = new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRegisteredServer()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RegisteredServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewRegisteredServer()
        {
            var value = HttpMockServer.GetCurrentMode();
            TestController.NewInstance.RunPsTest(_logger, "Test-NewRegisteredServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewRegisteredServerParentObject()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-NewRegisteredServerParentObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewRegisteredServerParentResourceId()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-NewRegisteredServerParentResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRegisteredServer()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetRegisteredServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRegisteredServerParentObject()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetRegisteredServerParentObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRegisteredServerParentResourceId()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetRegisteredServerParentResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRegisteredServers()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetRegisteredServers");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveRegisteredServer()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveRegisteredServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveRegisteredServerResourceId()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveRegisteredServerResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveRegisteredServerInputObject()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveRegisteredServerInputObject");
        }
    }
}
