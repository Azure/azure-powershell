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
    using Xunit;

    public class SparkJobTests : SynapseTestRunner
    {
        public SparkJobTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact(Skip = "Job submission through Service Principal has not been supported.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSynapseSparkJob()
        {
            string resourceGroupName = SynapseTestRunner.TestResourceGroupName;
            string testWorkspaceName = SynapseTestRunner.TestWorkspaceName;
            string testSparkPoolName = SynapseTestRunner.TestSparkPoolName;
            if (string.IsNullOrEmpty(resourceGroupName) || string.IsNullOrEmpty(testWorkspaceName) || string.IsNullOrEmpty(testSparkPoolName))
            {
                resourceGroupName = nameof(TestResourceGroupName);
                testWorkspaceName = nameof(TestWorkspaceName);
                testSparkPoolName = nameof(TestSparkPoolName);
            }

            TestRunner.RunTestScript(
                string.Format(
                "Test-SynapseSparkJob -resourceGroupname '{0}' -workspaceName '{1}' -sparkPoolName {2}",
                resourceGroupName,
                testWorkspaceName,
                testSparkPoolName));
        }
    }
}
