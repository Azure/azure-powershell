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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ScenarioTest.DmsTest
{
    public class ServiceTests
    {
        public ServiceTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAndGetService()
        {
            DataMigrationTestController.NewInstance.RunPsTest("Test-CreateAndGetService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAndGetProjectSqlSqlDb()
        {
            DataMigrationTestController.NewInstance.RunPsTest("Test-CreateAndGetProjectSqlSqlDb");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveService()
        {
            DataMigrationTestController.NewInstance.RunPsTest("Test-RemoveService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveProject()
        {
            DataMigrationTestController.NewInstance.RunPsTest("Test-RemoveProject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStopStartService()
        {
            DataMigrationTestController.NewInstance.RunPsTest("Test-StopStartDataMigrationService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToSourceSqlServer()
        {
            DataMigrationTestController.NewInstance.RunPsTest("Test-ConnectToSourceSqlServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToTargetSqlDb()
        {
            DataMigrationTestController.NewInstance.RunPsTest("Test-ConnectToTargetSqlDb");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetUserTableTask()
        {
            DataMigrationTestController.NewInstance.RunPsTest("Test-GetUserTableTask");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMigrateSqlSqlDb()
        {
            DataMigrationTestController.NewInstance.RunPsTest("Test-MigrateSqlSqlDB");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectToTargetSqlDbMi()
        {
            DataMigrationTestController.NewInstance.RunPsTest("Test-ConnectToTargetSqlDbMi");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMigrateSqlSqlDbMi()
        {
            DataMigrationTestController.NewInstance.RunPsTest("Test-MigrateSqlSqlDbMi");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestValidateMigrationInputSqlSqlDbMi()
        {
            DataMigrationTestController.NewInstance.RunPsTest("Test-ValidateMigrationInputSqlSqlDbMi");
        }
    }
}