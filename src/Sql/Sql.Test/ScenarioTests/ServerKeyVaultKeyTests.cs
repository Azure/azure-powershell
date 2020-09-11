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
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class ServerKeyVaultKeyTests : SqlTestsBase
    {


        protected override void SetupManagementClients(RestTestFramework.MockContext context)
        {
            var sqlClient = GetSqlClient(context);
            var newResourcesClient = GetResourcesClient(context);
            var graphClient = GetGraphClient(context);
            var networkClient = GetNetworkClient(context);
            var keyVaultClient = GetKeyVaultClient(context);
            Helper.SetupSomeOfManagementClients(sqlClient, newResourcesClient, networkClient, graphClient, keyVaultClient);
        }

        public ServerKeyVaultKeyTests(ITestOutputHelper output) : base(output)
        {
            base.resourceTypesToIgnoreApiVersion = new string[] {
                "Microsoft.Sql/servers"
            };
        }

        [Fact(Skip = "Requires hardcoded resource 'akvtdekeyvaultcl'")]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestServerKeyVaultKeyAdd()
        {
            RunPowerShellTest("Test-AddServerKeyVaultKey");
        }

        [Fact(Skip = "Requires hardcoded resource 'akvtdekeyvaultcl'")]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestServerKeyVaultKeyGet()
        {
            RunPowerShellTest("Test-GetServerKeyVaultKey");
        }

        [Fact(Skip = "TODO: only works for live mode. Mihymel will fix the test issue for Create-ServerKeyVaultKeyTestEnvironment")]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestServerKeyVaultKeyRemove()
        {
            RunPowerShellTest("Test-RemoveServerKeyVaultKey");
        }
    }
}
