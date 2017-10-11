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

using Microsoft.Azure.Commands.ApplicationInsights.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ApplicationInsights
{
    [Cmdlet(VerbsCommon.Get, ApplicationInsightsDailyCapNounStr), OutputType(typeof(PSPricingTier))]
    public class GetApplicationInsightsDailyCapCommand : ApplicationInsightsBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Insights Component Name.")]
        [Alias(ApplicationInsightsComponentNameAlias, ComponentNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var pricingPlanResponse = this.AppInsightsManagementClient
                                            .ComponentCurrentBillingFeatures
                                            .GetWithHttpMessagesAsync(
                                                this.ResourceGroupName,
                                                this.Name)
                                            .GetAwaiter()
                                            .GetResult();

            WriteDailyCap(pricingPlanResponse.Body);
        }
    }
}
