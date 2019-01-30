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
    public class ThreatDetectionClassicStorageTests : SqlTestsBase
    {
        protected override void SetupManagementClients(RestTestFramework.MockContext context)
        {
            var sqlClient = GetSqlClient(context);
            var storageV2Client = GetStorageManagementClient(context);
            var newResourcesClient = GetResourcesClient(context);
            Helper.SetupSomeOfManagementClients(sqlClient, storageV2Client, newResourcesClient);
        }

        public ThreatDetectionClassicStorageTests(ITestOutputHelper output) : base(output)
        {
        }

        // Commenting out the test until a fix will be added
        // [Fact]
        // [Trait(Category.AcceptanceType, Category.CheckIn)]
        // See issue https://github.com/Azure/azure-powershell/issues/6601
        public void ThreatDetectionUpdatePolicyWithClassicStorage()
        {
            RunPowerShellTest("Test-ThreatDetectionUpdatePolicyWithClassicStorage");
        }
    }
}
