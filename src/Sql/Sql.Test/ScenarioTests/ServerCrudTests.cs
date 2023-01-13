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

using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class ServerCrudTests : SqlTestRunner
    {
        public ServerCrudTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerCreate()
        {
            TestRunner.RunTestScript("Test-CreateServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerUpdate()
        {
            TestRunner.RunTestScript("Test-UpdateServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerGet()
        {
            TestRunner.RunTestScript("Test-GetServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerRemove()
        {
            TestRunner.RunTestScript("Test-RemoveServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerCreateWithIdentity()
        {
            TestRunner.RunTestScript("Test-CreateServerWithIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerUpdateWithIdentity()
        {
            TestRunner.RunTestScript("Test-UpdateServerWithIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerCreateWithFederatedClientId()
        {
            TestRunner.RunTestScript("Test-CreateServerWithFederatedClientId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerUpdateWithFederatedClientId()
        {
            TestRunner.RunTestScript("Test-UpdatingServerWithFederatedClientId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerUpdateWithoutIdentity()
        {
            TestRunner.RunTestScript("Test-UpdateServerWithoutIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerCreateAndGetWithPublicNetworkAccess()
        {
            TestRunner.RunTestScript("Test-CreateAndGetServerWithPublicNetworkAccess");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerUpdateWithPublicNetworkAccess()
        {
            TestRunner.RunTestScript("Test-UpdateServerWithPublicNetworkAccess");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestOutboundFirewallRulesCRUD()
        {
            TestRunner.RunTestScript("Test-OutboundFirewallRulesCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerCreateAndGetWithRestrictOutboundNetworkAccess()
        {
            TestRunner.RunTestScript("Test-CreateAndGetServerWithRestrictOutboundNetworkAccess");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerUpdateWithRestrictOutboundNetworkAccess()
        {
            TestRunner.RunTestScript("Test-UpdateServerWithRestrictOutboundNetworkAccess");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateandUpdateServerWithMinimalTlsVersion()
        {
            TestRunner.RunTestScript("Test-CreateandUpdateServerWithMinimalTlsVersion");
        }
    }
}
