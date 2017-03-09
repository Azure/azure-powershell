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

using Microsoft.Azure.Commands.ScenarioTest.Mocks;
using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class DatabaseCrudStretchTests : SqlTestsBase
    {
        /// <summary>
        /// Follow the way how AuditingTests setup their manangement clients
        /// Only overide SetupManagementClients() here because stretch database 
        /// tests in this test suite now use V2 version of storage client
        /// </summary>
        protected override void SetupManagementClients(RestTestFramework.MockContext context)
        {
            var sqlCSMClient = GetSqlClient();
            var storageClient = GetStorageV2Client();

            // TODO, Remove the MockDeploymentFactory call when the test is re-recorded
            //
            var resourcesClient = MockDeploymentClientFactory.GetResourceClient(GetResourcesClient());
            var authorizationClient = GetAuthorizationManagementClient();
            helper.SetupSomeOfManagementClients(sqlCSMClient, storageClient, resourcesClient,
                authorizationClient);
        }

        public DatabaseCrudStretchTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStretchDatabaseCreate()
        {
            RunPowerShellTest("Test-CreateStretchDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStretchDatabaseUpdate()
        {
            RunPowerShellTest("Test-UpdateStretchDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStretchDatabaseGet()
        {
            RunPowerShellTest("Test-GetStretchDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStretchDatabaseRemove()
        {
            RunPowerShellTest("Test-RemoveStretchDatabase");
        }
    }
}
