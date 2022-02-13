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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.FirewallRule,
        DefaultParameterSetName = UpdateByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseIpFirewallRule))]
    public class UpdateAzureSynapseFirewallRules : SynapseManagementCmdletBase
    {
        private const string UpdateByNameParameterSet = "UpdateByNameParameterSet";
        private const string UpdateByParentObjectParameterSet = "UpdateByParentObjectParameterSet";

        [Parameter(ParameterSetName = UpdateByNameParameterSet, Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = UpdateByNameParameterSet, Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = UpdateByParentObjectParameterSet, Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ParameterSetName = UpdateByNameParameterSet, Mandatory = true, HelpMessage = HelpMessages.FirewallRuleName)]
        [Parameter(ParameterSetName = UpdateByParentObjectParameterSet, Mandatory = true, HelpMessage = HelpMessages.FirewallRuleName)]
        [Alias(SynapseConstants.FirewallRuleName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = UpdateByNameParameterSet, Mandatory = false, HelpMessage = HelpMessages.StartIpAddress)]
        [Parameter(ParameterSetName = UpdateByParentObjectParameterSet, Mandatory = false, HelpMessage = HelpMessages.StartIpAddress)]
        [ValidateNotNullOrEmpty]
        public string StartIpAddress { get; set; }

        [Parameter(ParameterSetName = UpdateByNameParameterSet, Mandatory = false, HelpMessage = HelpMessages.EndIpAddress)]
        [Parameter(ParameterSetName = UpdateByParentObjectParameterSet, Mandatory = false, HelpMessage = HelpMessages.EndIpAddress)]
        [ValidateNotNullOrEmpty]
        public string EndIpAddress { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            if (!SynapseAnalyticsClient.TestFirewallRule(ResourceGroupName, WorkspaceName, Name))
            {
                throw new PSInvalidOperationException(string.Format(Resources.FirewallRuleDoesNotExist, Name));
            }

            var originIpFirewallRull = SynapseAnalyticsClient.GetFirewallRule(ResourceGroupName, WorkspaceName, Name);

            IpFirewallRuleInfo ipFirewallRuleInfo = new IpFirewallRuleInfo
            {
                StartIpAddress = StartIpAddress??originIpFirewallRull.StartIpAddress,
                EndIpAddress = EndIpAddress??originIpFirewallRull.EndIpAddress,
            };

            if (this.ShouldProcess(this.Name, string.Format(Resources.CreatingFirewallRule, this.WorkspaceName, this.Name)))
            {
                var result = new PSSynapseIpFirewallRule(this.SynapseAnalyticsClient.CreateOrUpdateWorkspaceFirewallRule(this.ResourceGroupName, this.WorkspaceName, this.Name, ipFirewallRuleInfo));
                WriteObject(result);
            }
        }
    }
}
