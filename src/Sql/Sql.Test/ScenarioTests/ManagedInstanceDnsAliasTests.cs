using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class ManagedInstanceDnsAliasTests : SqlTestsBase
    {
        protected override void SetupManagementClients(RestTestFramework.MockContext context)
        {
            var sqlClient = GetSqlClient(context);
            var newResourcesClient = GetResourcesClient(context);
            var networkClient = GetNetworkClient(context);
            Helper.SetupSomeOfManagementClients(sqlClient, newResourcesClient, networkClient);
        }

        public ManagedInstanceDnsAliasTests(ITestOutputHelper output) : base(output)
        {
            base.resourceTypesToIgnoreApiVersion = new string[] { "Microsoft.Sql/managedInstances" };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateManagedInstanceDnsAlias()
        {
            RunPowerShellTest("Test-ManagedInstanceDnsAliasCRUDOperations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedInstanceDnsAliasGetAndMoveOperations()
        {
            RunPowerShellTest("Test-ManagedInstanceDnsAliasGetAndMoveOperations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedInstanceDnsAliasPipingScenarios()
        {
            RunPowerShellTest("Test-ManagedInstanceDnsAliasPipingScenarios");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedInstanceDnsAliasErrorHandlings()
        {
            RunPowerShellTest("Test-ManagedInstanceDnsAliasErrorHandling");
        }
    }
}
