using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.WorkspaceKey;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse.Commands.ManagementCommands
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.WorkspaceKey, SupportsShouldProcess = true, DefaultParameterSetName = CreateByNameParameterSet)]
    [OutputType(typeof(PSWorkspaceKey))]
    public class NewAzureSynapseWorkspaceKey : SynapseManagementCmdletBase
    {
        private const string CreateByNameParameterSet = "CreateByNameParameterSet";
        private const string CreateByParentObjectParameterSet = "CreateByParentObjectParameterSet";

        [Parameter(ParameterSetName = CreateByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = CreateByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessages.WorkspaceKeyName)]
        [Alias(nameof(SynapseConstants.KeyName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessages.EncryptionKeyIdentifier)]
        public string EncryptionKeyIdentifier { get;  set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.IsActiveCustomerManagedKey)]
        public SwitchParameter Activate { get; set; }

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

            var existingWorkspace = this.SynapseAnalyticsClient.GetWorkspaceOrDefault(this.ResourceGroupName, this.WorkspaceName);
            if (existingWorkspace == null)
            {
                throw new AzPSResourceNotFoundCloudException(string.Format(Resources.WorkspaceDoesNotExist, this.WorkspaceName));
            }

            var existingKey = this.SynapseAnalyticsClient.GetKeyOrDefault(this.ResourceGroupName, this.WorkspaceName, this.Name);
            if (existingKey != null)
            {
                throw new AzPSInvalidOperationException(string.Format(Resources.WorkspaceKeyExists, this.Name, this.ResourceGroupName, this.WorkspaceName));
            }

            var createParams = new Key
            {
                IsActiveCMK = this.Activate.IsPresent,
                KeyVaultUrl = this.EncryptionKeyIdentifier
            };

            if (!this.IsParameterBound(c => c.Name))
            {
                this.Name = SynapseConstants.DefaultName;
            }

            if (this.ShouldProcess(this.Name, string.Format(Resources.CreatingSynapseWorkspaceKey, this.ResourceGroupName, this.WorkspaceName, this.Name)))
            {
                var result = new PSWorkspaceKey(this.SynapseAnalyticsClient.CreateOrUpdateKey(this.ResourceGroupName, this.WorkspaceName, this.Name, createParams));
                WriteObject(result);
            }
        }
    }
}
