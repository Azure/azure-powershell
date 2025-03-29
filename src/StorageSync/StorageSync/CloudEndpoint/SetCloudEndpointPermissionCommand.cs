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
using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Commands.StorageSync.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.CloudEndpoint
{
    /// <summary>
    /// Class SetCloudEndpointPermissionCommand.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsCommon.Set, StorageSyncNouns.NounAzureRmStorageSyncCloudEndpointPermission,
        DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSCloudEndpoint))]
    public class SetCloudEndpointPermissionCommand : StorageSyncClientCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the resource group.
        /// </summary>
        /// <value>The name of the resource group.</value>
        [Parameter(
           Position = 0,
            ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.ResourceGroupNameParameter)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the storage sync service.
        /// </summary>
        /// <value>The name of the storage sync service.</value>
        [Parameter(
             Position = 1,
             ParameterSetName = StorageSyncParameterSets.StringParameterSet,
             Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = HelpMessages.StorageSyncServiceNameParameter)]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.ParentNameAlias)]
        public string StorageSyncServiceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the sync group.
        /// </summary>
        /// <value>The name of the sync group.</value>
        [Parameter(
            Position = 2,
            ParameterSetName = StorageSyncParameterSets.StringParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.SyncGroupNameParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices/syncGroups", "ResourceGroupName", "StorageSyncServiceName")]
        public string SyncGroupName { get; set; }

        /// <summary>
        /// Gets or sets the parent object.
        /// </summary>
        /// <value>The parent object.</value>
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ObjectParameterSet,
           Mandatory = true,
           ValueFromPipeline = true,
           HelpMessage = HelpMessages.StorageSyncServiceObjectParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices/syncGroups/cloudEndpoints", "ResourceGroupName", "StorageSyncServiceName","SyncGroupName")]
        [Alias(StorageSyncAliases.CloudEndpointAlias)]
        public PSCloudEndpoint InputObject { get; set; }

        /// <summary>
        /// Gets or sets the parent resource identifier.
        /// </summary>
        /// <value>The parent resource identifier.</value>
        [Parameter(
          Position = 0,
          ParameterSetName = StorageSyncParameterSets.ResourceIdParameterSet,
          Mandatory = true,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = HelpMessages.StorageSyncServiceObjectParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.CloudEndpointIdAlias)]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.CloudEndpointNameParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices/syncGroups/cloudEndpoints", "ResourceGroupName", "StorageSyncServiceName", "SyncGroupName")]
        [Alias(StorageSyncAliases.CloudEndpointNameAlias)]
        public string Name { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                var cloudEndointResourceIdentifier = default(ResourceIdentifier);
                if (this.IsParameterBound(c => c.ResourceId))
                {
                    cloudEndointResourceIdentifier = new ResourceIdentifier(ResourceId);
                    if (!string.Equals(StorageSyncConstants.CloudEndpointType, cloudEndointResourceIdentifier.ResourceType, System.StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException(StorageSyncResources.MissingResourceIdErrorMessage);
                    }
                }

                string resourceGroupName = ResourceGroupName ?? InputObject?.ResourceGroupName ?? cloudEndointResourceIdentifier.ResourceGroupName;
                string storageSyncServiceName = StorageSyncServiceName ?? InputObject?.StorageSyncServiceName ?? cloudEndointResourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 1);
                string syncGroupResourceName = SyncGroupName ?? InputObject?.SyncGroupName ?? cloudEndointResourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 0);
                string cloudEndpointResourceName = Name ?? InputObject?.CloudEndpointName ?? cloudEndointResourceIdentifier.ResourceName;

                StorageSyncModels.CloudEndpoint cloudEndpoint = StorageSyncClientWrapper.StorageSyncManagementClient.CloudEndpoints.Get(resourceGroupName, storageSyncServiceName, syncGroupResourceName, cloudEndpointResourceName);

                if (cloudEndpoint != null)
                {
                    // Get Storage sync service
                    StorageSyncModels.StorageSyncService storageSyncService = StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.Get(resourceGroupName, storageSyncServiceName);

                    if (storageSyncService == null)
                    {
                        throw new PSArgumentException(StorageSyncResources.MissingParentResourceIdErrorMessage);
                    }

                    if (storageSyncService.Identity != null && storageSyncService.Identity.PrincipalId.GetValueOrDefault(Guid.Empty) != Guid.Empty
                        && storageSyncService.UseIdentity.GetValueOrDefault(false))
                    {
                        var storageAccountResourceIdentifier = new ResourceIdentifier(cloudEndpoint.StorageAccountResourceId);
                        // Identity , RoleDef, Scope
                        var scope = cloudEndpoint.StorageAccountResourceId;
                        var identityRoleAssignmentForSAScope = StorageSyncClientWrapper.EnsureRoleAssignmentWithIdentity(storageAccountResourceIdentifier.Subscription,
                            storageSyncService.Identity.PrincipalId.Value,
                            Common.StorageSyncClientWrapper.StorageAccountContributorRoleDefinitionId,
                            scope);

                        scope = $"{cloudEndpoint.StorageAccountResourceId}/fileServices/default/fileshares/{cloudEndpoint.AzureFileShareName}";
                        var identityRoleAssignmentForFilsShareScope = StorageSyncClientWrapper.EnsureRoleAssignmentWithIdentity(storageAccountResourceIdentifier.Subscription,
                           storageSyncService.Identity.PrincipalId.Value,
                           Common.StorageSyncClientWrapper.StorageFileDataPrivilegedContributorRoleDefinitionId,
                           scope);
                    }
                }
            });
        }
    }
}