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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.PolicyInsights.Test.ScenarioTests
{
    public class PolicyStateSummaryTests : PolicyInsightsTestRunner
    {
        public PolicyStateSummaryTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ManagementGroupScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyStateSummary-ManagementGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyStateSummary-SubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceGroupScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyStateSummary-ResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyStateSummary-ResourceScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PolicySetDefinitionScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyStateSummary-PolicySetDefinitionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PolicyDefinitionScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyStateSummary-PolicyDefinitionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionLevelPolicyAssignmentScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyStateSummary-SubscriptionLevelPolicyAssignmentScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceGroupLevelPolicyAssignmentScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyStateSummary-ResourceGroupLevelPolicyAssignmentScope");
        }
    }
}
