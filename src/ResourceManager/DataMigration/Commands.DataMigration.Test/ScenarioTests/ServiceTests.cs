// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
    }
}