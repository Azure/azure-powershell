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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Cmdlets
{
    /// <summary>
    /// Class SetServerEndpointCommand.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsCommon.Set, StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint,
        DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSServerEndpoint))]
    public class SetServerEndpointCommand : StorageSyncClientCmdletBase
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
            HelpMessage = HelpMessages.ServerEndpointNameParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices/syncGroups/serverEndpoints", "ResourceGroupName", "StorageSyncServiceName", "SyncGroupName")]
        [Alias(StorageSyncAliases.ServerEndpointNameAlias)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier.
        /// </summary>
        /// <value>The resource identifier.</value>
        [Parameter(Mandatory = true,
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ResourceIdParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.ServerEndpointResourceIdParameter)]
        [ResourceIdCompleter(StorageSyncConstants.ServerEndpointType)]
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
           HelpMessage = HelpMessages.SyncGroupObjectParameter)]
        [CmdletParameterBreakingChange("InputObject", ChangeDescription = "Alias RegisteredServer is invalid and preserved for compatibility. Alias ServerEndpoint should be used instead")]
        [Alias(StorageSyncAliases.RegisteredServerAlias, StorageSyncAliases.ServerEndpointAlias)]
        public PSServerEndpoint InputObject { get; set; }

        /// <summary>
        /// Gets or sets the cloud tiering.
        /// </summary>
        /// <value>The cloud tiering.</value>
        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = false,
          HelpMessage = HelpMessages.CloudTieringParameter)]
        public SwitchParameter CloudTiering { get; set; }

        /// <summary>
        /// Gets or sets the volume free space percent.
        /// </summary>
        /// <value>The volume free space percent.</value>
        [Parameter(
        Mandatory = false,
        ValueFromPipelineByPropertyName = false,
        HelpMessage = HelpMessages.VolumeFreeSpacePercentParameter)]
        public int? VolumeFreeSpacePercent { get; set; }

        /// <summary>
        /// Gets or sets the tier files older than days.
        /// </summary>
        /// <value>The tier files older than days.</value>
        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = false,
          HelpMessage = HelpMessages.TierFilesOlderThanDaysParameter)]
        public int? TierFilesOlderThanDays { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the policy to use for regular download sync sessions.
        /// </summary>
        /// <value>The local cache mode.</value>
        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = false,
          HelpMessage = HelpMessages.LocalCacheModeParameter)]
        //[ValidateSet(StorageSyncModels.LocalCacheMode.DownloadNewAndModifiedFiles,
        //    StorageSyncModels.LocalCacheMode.UpdateLocallyCachedFiles,
        //    IgnoreCase = true)]
        [ValidateSet("DownloadNewAndModifiedFiles",
            "UpdateLocallyCachedFiles",
            IgnoreCase = true)]
        public string LocalCacheMode { get; set; }

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
        protected override string Target => Name ?? ResourceId ?? InputObject?.ServerEndpointName;

        /// <summary>
        /// Gets or sets the action message.
        /// </summary>
        /// <value>The action message.</value>
        protected override string ActionMessage => $"{StorageSyncResources.SetServerEndpointActionMessage} {Name ?? ResourceId ?? InputObject?.ServerEndpointName}";

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

                var updateParameters = new ServerEndpointUpdateParameters();

                if (this.IsParameterBound(c => c.InputObject))
                {
                    resourceName = InputObject.ServerEndpointName;
                    resourceGroupName = InputObject.ResourceGroupName;
                    parentResourceName = InputObject.SyncGroupName;
                    storageSyncServiceName = InputObject.StorageSyncServiceName;

                    updateParameters.CloudTiering = InputObject.CloudTiering;
                    updateParameters.VolumeFreeSpacePercent = InputObject.VolumeFreeSpacePercent;
                    updateParameters.TierFilesOlderThanDays = InputObject.TierFilesOlderThanDays;
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

                if (this.IsParameterBound(c => c.CloudTiering))
                {
                    updateParameters.CloudTiering = CloudTiering.ToBool() ? StorageSyncConstants.CloudTieringOn : StorageSyncConstants.CloudTieringOff;
                }
                if (this.IsParameterBound(c => c.VolumeFreeSpacePercent))
                {
                    updateParameters.VolumeFreeSpacePercent = VolumeFreeSpacePercent;
                }
                if (this.IsParameterBound(c => c.TierFilesOlderThanDays))
                {
                    updateParameters.TierFilesOlderThanDays = TierFilesOlderThanDays;
                }

                if (this.IsParameterBound(c => c.LocalCacheMode))
                {
                    updateParameters.LocalCacheMode = LocalCacheMode;
                }

                Target = string.Join("/", resourceGroupName, storageSyncServiceName, parentResourceName, resourceName);
                if (ShouldProcess(Target, ActionMessage))
                {
                    ServerEndpoint resource = StorageSyncClientWrapper.StorageSyncManagementClient.ServerEndpoints.Update(
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