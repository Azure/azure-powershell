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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class DataSyncTests : SqlTestsBase
    {
        public DataSyncTests(ITestOutputHelper output) : base(output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncAgentCreate()
        {
            RunPowerShellTest("Test-CreateSyncAgent");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncAgentsGetAndList()
        {
            RunPowerShellTest("Test-GetAndListSyncAgents");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncAgentRemove()
        {
            RunPowerShellTest("Test-RemoveSyncAgent");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncAgentKeyCreate()
        {
            RunPowerShellTest("Test-CreateSyncAgentKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncAgentLinkedDatabaseList()
        {
            RunPowerShellTest("Test-listSyncAgentLinkedDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncGroupCreate()
        {
            RunPowerShellTest("Test-CreateSyncGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncGroupUpdate()
        {
            RunPowerShellTest("Test-UpdateSyncGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncGroupsGetAndList()
        {
            RunPowerShellTest("Test-GetAndListSyncGroups");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncGroupHubSchemaRefreshAndGet()
        {
            RunPowerShellTest("Test-RefreshAndGetSyncGroupHubSchema");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncGroupRemove()
        {
            RunPowerShellTest("Test-RemoveSyncGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncMemberCreate()
        {
            RunPowerShellTest("Test-CreateSyncMember");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncMembersGetAndList()
        {
            RunPowerShellTest("Test-GetAndListSyncMembers");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncMemberUpdate()
        {
            RunPowerShellTest("Test-UpdateSyncMember");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncMemberSchemaRefreshAndGet()
        {
            RunPowerShellTest("Test-RefreshAndGetSyncMemberSchema");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncMemberRemove()
        {
            RunPowerShellTest("Test-RemoveSyncMember");
        }                       
    }
}
