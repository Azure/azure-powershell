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

using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.PolicyInsights.Test.ScenarioTests
{
    public class PolicyStateSummaryTests
    {
        private readonly XunitTracingInterceptor _logger;

        public PolicyStateSummaryTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Get_AzureRmPolicyStateSummary_ManagementGroupScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyStateSummary-ManagementGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Get_AzureRmPolicyStateSummary_SubscriptionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyStateSummary-SubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Get_AzureRmPolicyStateSummary_ResourceGroupScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyStateSummary-ResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Get_AzureRmPolicyStateSummary_ResourceScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyStateSummary-ResourceScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Get_AzureRmPolicyStateSummary_PolicySetDefinitionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyStateSummary-PolicySetDefinitionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Get_AzureRmPolicyStateSummary_PolicyDefinitionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyStateSummary-PolicyDefinitionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Get_AzureRmPolicyStateSummary_SubscriptionLevelPolicyAssignmentScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyStateSummary-SubscriptionLevelPolicyAssignmentScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Get_AzureRmPolicyStateSummary_ResourceGroupLevelPolicyAssignmentScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyStateSummary-ResourceGroupLevelPolicyAssignmentScope");
        }
    }
}
