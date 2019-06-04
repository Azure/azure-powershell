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

using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ScenarioTest.DmsTest
{
    public class ServiceTests
    {
        public XunitTracingInterceptor _logger;

        public ServiceTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAndGetService()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-CreateAndGetService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAndGetProjectSqlSqlDb()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-CreateAndGetProjectSqlSqlDb");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveService()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-RemoveService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveProject()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-RemoveProject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStopStartService()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-StopStartDataMigrationService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToSourceSqlServer()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-ConnectToSourceSqlServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToTargetSqlDb()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-ConnectToTargetSqlDb");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetUserTableTask()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-GetUserTableTask");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMigrateSqlSqlDb()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-MigrateSqlSqlDB");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToTargetSqlDbMi()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-ConnectToTargetSqlDbMi");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMigrateSqlSqlDbMi()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-MigrateSqlSqlDbMi");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestValidateMigrationInputSqlSqlDbMi()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-ValidateMigrationInputSqlSqlDbMi");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToSourceSqlServerSync()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-ConnectToSourceSqlServerSync");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToTargetSqlDbSync()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-ConnectToTargetSqlDbSync");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetUserTableSyncTask()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-GetUserTableSyncTask");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestValidateMigrationInputSqlSqlDbSync()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-ValidateMigrationInputSqlSqlDbSync");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMigrateSqlSqlDBSync()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-MigrateSqlSqlDBSync");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToSourceMongoDb()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-ConnectToSourceMongoDb");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToTargetCosmosDb()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-ConnectToTargetCosmosDb");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMigrateMongoDb()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-MigrateMongoDb");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToTargetSqlDbMiSync()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-ConnectToTargetSqlDbMiSync");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestValidateMigrationInputSqlSqlDbMiSync()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-ValidateMigrationInputSqlSqlDbMiSync");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMigrateSqlSqlDbMiSync()
        {
            DataMigrationTestController.NewInstance.RunPsTest(_logger, "Test-MigrateSqlSqlDbMiSync");
        }
    }
}