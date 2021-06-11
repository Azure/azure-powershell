using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.WorkspaceKey;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.WorkspaceKey,
        DefaultParameterSetName = UpdateByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSWorkspaceKey))]
    public class UpdateAzureSynapseWorkspaceKey : SynapseManagementCmdletBase
    {
        private const string UpdateByNameParameterSet = "UpdateByNameParameterSet";
        private const string UpdateByParentObjectParameterSet = "UpdateByParentObjectParameterSet";
        private const string UpdateByInputObjectParameterSet = "UpdateByInputObjectParameterSet";
        private const string UpdateByResourceIdParameterSet = "UpdateByResourceIdParameterSet";

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, HelpMessage = HelpMessages.EncryptionKeyName)]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByParentObjectParameterSet, HelpMessage = HelpMessages.EncryptionKeyName)]
        [Alias(nameof(SynapseConstants.KeyName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = SynapseConstants.DefaultName;

        [Parameter(ValueFromPipeline = true, ParameterSetName = UpdateByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = UpdateByInputObjectParameterSet, Mandatory = true,
            HelpMessage = HelpMessages.KeyObject)]
        [ValidateNotNull]
        public PSWorkspaceKey InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.KeyResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.EncryptionKeyIdentifier)]
        public string EncryptionKeyIdentifier { get;  set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.IsActiveCustomerManagedKey)]
        public SwitchParameter Activate { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.Name = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.Name = resourceIdentifier.ResourceName;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            Key existingKey = null;
            try
            {
                existingKey = this.SynapseAnalyticsClient.GetKey(this.ResourceGroupName, this.WorkspaceName, this.Name);
            }
            catch
            {
                existingKey = null;
            }

            if (existingKey == null)
            {
                throw new AzPSInvalidOperationException(string.Format(Resources.FailedToDiscoverKey, this.Name, this.ResourceGroupName, this.WorkspaceName));
            }

            var updateParams = new Key
            {
                IsActiveCMK = this.IsParameterBound(c => c.Activate) ? this.Activate.IsPresent : existingKey.IsActiveCMK,
                KeyVaultUrl = this.IsParameterBound(c => c.EncryptionKeyIdentifier) ? this.EncryptionKeyIdentifier : existingKey.KeyVaultUrl
            };

            if (this.ShouldProcess(this.Name, string.Format(Resources.UpdatingWorkspaceKey, this.Name, this.ResourceGroupName, this.WorkspaceName)))
            {
                WriteObject(new PSWorkspaceKey(this.SynapseAnalyticsClient.CreateOrUpdateKey(this.ResourceGroupName, this.WorkspaceName, this.Name, updateParams)));
            }
        }
    }
}
