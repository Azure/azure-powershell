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
    public class PolicyInsightsTests
    {
        private readonly XunitTracingInterceptor _logger;

        public PolicyInsightsTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        #region Policy Events - Scopes

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Get_AzureRmPolicyEvent_ManagementGroupScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyEvent-ManagementGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Get_AzureRmPolicyEvent_SubscriptionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyEvent-SubscriptionScope");
        }

        #endregion

        #region Policy States Latest - Scopes

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Get_AzureRmPolicyState_LatestSubscriptionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-LatestSubscriptionScope");
        }

        #endregion

        #region Policy States Default - Scopes

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Get_AzureRmPolicyState_AllSubscriptionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyState-AllSubscriptionScope");
        }

        #endregion

        #region Policy States Latest - Summarize

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Get_AzureRmPolicyStateSummary_SubscriptionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmPolicyStateSummary-SubscriptionScope");
        }

        #endregion

        #region Query options

        #endregion
    }
}
