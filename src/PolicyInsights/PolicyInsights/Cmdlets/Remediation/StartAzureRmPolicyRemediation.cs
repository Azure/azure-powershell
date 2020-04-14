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

namespace Microsoft.Azure.Commands.PolicyInsights.Cmdlets.Remediation
{
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.PolicyInsights.Common;
    using Microsoft.Azure.Commands.PolicyInsights.Models.Remediation;
    using Microsoft.Azure.Commands.PolicyInsights.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.PolicyInsights;
    using Microsoft.Azure.Management.PolicyInsights.Models;

    /// <summary>
    /// Creates and starts a policy remediation.
    /// </summary>
    [Cmdlet("Start", AzureRMConstants.AzureRMPrefix + "PolicyRemediation", DefaultParameterSetName = ParameterSetNames.ByName, SupportsShouldProcess = true), OutputType(typeof(PSRemediation))]
    public class StartAzureRmPolicyRemediation : RemediationCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Name)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Scope)]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ManagementGroupName)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("Id")]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.PolicyAssignmentId)]
        [ValidateNotNullOrEmpty]
        public string PolicyAssignmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.PolicyDefinitionReferenceId)]
        [ValidateNotNullOrEmpty]
        public string PolicyDefinitionReferenceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.LocationFilter)]
        [ValidateNotNullOrEmpty]
        public string[] LocationFilter { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceDiscoveryMode)]
        [ValidateSet("ExistingNonCompliant", "ReEvaluateCompliance")]
        public string ResourceDiscoveryMode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Executes the cmdlet to create a remediation resource
        /// </summary>
        public override void Execute()
        {
            if (!string.IsNullOrEmpty(this.Name) && new[] { this.Scope, this.ManagementGroupName, this.ResourceGroupName }.Count(s => s != null) > 1)
            {
                throw new PSArgumentException(Resources.Error_TooManyScopes);
            }
            
            var rootScope = this.GetRootScope(scope: this.Scope, resourceId: this.ResourceId, managementGroupId: this.ManagementGroupName, resourceGroupName: this.ResourceGroupName);
            var remediationName = this.GetRemediationName(name: this.Name, resourceId: this.ResourceId);

            var remediation = new Remediation(policyAssignmentId: this.PolicyAssignmentId, policyDefinitionReferenceId: this.PolicyDefinitionReferenceId, resourceDiscoveryMode: this.ResourceDiscoveryMode);
            if (this.LocationFilter != null)
            {
                remediation.Filters = new RemediationFilters(this.LocationFilter);
            }

            if (this.ShouldProcess(target: remediationName, action: string.Format(CultureInfo.InvariantCulture, Resources.CreatingRemediation, rootScope, remediationName)))
            {
                var result = this.PolicyInsightsClient.Remediations.CreateOrUpdateAtResource(resourceId: rootScope, remediationName: remediationName, parameters: remediation);

                if (this.AsJob.IsPresent)
                {
                    result = this.WaitForTerminalState(result);
                }

                WriteObject(new PSRemediation(result));
            }
        }
    }
}
