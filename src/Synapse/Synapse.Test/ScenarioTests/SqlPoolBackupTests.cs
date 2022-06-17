using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Synapse.Test.ScenarioTests
{
    public class SqlPoolBackupTests: SynapseTestRunner
    {
        public SqlPoolBackupTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlPoolRestorePoint(){
            TestRunner.RunTestScript("Test-SqlPoolRestorePoint");
        }

        [Fact(Skip = "Not recordable. Geo backup requires one day to complete.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlPoolGeoBackup()
        {
            TestRunner.RunTestScript("Test-SqlPoolGeoBackup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDroppedSqlPool()
        {
            TestRunner.RunTestScript("Test-DroppedSqlPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreFromRestorePoint()
        {
            TestRunner.RunTestScript("Test-RestoreFromRestorePoint");
        }

        [Fact(Skip = "Currently the test case cannot pass due to some backend issues.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreFromBackup(){
            TestRunner.RunTestScript("Test-RestoreFromBackup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreFromDroppedSqlPool()
        {
            TestRunner.RunTestScript("Test-RestoreFromDroppedSqlPool");
        }
    }
}
