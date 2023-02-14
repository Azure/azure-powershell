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
    public class PolicyStateTests : PolicyInsightsTestRunner
    {
        public PolicyStateTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        #region Policy States Latest - Scopes

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LatestManagementGroupScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-LatestManagementGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LatestSubscriptionScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-LatestSubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LatestResourceGroupScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-LatestResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LatestResourceScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-LatestResourceScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LatestPolicySetDefinitionScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-LatestPolicySetDefinitionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LatestPolicyDefinitionScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-LatestPolicyDefinitionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LatestSubscriptionLevelPolicyAssignmentScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-LatestSubscriptionLevelPolicyAssignmentScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LatestResourceGroupLevelPolicyAssignmentScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-LatestResourceGroupLevelPolicyAssignmentScope");
        }

        #endregion

        #region Policy States Default - Scopes

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllManagementGroupScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-AllManagementGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllSubscriptionScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-AllSubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllResourceGroupScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-AllResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllResourceScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-AllResourceScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllPolicySetDefinitionScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-AllPolicySetDefinitionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllPolicyDefinitionScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-AllPolicyDefinitionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllSubscriptionLevelPolicyAssignmentScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-AllSubscriptionLevelPolicyAssignmentScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllResourceGroupLevelPolicyAssignmentScope()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-AllResourceGroupLevelPolicyAssignmentScope");
        }

        #endregion


        #region Get multiple pages of policy states

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ManagementGroupScope_Paging()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-ManagementGroupScope-Paging");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionScope_Paging()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-SubscriptionScope-Paging");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PolicyDefinitionScope_Paging()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-PolicyDefinitionScope-Paging");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PolicySetDefinitionScope_Paging()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-PolicySetDefinitionScope-Paging");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PolicyAssignmentScope_Paging()
        {
            TestRunner.RunTestScript("Get-AzureRmPolicyState-PolicyAssignmentScope-Paging");
        }

        #endregion

        #region Trigger Evaluation

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TriggerEvaluationSubscriptionScope()
        {
            TestRunner.RunTestScript("Start-AzPolicyComplianceScan-SubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TriggerEvaluationResourceGroupScope()
        {
            TestRunner.RunTestScript("Start-AzPolicyComplianceScan-ResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TriggerEvaluationSubscriptionScope_AsJob()
        {
            TestRunner.RunTestScript("Start-AzPolicyComplianceScan-SubscriptionScope-AsJob");
        }

        #endregion
    }
}
