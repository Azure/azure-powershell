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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.Cmdlets
{
    /// <summary>
    /// Class GetServerEndpointCommand.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsCommon.Get, StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint, DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet), OutputType(typeof(PSServerEndpoint))]
    public class GetServerEndpointCommand : StorageSyncClientCmdletBase
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
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices/syncGroups", "ResourceGroupName", "StorageSyncServiceName")]
        [ValidateNotNullOrEmpty]
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
        [Alias(StorageSyncAliases.SyncGroupAlias)]
        public PSSyncGroup ParentObject { get; set; }

        /// <summary>
        /// Gets or sets the parent resource identifier.
        /// </summary>
        /// <value>The parent resource identifier.</value>
        [Parameter(
          Position = 0,
          ParameterSetName = StorageSyncParameterSets.ParentStringParameterSet,
          Mandatory = true,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = HelpMessages.StorageSyncServiceObjectParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.SyncGroupIdAlias)]
        public string ParentResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.ServerEndpointNameParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.ServerEndpointNameAlias)]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices/syncGroups/serverEndpoints", "ResourceGroupName", "StorageSyncServiceName", "SyncGroupName")]
        public string Name { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                var parentResourceIdentifier = default(ResourceIdentifier);
                if (this.IsParameterBound(c => c.ParentResourceId))
                {
                    parentResourceIdentifier = new ResourceIdentifier(ParentResourceId);
                    if (!string.Equals(StorageSyncConstants.SyncGroupType, parentResourceIdentifier.ResourceType, System.StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException(StorageSyncResources.MissingParentResourceIdErrorMessage);
                    }
                }

                string resourceGroupName = ResourceGroupName ?? ParentObject?.ResourceGroupName ?? parentResourceIdentifier.ResourceGroupName;
                string storageSyncServiceName = StorageSyncServiceName ?? ParentObject?.StorageSyncServiceName ?? parentResourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 0);
                string parentResourceName = SyncGroupName ?? ParentObject?.SyncGroupName ?? parentResourceIdentifier.ResourceName;
                 if (!this.IsParameterBound(c => c.Name))
                {
                    WriteObject(StorageSyncClientWrapper.StorageSyncManagementClient.ServerEndpoints.ListBySyncGroup(resourceGroupName, storageSyncServiceName, parentResourceName));
                }
                else
                {
                    WriteObject(StorageSyncClientWrapper.StorageSyncManagementClient.ServerEndpoints.Get(resourceGroupName, storageSyncServiceName, parentResourceName, Name));
                }
            });
        }
    }
}
