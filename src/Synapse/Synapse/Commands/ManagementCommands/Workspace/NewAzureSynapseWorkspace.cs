using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Models;
using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;

namespace Microsoft.Azure.Commands.Synaspe
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Workspace, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseWorkspace))]
    public class NewAzureSynapseWorkspace : SynapseManagementCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            HelpMessage = HelpMessages.WorkspaceName)]
        [Alias(SynapseConstants.WorkspaceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            HelpMessage = HelpMessages.Location)]
        [LocationCompleter(ResourceTypes.Workspace)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = HelpMessages.Tag)]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            HelpMessage = HelpMessages.DefaultDataLakeStorageAccountName)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.StorageAccount, nameof(ResourceGroupName))]
        public string DefaultDataLakeStorageAccountName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            HelpMessage = HelpMessages.DefaultDataLakeStorageFilesystem)]
        [ValidateNotNullOrEmpty]
        public string DefaultDataLakeStorageFilesystem { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            HelpMessage = HelpMessages.SqlAdministratorLoginCredential)]
        [ValidateNotNull]
        public PSCredential SqlAdministratorLoginCredential { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.ManagedVirtualNetwork)]
        [ValidateSet("default")]
        public string ManagedVirtualNetwork { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (SynapseAnalyticsClient.GetWorkspace(ResourceGroupName, Name) != null)
                {
                    throw new SynapseException(string.Format(Resources.SynapseWorkspaceExists, this.Name, this.ResourceGroupName));
                }
            }
            catch (NotFoundException ex)
            {
                var innerException = ex.InnerException as ErrorContractException;
                if (innerException.Body?.Error?.Code == "ResourceNotFound" || innerException.Body?.Error?.Message.Contains("ResourceNotFound") == true)
                {
                    // account does not exists so go ahead and create one
                }
                else if (innerException.Body?.Error?.Code == "ResourceGroupNotFound" || innerException.Body?.Error?.Message.Contains("ResourceGroupNotFound") == true)
                {
                    // resource group not found, throw error during creation. Don't throw from here.
                }
                else
                {
                    // all other exceptions should be thrown
                    throw;
                }
            }

            var defaultDataLakeStorageAccountUrl = string.Format(
                "https://{0}.dfs.{1}",
                this.DefaultDataLakeStorageAccountName,
                this.DefaultContext.Environment.StorageEndpointSuffix);
            var createParams = new Workspace
            {
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true),
                Identity = new ManagedIdentity
                {
                    Type = ResourceIdentityType.SystemAssigned
                },
                DefaultDataLakeStorage = new DataLakeStorageAccountDetails
                {
                    AccountUrl = defaultDataLakeStorageAccountUrl,
                    Filesystem = this.DefaultDataLakeStorageFilesystem
                },
                SqlAdministratorLogin = this.SqlAdministratorLoginCredential.UserName,
                SqlAdministratorLoginPassword = this.SqlAdministratorLoginCredential.GetNetworkCredential().Password,
                ManagedVirtualNetwork = this.ManagedVirtualNetwork,
                Location = this.Location
            };

            if (ShouldProcess(Name, string.Format(Resources.CreatingSynapseWorkspace, this.ResourceGroupName, this.Name)))
            {
                var workspace = new PSSynapseWorkspace(SynapseAnalyticsClient.CreateOrUpdateWorkspace(
                    this.ResourceGroupName,
                    this.Name,
                    createParams));

                this.WriteObject(workspace);
            } 
        }
    }
}