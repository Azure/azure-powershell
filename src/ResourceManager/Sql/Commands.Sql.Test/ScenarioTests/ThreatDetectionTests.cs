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
    public class ThreatDetectionTests : SqlTestsBase
    {
        protected override void SetupManagementClients(RestTestFramework.MockContext context)
        {
            var sqlClient = GetSqlClient(context);
            var storageV2Client = GetStorageV2Client(context);
            var newResourcesClient = GetResourcesClient(context);
            Helper.SetupSomeOfManagementClients(sqlClient, storageV2Client, newResourcesClient);
        }

        public ThreatDetectionTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThreatDetectionGetDefualtPolicy()
        {
            RunPowerShellTest("Test-ThreatDetectionGetDefualtPolicy");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThreatDetectionDatabaseUpdatePolicy()
        {
            RunPowerShellTest("Test-ThreatDetectionDatabaseUpdatePolicy");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThreatDetectionServerUpdatePolicy()
        {
            RunPowerShellTest("Test-ThreatDetectionServerUpdatePolicy");
        }


#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisablingThreatDetection()
        {
            RunPowerShellTest("Test-DisablingThreatDetection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InvalidArgumentsThreatDetection()
        {
            RunPowerShellTest("Test-InvalidArgumentsThreatDetection");
        }
    }
}
