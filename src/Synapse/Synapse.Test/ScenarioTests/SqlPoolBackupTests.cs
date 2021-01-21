using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Microsoft.Azure.Commands.Synapse.Test.ScenarioTests
{
    public class SqlPoolBackupTests: SynapseTestBase
    {
        public XunitTracingInterceptor _logger;

        public SqlPoolBackupTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlPoolRestorePoint(){
            NewInstance.RunPsTest(
                _logger,
                "Test-SqlPoolRestorePoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlPoolGeoBackup()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-SqlPoolGeoBackup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDroppedSqlPool()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-DroppedSqlPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreFromRestorePoint()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-RestoreFromRestorePoint");
        }

        [Fact(Skip = "Currently the test case cannot pass due to some backend issues.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreFromBackup(){
            NewInstance.RunPsTest(
                _logger,
                "Test-RestoreFromBackup");
        }
    }
}
