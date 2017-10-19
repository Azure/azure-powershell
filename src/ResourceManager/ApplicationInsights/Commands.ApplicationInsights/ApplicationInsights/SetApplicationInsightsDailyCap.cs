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
using Microsoft.Azure.Management.ApplicationInsights.Management.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ApplicationInsights
{
    [Cmdlet(VerbsCommon.Set, ApplicationInsightsDailyCapNounStr), OutputType(typeof(PSPricingTier))]
    public class SetApplicationInsightsDailyCapCommand : ApplicationInsightsBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ComponentObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Application Insights Component Object.")]
        [ValidateNotNull]
        public PSApplicationInsightsComponent ApplicationInsightsComponent { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Insights Component Resource Id.")]
        [ValidateNotNull]
        public ResourceIdentifier ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Insights Component Name.")]
        [Alias(ApplicationInsightsComponentNameAlias, ComponentNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Daily Cap.")]        
        public double? DailyCapGB { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = false,
            HelpMessage = "Stop send notification when hit cap.")]
        public SwitchParameter DisableNotificationWhenHitCap { get; set; }

        [Parameter(
            Position = 4,
            Mandatory = false,
            HelpMessage = "Enable send notification when hit cap.")]
        public SwitchParameter EnableNotificationWhenHitCap { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.ApplicationInsightsComponent != null)
            {
                this.ResourceGroupName = this.ApplicationInsightsComponent.ResourceGroupName;
                this.Name = this.ApplicationInsightsComponent.Name;
            }

            if (this.ResourceId != null)
            {
                this.ResourceGroupName = this.ResourceId.ResourceGroupName;
                this.Name = this.ResourceId.ResourceName;
            }

            ApplicationInsightsComponentBillingFeatures features = 
                                                this.AppInsightsManagementClient
                                                        .ComponentCurrentBillingFeatures
                                                        .GetWithHttpMessagesAsync(
                                                            this.ResourceGroupName,
                                                            this.Name)
                                                        .GetAwaiter()
                                                        .GetResult()
                                                        .Body;

            if (this.DailyCapGB != null)
            {
                features.DataVolumeCap.Cap = this.DailyCapGB.Value;
            }

            if (this.DisableNotificationWhenHitCap.IsPresent)
            {
                features.DataVolumeCap.StopSendNotificationWhenHitCap = true;
            }

            if (this.EnableNotificationWhenHitCap.IsPresent)
            {
                features.DataVolumeCap.StopSendNotificationWhenHitCap = false;
            }

            var putResponse = this.AppInsightsManagementClient
                                    .ComponentCurrentBillingFeatures
                                    .UpdateWithHttpMessagesAsync(
                                        this.ResourceGroupName,
                                        this.Name,
                                        features)
                                    .GetAwaiter()
                                    .GetResult();

            WriteDailyCap(putResponse.Body);
        }
    }
}
