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
using Microsoft.Azure.Management.StorageSync.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.CloudEndpoint
{
    /// <summary>
    /// Class SetCloudEndpointCommand.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsCommon.Set, StorageSyncNouns.NounAzureRmStorageSyncCloudEndpoint,
        DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSCloudEndpoint))]
    public class SetCloudEndpointCommand : StorageSyncClientCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the resource group.
        /// </summary>
        /// <value>The name of the resource group.</value>
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = false,
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
           ValueFromPipelineByPropertyName = false,
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
           ValueFromPipelineByPropertyName = false,
           HelpMessage = HelpMessages.SyncGroupNameParameter)]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices/syncGroups", "ResourceGroupName", "StorageSyncServiceName")]
        [ValidateNotNullOrEmpty]
        public string SyncGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Parameter(Position = 3,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.CloudEndpointNameParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices/syncGroups/cloudEndpoints", "ResourceGroupName", "StorageSyncServiceName", "SyncGroupName")]
        [Alias(StorageSyncAliases.CloudEndpointNameAlias)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier.
        /// </summary>
        /// <value>The resource identifier.</value>
        [Parameter(Mandatory = true,
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ResourceIdParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.CloudEndpointResourceIdParameter)]
        [ResourceIdCompleter(StorageSyncConstants.CloudEndpointType)]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the input object.
        /// </summary>
        /// <value>The input object.</value>
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ObjectParameterSet,
           Mandatory = true,
           ValueFromPipeline = true,
           HelpMessage = HelpMessages.CloudEndpointObjectParameter)]
        [Alias(StorageSyncAliases.CloudEndpointAlias)]
        public PSCloudEndpoint InputObject { get; set; }

        /// <summary>
        /// Gets or sets the change enumeration interval day.
        /// </summary>
        /// <value>The change enumeration interval day.</value>
        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = false,
          HelpMessage = HelpMessages.ChangeEnumerationIntervalDayParameter)]
        [ValidateRange(1, 20)]
        public int? ChangeEnumerationIntervalDay { get; set; }

        /// <summary>
        /// Gets or sets as job.
        /// </summary>
        /// <value>As job.</value>
        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJobParameter)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        protected override string Target => Name ?? ResourceId ?? InputObject?.CloudEndpointName;

        /// <summary>
        /// Gets or sets the action message.
        /// </summary>
        /// <value>The action message.</value>
        protected override string ActionMessage => $"Update CloudEndpoint: {Name ?? ResourceId ?? InputObject?.CloudEndpointName}";

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                var resourceName = default(string);
                var resourceGroupName = default(string);
                var storageSyncServiceName = default(string);
                var parentResourceName = default(string);

                if (this.IsParameterBound(c => c.InputObject))
                {
                    resourceName = InputObject.CloudEndpointName;
                    resourceGroupName = InputObject.ResourceGroupName;
                    parentResourceName = InputObject.SyncGroupName;
                    storageSyncServiceName = InputObject.StorageSyncServiceName;
                }
                else
                {
                    if (this.IsParameterBound(c => c.ResourceId))
                    {
                        var resourceIdentifier = new ResourceIdentifier(ResourceId);
                        resourceName = resourceIdentifier.ResourceName;
                        resourceGroupName = resourceIdentifier.ResourceGroupName;
                        parentResourceName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.SyncGroupTypeName, 0);
                        storageSyncServiceName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 1);
                    }
                    else
                    {
                        resourceName = Name;
                        resourceGroupName = ResourceGroupName;
                        parentResourceName = SyncGroupName;
                        storageSyncServiceName = StorageSyncServiceName;
                    }
                }

                // Get the existing cloud endpoint
                StorageSyncModels.CloudEndpoint existingCloudEndpoint = StorageSyncClientWrapper.StorageSyncManagementClient.CloudEndpoints.Get(
                    resourceGroupName,
                    storageSyncServiceName,
                    parentResourceName,
                    resourceName);

                if (existingCloudEndpoint == null)
                {
                    throw new PSArgumentException($"Cloud endpoint '{resourceName}' not found.");
                }

                // Create update parameters with the existing values and new ChangeEnumerationIntervalDays
                var updateParameters = new CloudEndpointCreateParameters()
                {
                    StorageAccountResourceId = existingCloudEndpoint.StorageAccountResourceId,
                    AzureFileShareName = existingCloudEndpoint.AzureFileShareName,
                    StorageAccountTenantId = existingCloudEndpoint.StorageAccountTenantId,
                    FriendlyName = existingCloudEndpoint.FriendlyName
                };

                // Apply the update if parameter is provided
                if (this.IsParameterBound(c => c.ChangeEnumerationIntervalDay))
                {
                    updateParameters.ChangeEnumerationIntervalDays = ChangeEnumerationIntervalDay;
                }
                else if (existingCloudEndpoint.ChangeEnumerationIntervalDays.HasValue)
                {
                    updateParameters.ChangeEnumerationIntervalDays = existingCloudEndpoint.ChangeEnumerationIntervalDays;
                }

                Target = string.Join("/", resourceGroupName, storageSyncServiceName, parentResourceName, resourceName);
                if (ShouldProcess(Target, ActionMessage))
                {
                    StorageSyncModels.CloudEndpoint resource = StorageSyncClientWrapper.StorageSyncManagementClient.CloudEndpoints.Create(
                        resourceGroupName,
                        storageSyncServiceName,
                        parentResourceName,
                        resourceName,
                        updateParameters);

                    WriteObject(resource);
                }
            });
        }
    }
}
