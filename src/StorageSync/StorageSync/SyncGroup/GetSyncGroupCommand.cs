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

using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Commands.StorageSync.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.SyncGroup
{

    /// <summary>
    /// Class GetSyncGroupCommand.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsCommon.Get, StorageSyncNouns.NounAzureRmStorageSyncGroup, DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet), OutputType(typeof(PSSyncGroup))]
    public class GetSyncGroupCommand : StorageSyncClientCmdletBase
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
        [Alias(StorageSyncAliases.StorageSyncServiceAlias)]
        public PSStorageSyncService ParentObject { get; set; }

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
        [ResourceIdCompleter(StorageSyncConstants.StorageSyncServiceType)]
        [Alias(StorageSyncAliases.StorageSyncServiceIdAlias)]
        public string ParentResourceId { get; set; }


        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.SyncGroupNameParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices/syncGroups", "ResourceGroupName", "StorageSyncServiceName")]
        [Alias(StorageSyncAliases.SyncGroupNameAlias)]
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
                    if (!string.Equals(StorageSyncConstants.StorageSyncServiceType, parentResourceIdentifier.ResourceType, System.StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException(StorageSyncResources.MissingParentResourceIdErrorMessage);
                    }
                }

                var resourceGroupName = ResourceGroupName ?? ParentObject?.ResourceGroupName ?? parentResourceIdentifier?.ResourceGroupName;
                var parentResourceName = StorageSyncServiceName ?? ParentObject?.StorageSyncServiceName ?? parentResourceIdentifier?.ResourceName;
                 if (!this.IsParameterBound(c => c.Name))
                {
                    
                    WriteObject(StorageSyncClientWrapper.StorageSyncManagementClient.SyncGroups.ListByStorageSyncService(resourceGroupName, parentResourceName));
                }
                else
                {
                    WriteObject(StorageSyncClientWrapper.StorageSyncManagementClient.SyncGroups.Get(resourceGroupName, parentResourceName, Name));
                }
            });
        }
    }
}
