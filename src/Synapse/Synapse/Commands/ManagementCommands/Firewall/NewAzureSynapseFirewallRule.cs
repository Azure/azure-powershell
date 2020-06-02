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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.FirewallRule,
        DefaultParameterSetName = CreateByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseIpFirewallRule))]
    public class NewAzureSynapseFirewallRule : SynapseCmdletBase
    {
        private const string CreateByNameParameterSet = "CreateByNameParameterSet";
        private const string CreateByParentObjectParameterSet = "CreateByParentObjectParameterSet";
        private const string CreateByNameAllowAllIpParameterSet = "CreateByNameAllowAllIpParameterSet";
        private const string CreateByParentObjectAllowAllIpParameterSet = "CreateByParentObjectAllowAllIpParameterSet";
        private const string AzureRuleStartIp = "0.0.0.0";
        private const string AzureRuleEndIp = "255.255.255.255";
        private const string AzureRuleName = "AllowAllAzureIPs";

        [Parameter(ParameterSetName = CreateByNameParameterSet,Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = CreateByNameAllowAllIpParameterSet, Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = CreateByNameParameterSet,Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = CreateByNameAllowAllIpParameterSet, Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateByParentObjectParameterSet, Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
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

        [Parameter(ParameterSetName = CreateByNameAllowAllIpParameterSet, Mandatory = true, HelpMessage = HelpMessages.AzureIpRule)]
        [Parameter(ParameterSetName = CreateByParentObjectAllowAllIpParameterSet, Mandatory = true, HelpMessage = HelpMessages.AzureIpRule)]
        public SwitchParameter AllowAllAzureIP { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (ParameterSetName == CreateByNameAllowAllIpParameterSet || ParameterSetName == CreateByParentObjectAllowAllIpParameterSet)
            {
                this.Name = AzureRuleName;
                this.StartIpAddress = AzureRuleStartIp;
                this.EndIpAddress = AzureRuleEndIp;
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
