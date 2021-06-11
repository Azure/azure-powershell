using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;
using System.Management.Automation;
using SecureString = System.Security.SecureString;

namespace Microsoft.Azure.Commands.Synapse
{

    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Workspace, SupportsShouldProcess = true, DefaultParameterSetName = SetByNameParameterSet)]
    [OutputType(typeof(PSSynapseWorkspace))]
    public class UpdateAzureSynapseWorkspace : SynapseManagementCmdletBase
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";

        [Parameter(ParameterSetName = SetByNameParameterSet, Mandatory = false,
            HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = SetByNameParameterSet, Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Alias(SynapseConstants.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.Tag)]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = HelpMessages.SqlAdministratorLoginPassword)]
        [ValidateNotNull]
        public SecureString SqlAdministratorLoginPassword { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.ManagedVirtualNetwork)]
        [ValidateNotNull]
        public PSManagedVirtualNetworkSettings ManagedVirtualNetwork { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.EncryptionKeyName)]
        [ValidateNotNullOrEmpty]
        public string EncryptionKeyName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.InputObject.Id).ResourceGroupName;
                this.Name = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (string.IsNullOrEmpty(ResourceGroupName))
            {
                ResourceGroupName = SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(Name);
            }

            Workspace existingWorkspace = null;

            try
            {
                existingWorkspace = SynapseAnalyticsClient.GetWorkspace(this.ResourceGroupName, this.Name);
            }
            catch
            {
                existingWorkspace = null;
            }

            if (existingWorkspace == null)
            {
                throw new AzPSInvalidOperationException(string.Format(Resources.FailedToDiscoverWorkspace, this.Name, this.ResourceGroupName));
            }

            WorkspacePatchInfo patchInfo = new WorkspacePatchInfo();
            patchInfo.Tags = this.IsParameterBound(c => c.Tag) ? TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true) : TagsConversionHelper.CreateTagDictionary(this.InputObject?.Tags, validate:true);
            patchInfo.SqlAdministratorLoginPassword = this.IsParameterBound(c => c.SqlAdministratorLoginPassword) ? this.SqlAdministratorLoginPassword.ConvertToString() : null;
            patchInfo.ManagedVirtualNetworkSettings = this.IsParameterBound(c => c.ManagedVirtualNetwork) ? this.ManagedVirtualNetwork?.ToSdkObject() : this.InputObject?.ManagedVirtualNetworkSettings?.ToSdkObject();
            string encrptionKeyName = this.IsParameterBound(c => c.EncryptionKeyName) ? this.EncryptionKeyName : this.InputObject?.Encryption?.CustomerManagedKeyDetails?.Key?.Name;
            patchInfo.Encryption = !string.IsNullOrEmpty(encrptionKeyName) ? new EncryptionDetails
            {
                Cmk = new CustomerManagedKeyDetails
                {
                    Key = new WorkspaceKeyDetails
                    {
                        Name = encrptionKeyName
                    }
                }
            } : null;

            if (ShouldProcess(this.Name, string.Format(Resources.UpdatingSynapseWorkspace, this.Name, this.ResourceGroupName)))
            {
                var workspace = new PSSynapseWorkspace(SynapseAnalyticsClient.UpdateWorkspace(
                    this.ResourceGroupName,
                    this.Name,
                    patchInfo));
                this.WriteObject(workspace);
            }
        }
    }
}
