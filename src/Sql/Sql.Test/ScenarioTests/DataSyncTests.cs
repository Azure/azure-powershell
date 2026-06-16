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
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class DataSyncTests : SqlTestRunner
    {
        public DataSyncTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncAgentCreate()
        {
            TestRunner.RunTestScript("Test-CreateSyncAgent");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncAgentsGetAndList()
        {
            TestRunner.RunTestScript("Test-GetAndListSyncAgents");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncAgentRemove()
        {
            TestRunner.RunTestScript("Test-RemoveSyncAgent");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncAgentKeyCreate()
        {
            TestRunner.RunTestScript("Test-CreateSyncAgentKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncAgentLinkedDatabaseList()
        {
            TestRunner.RunTestScript("Test-listSyncAgentLinkedDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncGroupCreate()
        {
            TestRunner.RunTestScript("Test-CreateSyncGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncGroupUpdate()
        {
            TestRunner.RunTestScript("Test-UpdateSyncGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncGroupsGetAndList()
        {
            TestRunner.RunTestScript("Test-GetAndListSyncGroups");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncGroupHubSchemaRefreshAndGet()
        {
            TestRunner.RunTestScript("Test-RefreshAndGetSyncGroupHubSchema");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncGroupRemove()
        {
            TestRunner.RunTestScript("Test-RemoveSyncGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncMemberCreate()
        {
            TestRunner.RunTestScript("Test-CreateSyncMember");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncMembersGetAndList()
        {
            TestRunner.RunTestScript("Test-GetAndListSyncMembers");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncMemberUpdate()
        {
            TestRunner.RunTestScript("Test-UpdateSyncMember");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncMemberSchemaRefreshAndGet()
        {
            TestRunner.RunTestScript("Test-RefreshAndGetSyncMemberSchema");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncMemberRemove()
        {
            TestRunner.RunTestScript("Test-RemoveSyncMember");
        }
    }
}
