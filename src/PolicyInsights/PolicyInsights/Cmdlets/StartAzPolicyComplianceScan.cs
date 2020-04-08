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

namespace Microsoft.Azure.Commands.PolicyInsights.Cmdlets
{
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.PolicyInsights.Common;
    using Microsoft.Azure.Commands.PolicyInsights.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.PolicyInsights;

    /// <summary>
    /// Creates and starts a policy remediation.
    /// </summary>
    [Cmdlet("Start", AzureRMConstants.AzureRMPrefix + "PolicyComplianceScan", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class StartAzPolicyComplianceScan : PolicyInsightsCmdletBase
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Executes the cmdlet to trigger a compliance scan
        /// </summary>
        public override void Execute()
        {
            var scanScope = string.IsNullOrEmpty(this.ResourceGroupName) ?
                ResourceIdHelper.GetSubscriptionScope(subscriptionId: this.DefaultContext.Subscription.Id) :
                ResourceIdHelper.GetResourceGroupScope(subscriptionId: this.DefaultContext.Subscription.Id, resourceGroupName: this.ResourceGroupName);

            if (this.ShouldProcess(target: scanScope, action: string.Format(CultureInfo.InvariantCulture, Resources.StartComplianceScan, scanScope)))
            {
                if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    this.PolicyInsightsClient.PolicyStates.TriggerResourceGroupEvaluation(subscriptionId: this.DefaultContext.Subscription.Id, resourceGroupName: this.ResourceGroupName);
                }
                else
                {
                    this.PolicyInsightsClient.PolicyStates.TriggerSubscriptionEvaluation(subscriptionId: this.DefaultContext.Subscription.Id);
                }

                if (this.PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
