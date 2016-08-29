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
    public class ThreatDetectionTests : SqlTestsBase
    {
        protected override void SetupManagementClients(RestTestFramework.MockContext context)
        {
            var sqlCSMClient = GetSqlClient();
            var storageClient = GetStorageClient();
            var storageV2Client = GetStorageV2Client();
            //TODO, Remove the MockDeploymentFactory call when the test is re-recorded
            var resourcesClient = MockDeploymentClientFactory.GetResourceClient(GetResourcesClient());
            var authorizationClient = GetAuthorizationManagementClient();
            helper.SetupSomeOfManagementClients(sqlCSMClient, storageClient, storageV2Client, resourcesClient,
                authorizationClient);
        }

        public ThreatDetectionTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void ThreatDetectionGetDefualtPolicy()
        {
            RunPowerShellTest("Test-ThreatDetectionGetDefualtPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void ThreatDetectionDatabaseUpdatePolicy()
        {
            RunPowerShellTest("Test-ThreatDetectionDatabaseUpdatePolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void ThreatDetectionServerUpdatePolicy()
        {
            RunPowerShellTest("Test-ThreatDetectionServerUpdatePolicy");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void DisablingThreatDetection()
        {
            RunPowerShellTest("Test-DisablingThreatDetection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void InvalidArgumentsThreatDetection()
        {
            RunPowerShellTest("Test-InvalidArgumentsThreatDetection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void ThreatDetectionOnV2Server()
        {
            RunPowerShellTest("Test-ThreatDetectionOnV2Server");
        }
    }
}
