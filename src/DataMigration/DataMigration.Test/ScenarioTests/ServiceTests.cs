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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.ScenarioTest.DmsTest
{
    public class ServiceTests : DataMigrationTestRunner
    {
        public ServiceTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAndGetService()
        {
            TestRunner.RunTestScript("Test-CreateAndGetService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAndGetProjectSqlSqlDb()
        {
            TestRunner.RunTestScript("Test-CreateAndGetProjectSqlSqlDb");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveService()
        {
            TestRunner.RunTestScript("Test-RemoveService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveProject()
        {
            TestRunner.RunTestScript("Test-RemoveProject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStopStartService()
        {
            TestRunner.RunTestScript("Test-StopStartDataMigrationService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToSourceSqlServer()
        {
            TestRunner.RunTestScript("Test-ConnectToSourceSqlServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToTargetSqlDb()
        {
            TestRunner.RunTestScript("Test-ConnectToTargetSqlDb");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetUserTableTask()
        {
            TestRunner.RunTestScript("Test-GetUserTableTask");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMigrateSqlSqlDb()
        {
            TestRunner.RunTestScript("Test-MigrateSqlSqlDB");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToTargetSqlDbMi()
        {
            TestRunner.RunTestScript("Test-ConnectToTargetSqlDbMi");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMigrateSqlSqlDbMi()
        {
            TestRunner.RunTestScript("Test-MigrateSqlSqlDbMi");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestValidateMigrationInputSqlSqlDbMi()
        {
            TestRunner.RunTestScript("Test-ValidateMigrationInputSqlSqlDbMi");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToSourceSqlServerSync()
        {
            TestRunner.RunTestScript("Test-ConnectToSourceSqlServerSync");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToTargetSqlDbSync()
        {
            TestRunner.RunTestScript("Test-ConnectToTargetSqlDbSync");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetUserTableSyncTask()
        {
            TestRunner.RunTestScript("Test-GetUserTableSyncTask");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestValidateMigrationInputSqlSqlDbSync()
        {
            TestRunner.RunTestScript("Test-ValidateMigrationInputSqlSqlDbSync");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMigrateSqlSqlDBSync()
        {
            TestRunner.RunTestScript("Test-MigrateSqlSqlDBSync");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToSourceMongoDb()
        {
            TestRunner.RunTestScript("Test-ConnectToSourceMongoDb");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToTargetCosmosDb()
        {
            TestRunner.RunTestScript("Test-ConnectToTargetCosmosDb");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMigrateMongoDb()
        {
            TestRunner.RunTestScript("Test-MigrateMongoDb");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToTargetSqlDbMiSync()
        {
            TestRunner.RunTestScript("Test-ConnectToTargetSqlDbMiSync");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestValidateMigrationInputSqlSqlDbMiSync()
        {
            TestRunner.RunTestScript("Test-ValidateMigrationInputSqlSqlDbMiSync");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMigrateSqlSqlDbMiSync()
        {
            TestRunner.RunTestScript("Test-MigrateSqlSqlDbMiSync");
        }
    }
}