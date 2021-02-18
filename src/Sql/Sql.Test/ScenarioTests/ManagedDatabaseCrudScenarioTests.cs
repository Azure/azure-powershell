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
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class ManagedDatabaseCrudScenarioTests : SqlTestsBase
    {
        protected override void SetupManagementClients(RestTestFramework.MockContext context)
        {
            var sqlClient = GetSqlClient(context);
            var newResourcesClient = GetResourcesClient(context);
            var networkClient = GetNetworkClient(context);
            Helper.SetupSomeOfManagementClients(sqlClient, newResourcesClient, networkClient);
        }

        public ManagedDatabaseCrudScenarioTests(ITestOutputHelper output) : base(output)
        {
<<<<<<< HEAD
=======
            base.resourceTypesToIgnoreApiVersion = new string[] {
                "Microsoft.Sql/managedInstances",
                "Microsoft.Sql/managedInstances/databases",
                "Microsoft.Sql/managedInstances/managedDatabases"
            };
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateManagedDatabase()
        {
            RunPowerShellTest("Test-CreateManagedDatabase");
        }

<<<<<<< HEAD
        [Fact]
=======
        [Fact(Skip = "Skip due to bug in ignore api version plus long setup time for managed instance")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagedDatabase()
        {
            RunPowerShellTest("Test-GetManagedDatabase");
        }

<<<<<<< HEAD
        [Fact]
=======
        [Fact(Skip = "Skip due to long setup time for managed instance")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveManagedDatabase()
        {
            RunPowerShellTest("Test-RemoveManagedDatabase");
        }

<<<<<<< HEAD
        [Fact]
=======
        [Fact(Skip = "Skip due to long setup time for managed instance")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreManagedDatabase()
        {
            RunPowerShellTest("Test-RestoreManagedDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
<<<<<<< HEAD
=======
        public void TestRestoreDeletedManagedDatabase()
        {
            RunPowerShellTest("Test-RestoreDeletedManagedDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public void TestGetManagedDatabaseGeoBackup()
        {
            RunPowerShellTest("Test-GetManagedDatabaseGeoBackup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGeoRestoreManagedDatabase()
        {
            RunPowerShellTest("Test-GeoRestoreManagedDatabase");
        }
    }
}
