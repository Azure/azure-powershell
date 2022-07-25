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

namespace Microsoft.Azure.Commands.ServiceBus.Test.ScenarioTests
{
    using Microsoft.Azure.Commands.EventHub.Test.ScenarioTests;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using Xunit.Abstractions;
    public class ServiceBusServiceTests : ServiceBusTestRunner
    {
        public ServiceBusServiceTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ServiceBusNameSpace_CURD_Tests()
        {
            TestRunner.RunTestScript("ServiceBusTests");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ServiceBusNameSpaceAuth_CURD_Tests()
        {
            TestRunner.RunTestScript("ServiceBusNameSpaceAuthTests");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void ServiceBusNameSpaceEncryption_CRUD()
        {
            TestRunner.RunTestScript("EncryptionTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void ServiceBusNameSpaceMSI()
        {
            TestRunner.RunTestScript("MSITest");
        }
    }
}
