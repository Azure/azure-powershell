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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using static Microsoft.Azure.Commands.Synapse.Models.SynapseConstants;
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

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.UserAssignedIdentityInEncryption)]
        public string UserAssignedIdentityInEncryption { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.UseSystemAssignedIdentityInEncryption)]
        [ValidateNotNullOrEmpty]
        public object UseSystemAssignedIdentityInEncryption { get; set; }        

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.GitRepository)]
        [ValidateNotNull]
        public PSWorkspaceRepositoryConfiguration GitRepository { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = HelpMessages.UserAssignedIdentityAction)]
        public SynapseConstants.UserAssignedManagedIdentityActionType UserAssignedIdentityAction { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.UserAssignedIdentityId)]
        [ValidateNotNull]
        public List<string> UserAssignedIdentityId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PublicNetworkAccess)]
        [ValidateNotNull]
        public bool EnablePublicNetworkAccess { get; set; }

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
            string userAssignedIdentityInEncryption = this.IsParameterBound(c => c.UserAssignedIdentityInEncryption) ? this.UserAssignedIdentityInEncryption : this.InputObject?.Encryption?.CustomerManagedKeyDetails?.KekIdentity?.UserAssignedIdentity;
            object useSystemAssignedIdentityInEncryption = this.IsParameterBound(c => c.UseSystemAssignedIdentityInEncryption) ? this.UseSystemAssignedIdentityInEncryption : this.InputObject?.Encryption?.CustomerManagedKeyDetails?.KekIdentity?.UseSystemAssignedIdentity;
            patchInfo.Encryption = !string.IsNullOrEmpty(encrptionKeyName) || this.IsParameterBound(c => c.UseSystemAssignedIdentityInEncryption) ? new EncryptionDetails
            {
                Cmk = new CustomerManagedKeyDetails
                {
                    Key = new WorkspaceKeyDetails
                    {
                        Name = encrptionKeyName
                    },
                    KekIdentity = new KekIdentityProperties
                    {
                        UserAssignedIdentity = userAssignedIdentityInEncryption,
                        UseSystemAssignedIdentity = useSystemAssignedIdentityInEncryption
                    }
                }
            } : null;
            patchInfo.WorkspaceRepositoryConfiguration = this.IsParameterBound(c => c.GitRepository) ? this.GitRepository.ToSdkObject() : null;
            patchInfo.PublicNetworkAccess = this.IsParameterBound(c => c.EnablePublicNetworkAccess) ? (this.EnablePublicNetworkAccess ? PublicNetworkAccess.Enabled : PublicNetworkAccess.Disabled): existingWorkspace.PublicNetworkAccess;

            if ((!this.IsParameterBound(c => c.UserAssignedIdentityAction) && this.IsParameterBound(c => c.UserAssignedIdentityId))
               || ((this.IsParameterBound(c => c.UserAssignedIdentityAction) && !this.IsParameterBound(c => c.UserAssignedIdentityId))))
            {
                throw new AzPSInvalidOperationException(Resources.FailedToValidateUserAssignedIdentityParameter);
            }

            if (this.IsParameterBound(c => c.UserAssignedIdentityAction) && this.IsParameterBound(c => c.UserAssignedIdentityId))
            {
                patchInfo.Identity = existingWorkspace.Identity;
                patchInfo.Identity.Type = ResourceIdentityType.SystemAssignedUserAssigned;
                if (patchInfo.Identity.UserAssignedIdentities == null)
                {
                    patchInfo.Identity.UserAssignedIdentities = new Dictionary<string, UserAssignedManagedIdentity>();
                }

                if (this.UserAssignedIdentityAction == SynapseConstants.UserAssignedManagedIdentityActionType.Add)
                {
                    UserAssignedIdentityId.Where(identity => !patchInfo.Identity.UserAssignedIdentities.ContainsKey(identity))?.ForEach(
                        item => patchInfo.Identity.UserAssignedIdentities.Add(item, new UserAssignedManagedIdentity()));
                }
                else if (this.UserAssignedIdentityAction == SynapseConstants.UserAssignedManagedIdentityActionType.Remove)
                {
                    UserAssignedIdentityId.Where(identity => patchInfo.Identity.UserAssignedIdentities.ContainsKey(identity))?.ForEach(
                        item => patchInfo.Identity.UserAssignedIdentities[item] = null);
                }
                else if (this.UserAssignedIdentityAction == SynapseConstants.UserAssignedManagedIdentityActionType.Set)
                {
                    patchInfo.Identity.UserAssignedIdentities.Where(identity => !UserAssignedIdentityId.Contains(identity.Key))?.ForEach(
                        item => patchInfo.Identity.UserAssignedIdentities[item.Key] = null);

                    UserAssignedIdentityId.Where(identity => !patchInfo.Identity.UserAssignedIdentities.ContainsKey(identity))?.ForEach(
                        item => patchInfo.Identity.UserAssignedIdentities.Add(item, new UserAssignedManagedIdentity()));
                }

                if (patchInfo.Identity.UserAssignedIdentities.All(identity => identity.Value == null))
                {
                    patchInfo.Identity.Type = ResourceIdentityType.SystemAssigned;
                    patchInfo.Identity.UserAssignedIdentities = null;
                }
            }

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
