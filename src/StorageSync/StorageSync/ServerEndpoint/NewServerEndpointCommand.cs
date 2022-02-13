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
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.Cmdlets
{
    /// <summary>
    /// Class NewServerEndpointCommand.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsCommon.New, StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint,
        DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSServerEndpoint))]
    public class NewServerEndpointCommand : StorageSyncClientCmdletBase
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
           HelpMessage = HelpMessages.SyncGroupObjectParameter)]
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
          HelpMessage = HelpMessages.SyncGroupParentResourceIdParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.SyncGroupIdAlias)]
        public string ParentResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.ServerEndpointNameParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.ServerEndpointNameAlias)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the server resource identifier.
        /// </summary>
        /// <value>The server resource identifier.</value>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.RegisteredServerResourceIdParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter(StorageSyncConstants.RegisteredServerType)]
        public string ServerResourceId { get; set; }

        /// <summary>
        /// Gets or sets the server local path.
        /// </summary>
        /// <value>The server local path.</value>
        [Parameter(
          Mandatory = true,
          ValueFromPipelineByPropertyName = false,
          HelpMessage = HelpMessages.ServerLocalPathParameter)]
        [ValidateNotNullOrEmpty]
        public string ServerLocalPath { get; set; }

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

        // <summary>
        /// Gets or sets a value indicating the policy to use for the initial download sync.
        /// </summary>
        /// <value>The initial download policy.</value>
        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = false,
          HelpMessage = HelpMessages.InitialDownloadPolicyParameter)]
        [ValidateSet(StorageSyncModels.InitialDownloadPolicy.AvoidTieredFiles,
            StorageSyncModels.InitialDownloadPolicy.NamespaceOnly,
            StorageSyncModels.InitialDownloadPolicy.NamespaceThenModifiedFiles,
            IgnoreCase = true)]
        public string InitialDownloadPolicy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the policy to use for regular download sync sessions.
        /// </summary>
        /// <value>The local cache mode.</value>
        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = false,
          HelpMessage = HelpMessages.LocalCacheModeParameter)]
        [ValidateSet(StorageSyncModels.LocalCacheMode.DownloadNewAndModifiedFiles,
            StorageSyncModels.LocalCacheMode.UpdateLocallyCachedFiles,
            IgnoreCase = true)]
        public string LocalCacheMode { get; set; }

        // <summary>
        /// Gets or sets a value indicating the policy to use for the initial upload sync.
        /// </summary>
        /// <value>The initial upload policy.</value>
        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = false,
          HelpMessage = HelpMessages.InitialUploadPolicyParameter)]
        [ValidateSet(StorageSyncModels.InitialUploadPolicy.Merge,
            StorageSyncModels.InitialUploadPolicy.ServerAuthoritative,
            IgnoreCase = true)]
        public string InitialUploadPolicy { get; set; }

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
        protected override string Target => Name;

        /// <summary>
        /// Gets or sets the action message.
        /// </summary>
        /// <value>The action message.</value>
        protected override string ActionMessage => $"{StorageSyncResources.NewServerEndpointActionMessage} {Name}";

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

                var createParameters = new StorageSyncModels.ServerEndpointCreateParameters()
                {
                    CloudTiering = CloudTiering.ToBool() ? StorageSyncConstants.CloudTieringOn : StorageSyncConstants.CloudTieringOff,
                    VolumeFreeSpacePercent = VolumeFreeSpacePercent,
                    ServerLocalPath = ServerLocalPath,
                    ServerResourceId = ServerResourceId,
                    TierFilesOlderThanDays = TierFilesOlderThanDays
                };

                if (this.IsParameterBound(c => c.InitialDownloadPolicy))
                {
                    createParameters.InitialDownloadPolicy = InitialDownloadPolicy;
                }

                if (this.IsParameterBound(c => c.LocalCacheMode))
                {
                    createParameters.LocalCacheMode = LocalCacheMode;
                }

                if (this.IsParameterBound(c => c.InitialUploadPolicy))
                {
                    createParameters.InitialUploadPolicy = InitialUploadPolicy;
                }

                string resourceGroupName = ResourceGroupName ?? ParentObject?.ResourceGroupName ?? parentResourceIdentifier.ResourceGroupName;
                string storageSyncServiceName = StorageSyncServiceName ?? ParentObject?.StorageSyncServiceName ?? parentResourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 0);
                string syncGroupName = SyncGroupName ?? ParentObject?.SyncGroupName ?? parentResourceIdentifier.ResourceName;

                Target = string.Join("/", resourceGroupName, storageSyncServiceName, syncGroupName, Name);
                if (ShouldProcess(Target, ActionMessage))
                {
                    StorageSyncModels.ServerEndpoint resource = StorageSyncClientWrapper.StorageSyncManagementClient.ServerEndpoints.Create(
                        resourceGroupName,
                        storageSyncServiceName,
                        syncGroupName,
                        Name,
                        createParameters);

                    WriteObject(resource);
                }
            });
        }
    }
}