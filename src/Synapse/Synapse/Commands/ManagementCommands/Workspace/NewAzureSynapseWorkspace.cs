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
using static Microsoft.Azure.Commands.Synapse.Models.SynapseConstants;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse
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
        [ValidateNotNull]
        public PSManagedVirtualNetworkSettings ManagedVirtualNetwork { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.EncryptionKeyName)]
        [ValidateNotNullOrEmpty]
        public string EncryptionKeyName { get; set; } = SynapseConstants.DefaultName;

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.EncryptionKeyIdentifier)]
        [ValidateNotNullOrEmpty]
        public string EncryptionKeyIdentifier { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.UserAssignedIdentityInEncryption)]
        public string UserAssignedIdentityInEncryption { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.UseSystemAssignedIdentityInEncryption)]
        [ValidateNotNullOrEmpty]
        public object UseSystemAssignedIdentityInEncryption { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = HelpMessages.ManagedResourceGroupName)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ManagedResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.GitRepository)]
        [ValidateNotNull]
        public PSWorkspaceRepositoryConfiguration GitRepository { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PublicNetworkAccess)]
        [ValidateNotNull]
        public bool EnablePublicNetworkAccess { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.UserAssignedIdentityId)]
        [ValidateNotNull]
        public List<string> UserAssignedIdentityId { get; set; }

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

            var defaultDataLakeStorageAccountUrl = string.Format(
                "https://{0}.dfs.{1}",
                this.DefaultDataLakeStorageAccountName,
                this.DefaultContext.Environment.StorageEndpointSuffix);
            var createParams = new Workspace
            {
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true),
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
                        },
                        KekIdentity = new KekIdentityProperties
                        {
                            UserAssignedIdentity = this.UserAssignedIdentityInEncryption,
                            UseSystemAssignedIdentity = this.UseSystemAssignedIdentityInEncryption
                        }
                    }
                } : null,
                WorkspaceRepositoryConfiguration = this.IsParameterBound(c => c.GitRepository) ? this.GitRepository.ToSdkObject() : null,
                PublicNetworkAccess = this.IsParameterBound(c => c.EnablePublicNetworkAccess) ? (this.EnablePublicNetworkAccess? PublicNetworkAccess.Enabled : PublicNetworkAccess.Disabled): null,
                Identity = this.IsParameterBound(c => c.UserAssignedIdentityId) ? new ManagedIdentity
                {
                    Type = ResourceIdentityType.SystemAssignedUserAssigned,
                    UserAssignedIdentities = new Dictionary<string, UserAssignedManagedIdentity>()
                } :
                new ManagedIdentity
                {
                    Type = ResourceIdentityType.SystemAssigned
                }
            };
            if (this.IsParameterBound(c => c.UserAssignedIdentityId))
            {
                UserAssignedIdentityId?.ForEach(identityId => createParams.Identity.UserAssignedIdentities.Add(identityId, new UserAssignedManagedIdentity()));
            }

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