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
    public class PolicyStateTests
    {
        private readonly XunitTracingInterceptor _logger;

        public PolicyStateTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        #region Policy States Latest - Scopes

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LatestManagementGroupScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-LatestManagementGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LatestSubscriptionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-LatestSubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LatestResourceGroupScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-LatestResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LatestResourceScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-LatestResourceScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LatestPolicySetDefinitionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-LatestPolicySetDefinitionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LatestPolicyDefinitionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-LatestPolicyDefinitionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LatestSubscriptionLevelPolicyAssignmentScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-LatestSubscriptionLevelPolicyAssignmentScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LatestResourceGroupLevelPolicyAssignmentScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-LatestResourceGroupLevelPolicyAssignmentScope");
        }

        #endregion

        #region Policy States Default - Scopes

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllManagementGroupScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-AllManagementGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllSubscriptionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-AllSubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllResourceGroupScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-AllResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllResourceScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-AllResourceScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllPolicySetDefinitionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-AllPolicySetDefinitionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllPolicyDefinitionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-AllPolicyDefinitionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllSubscriptionLevelPolicyAssignmentScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-AllSubscriptionLevelPolicyAssignmentScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllResourceGroupLevelPolicyAssignmentScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-AllResourceGroupLevelPolicyAssignmentScope");
        }

        #endregion
    }
}
