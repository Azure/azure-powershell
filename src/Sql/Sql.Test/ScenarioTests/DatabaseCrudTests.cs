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
    public class DatabaseCrudTests : SqlTestsBase
    {
        public DatabaseCrudTests(ITestOutputHelper output) : base(output)
        {
        }

        protected override void SetupManagementClients(Rest.ClientRuntime.Azure.TestFramework.MockContext context)
        {
            // Only SqlClient is needed.
            var sqlClient = GetSqlClient(context);
            var newResourcesClient = GetResourcesClient(context);
            Helper.SetupSomeOfManagementClients(sqlClient, newResourcesClient);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseCreate()
        {
            RunPowerShellTest("Test-CreateDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVcoreDatabaseCreate()
        {
            RunPowerShellTest("Test-CreateVcoreDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVcoreDatabaseCreateWithLicenseType()
        {
            RunPowerShellTest("Test-CreateVcoreDatabaseWithLicenseType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateServerlessDatabase()
        {
            RunPowerShellTest("Test-CreateServerlessDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseCreateWithSampleName()
        {
            RunPowerShellTest("Test-CreateDatabaseWithSampleName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseCreateWithZoneRedundancy()
        {
            RunPowerShellTest("Test-CreateDatabaseWithZoneRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseUpdate()
        {
            RunPowerShellTest("Test-UpdateDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVcoreDatabaseUpdate()
        {
            RunPowerShellTest("Test-UpdateVcoreDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVcoreDatabaseUpdateWithLicenseType()
        {
            RunPowerShellTest("Test-UpdateVcoreDatabaseLicenseType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseUpdateWithZoneRedundancy()
        {
            RunPowerShellTest("Test-UpdateDatabaseWithZoneRedundant");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseUpdateWithZoneRedundancyNotSpecified()
        {
            RunPowerShellTest("Test-UpdateDatabaseWithZoneRedundantNotSpecified");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateServerlessDatabase()
        {
            RunPowerShellTest("Test-UpdateServerlessDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseRename()
        {
            RunPowerShellTest("Test-RenameDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseGet()
        {
            RunPowerShellTest("Test-GetDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseGetWithZoneRedundancy()
        {
            RunPowerShellTest("Test-GetDatabaseWithZoneRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseRemove()
        {
            RunPowerShellTest("Test-RemoveDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseCancelOperation()
        {
            RunPowerShellTest("Test-CancelDatabaseOperation");
        }
    }
}
