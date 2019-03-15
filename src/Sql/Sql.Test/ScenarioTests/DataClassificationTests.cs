using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class DataClassificationTests : SqlTestsBase
    {
        public DataClassificationTests(ITestOutputHelper output) : base(output)
        {
        }

        protected override void SetupManagementClients(RestTestFramework.MockContext context)
        {
            var sqlClient = GetSqlClient(context);
            var newResourcesClient = GetResourcesClient(context);
            var networkClient = GetNetworkClient(context);
            Helper.SetupSomeOfManagementClients(sqlClient, newResourcesClient, networkClient);
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDataClassificationOnSqlDatabase()
        {
            RunPowerShellTest("Test-DataClassificationOnSqlDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestErrorIsThrownWhenInvalidClassificationIsSet()
        {
            RunPowerShellTest("Test-ErrorIsThrownWhenInvalidClassificationIsSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBasicDataClassificationOnSqlManagedDatabase()
        {
            RunPowerShellTest("Test-BasicDataClassificationOnSqlManagedDatabase");
        }
    }
}
