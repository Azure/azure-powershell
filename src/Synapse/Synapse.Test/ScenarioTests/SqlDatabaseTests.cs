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

namespace Microsoft.Azure.Commands.Synapse.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using ServiceManagement.Common.Models;
    using Xunit;

    public class SqlDatabaseTests : SynapseTestBase
    {
        public XunitTracingInterceptor _logger;

        public SqlDatabaseTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSynapseSqlDatabase()
        {
            string testResourceGroupName = SynapseTestBase.TestResourceGroupName;
            if (string.IsNullOrEmpty(testResourceGroupName))
            {
                testResourceGroupName = nameof(TestResourceGroupName);
            }

            string testWorkspaceName = SynapseTestBase.TestWorkspaceName;
            if (string.IsNullOrEmpty(testWorkspaceName))
            {
                testWorkspaceName = nameof(TestWorkspaceName);
            }

            SynapseTestBase.NewInstance.RunPsTest(
                _logger,
                string.Format(
                "Test-SynapseSqlDatabase -resourceGroupName '{0}' -workspaceName '{1}'",
                testResourceGroupName,
                testWorkspaceName));
        }
    }
}
