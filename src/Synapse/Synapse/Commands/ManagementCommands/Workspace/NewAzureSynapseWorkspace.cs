using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Models;
using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Workspace, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseWorkspace))]
    public class NewAzureSynapseWorkspace : SynapseManagementCmdletBase
    {
        private const string SetGitConfigParameterSet = "SetGitConfigParameterSet";

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
        [ValidateNotNull]
        public PSManagedVirtualNetworkSettings ManagedVirtualNetwork { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.EncryptionKeyName)]
        [ValidateNotNullOrEmpty]
        public string EncryptionKeyName { get; set; } = SynapseConstants.DefaultName;

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.EncryptionKeyIdentifier)]
        [ValidateNotNullOrEmpty]
        public string EncryptionKeyIdentifier { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = HelpMessages.ManagedResourceGroupName)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ManagedResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetGitConfigParameterSet,
            HelpMessage = HelpMessages.RepositoryType)]
        [ValidateSet(SynapseConstants.RepositoryType.GitHub, SynapseConstants.RepositoryType.DevOps, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string RepositoryType { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetGitConfigParameterSet,
            HelpMessage = HelpMessages.AccountName)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SetGitConfigParameterSet,
            HelpMessage = HelpMessages.ProjectName)]
        [ValidateNotNullOrEmpty]
        public string ProjectName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetGitConfigParameterSet,
            HelpMessage = HelpMessages.RepositoryName)]
        [ValidateNotNullOrEmpty]
        public string RepositoryName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetGitConfigParameterSet,
            HelpMessage = HelpMessages.CollaborationBranch)]
        [ValidateNotNullOrEmpty]
        public string CollaborationBranch { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SetGitConfigParameterSet,
            HelpMessage = HelpMessages.PublishBranch)]
        [ValidateNotNullOrEmpty]
        public string PublishBranch { get; set; } = "workspace_publish";

        [Parameter(Mandatory = false, ParameterSetName = SetGitConfigParameterSet,
            HelpMessage = HelpMessages.RootFolder)]
        [ValidateNotNullOrEmpty]
        public string RootFolder { get; set; } = "/";

        public override void ExecuteCmdlet()
        {
            try
            {
                if (SynapseAnalyticsClient.GetWorkspace(ResourceGroupName, Name) != null)
                {
                    throw new AzPSInvalidOperationException(string.Format(Resources.SynapseWorkspaceExists, this.Name, this.ResourceGroupName));
                }
            }
            catch (AzPSResourceNotFoundCloudException ex)
            {
                var innerException = ex.InnerException as ErrorResponseException;
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

            if(this.RepositoryType == SynapseConstants.RepositoryType.DevOps && this.ProjectName == null)
            {
                throw new PSArgumentException("Project name is not provided", "ProjectName");
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
                ManagedVirtualNetwork = this.IsParameterBound(c => c.ManagedVirtualNetwork) ? SynapseConstants.DefaultName : null,
                Location = this.Location,
                ManagedVirtualNetworkSettings = this.IsParameterBound(c => c.ManagedVirtualNetwork) ? this.ManagedVirtualNetwork?.ToSdkObject() : null,
                ManagedResourceGroupName = this.ManagedResourceGroupName,
                Encryption = this.IsParameterBound(c => c.EncryptionKeyIdentifier) ? new EncryptionDetails
                {
                    Cmk = new CustomerManagedKeyDetails
                    {
                        Key = new WorkspaceKeyDetails
                        {
                            Name = this.EncryptionKeyName,
                            KeyVaultUrl = this.EncryptionKeyIdentifier
                        }
                    }
                } : null,
                WorkspaceRepositoryConfiguration = this.IsParameterBound(c => c.RepositoryType) ? new WorkspaceRepositoryConfiguration
                {
                    Type = this.RepositoryType == SynapseConstants.RepositoryType.DevOps ? SynapseConstants.RepositoryType.WorkspaceVSTSConfiguration : SynapseConstants.RepositoryType.WorkspaceGitHubConfiguration,
                    AccountName = this.AccountName,
                    ProjectName = this.RepositoryType == SynapseConstants.RepositoryType.DevOps ? this.ProjectName : null,
                    RepositoryName = this.RepositoryName,
                    CollaborationBranch = this.CollaborationBranch,
                    RootFolder = this.RootFolder
                } : null
            };

            if (ShouldProcess(Name, string.Format(Resources.CreatingSynapseWorkspace, this.ResourceGroupName, this.Name)))
            {
                var workspace = new PSSynapseWorkspace(SynapseAnalyticsClient.CreateWorkspace(
                    this.ResourceGroupName,
                    this.Name,
                    createParams));

                this.WriteObject(workspace);
            } 
        }
    }
}