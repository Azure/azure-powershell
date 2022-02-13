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
using System.Management.Automation;
using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.FirewallRule,
        DefaultParameterSetName = CreateByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseIpFirewallRule))]
    public class NewAzureSynapseFirewallRule : SynapseManagementCmdletBase
    {
        private const string CreateByNameParameterSet = "CreateByNameParameterSet";
        private const string CreateByParentObjectParameterSet = "CreateByParentObjectParameterSet";
        private const string CreateByNameAllowAllAzureIpParameterSet = "CreateByNameAllowAllAzureIpParameterSet";
        private const string CreateByParentObjectAllowAllAzureIpParameterSet = "CreateByParentObjectAllowAllAzureIpParameterSet";
        private const string CreateByNameAllowAllIpParameterSet = "CreateByNameAllowAllIpParameterSet";
        private const string CreateByParentObjectAllowAllIpParameterSet = "CreateByParentObjectAllowAllIpParameterSet";
        private const string AllowAllAzureIpRuleStartIp = "0.0.0.0";
        private const string AllowAllAzureIpRuleEndIp = "0.0.0.0";
        private const string AllowAllAzureIpRuleName = "AllowAllWindowsAzureIps";
        private const string AllowAllIpRuleStartIp = "0.0.0.0";
        private const string AllowAllIpRuleEndIp = "255.255.255.255";
        private const string AllowAllIpRuleName = "allowAll";

        [Parameter(ParameterSetName = CreateByNameParameterSet,Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = CreateByNameAllowAllAzureIpParameterSet, Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = CreateByNameAllowAllIpParameterSet, Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = CreateByNameParameterSet,Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = CreateByNameAllowAllAzureIpParameterSet, Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = CreateByNameAllowAllIpParameterSet, Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateByParentObjectParameterSet, Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateByParentObjectAllowAllAzureIpParameterSet, Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateByParentObjectAllowAllIpParameterSet, Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ParameterSetName = CreateByNameParameterSet, Mandatory = true, HelpMessage = HelpMessages.FirewallRuleName)]
        [Parameter(ParameterSetName = CreateByParentObjectParameterSet, Mandatory = true, HelpMessage = HelpMessages.FirewallRuleName)]
        [Alias(SynapseConstants.FirewallRuleName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = CreateByNameParameterSet, Mandatory = true, HelpMessage = HelpMessages.StartIpAddress)]
        [Parameter(ParameterSetName = CreateByParentObjectParameterSet,Mandatory = true, HelpMessage = HelpMessages.StartIpAddress)]
        [ValidateNotNullOrEmpty]
        public string StartIpAddress { get; set; }

        [Parameter(ParameterSetName = CreateByNameParameterSet, Mandatory = true, HelpMessage = HelpMessages.EndIpAddress)]
        [Parameter(ParameterSetName = CreateByParentObjectParameterSet, Mandatory = true, HelpMessage = HelpMessages.EndIpAddress)]
        [ValidateNotNullOrEmpty]
        public string EndIpAddress { get; set; }

        [Parameter(ParameterSetName = CreateByNameAllowAllAzureIpParameterSet, Mandatory = true, HelpMessage = HelpMessages.AllowAllAzureIpRule)]
        [Parameter(ParameterSetName = CreateByParentObjectAllowAllAzureIpParameterSet, Mandatory = true, HelpMessage = HelpMessages.AllowAllAzureIpRule)]
        public SwitchParameter AllowAllAzureIp { get; set; }

        [Parameter(ParameterSetName = CreateByNameAllowAllIpParameterSet, Mandatory = true, HelpMessage = HelpMessages.AllowAllIpRule)]
        [Parameter(ParameterSetName = CreateByParentObjectAllowAllIpParameterSet, Mandatory = true, HelpMessage = HelpMessages.AllowAllIpRule)]
        public SwitchParameter AllowAllIp { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (ParameterSetName == CreateByNameAllowAllAzureIpParameterSet || ParameterSetName == CreateByParentObjectAllowAllAzureIpParameterSet)
            {
                this.Name = AllowAllAzureIpRuleName;
                this.StartIpAddress = AllowAllAzureIpRuleStartIp;
                this.EndIpAddress = AllowAllAzureIpRuleEndIp;
            }

            if (ParameterSetName == CreateByNameAllowAllIpParameterSet || ParameterSetName == CreateByParentObjectAllowAllIpParameterSet)
            {
                this.Name = AllowAllIpRuleName;
                this.StartIpAddress = AllowAllIpRuleStartIp;
                this.EndIpAddress = AllowAllIpRuleEndIp;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            if (SynapseAnalyticsClient.TestFirewallRule(ResourceGroupName, WorkspaceName, Name))
            {
                throw new PSInvalidOperationException(string.Format(Resources.ConflictFirewallRuleName, Name));
            }

            IpFirewallRuleInfo ipFirewallRuleInfo = new IpFirewallRuleInfo
            {
                StartIpAddress = StartIpAddress,
                EndIpAddress = EndIpAddress
            };

            if (this.ShouldProcess(this.Name, string.Format(Resources.CreatingFirewallRule, this.WorkspaceName, this.Name)))
            {
                var result = new PSSynapseIpFirewallRule(this.SynapseAnalyticsClient.CreateOrUpdateWorkspaceFirewallRule(this.ResourceGroupName, this.WorkspaceName, this.Name, ipFirewallRuleInfo));
                WriteObject(result);
            }
        }
    }
}
