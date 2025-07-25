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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.CloudEndpoint
{

    /// <summary>
    /// Class InvokeChangeDetectionCommand.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsLifecycle.Invoke, StorageSyncNouns.NounAzureRmStorageSyncChangeDetection,
        DefaultParameterSetName = StorageSyncParameterSets.ChangeDetectionFullShareStringParameterSet, SupportsShouldProcess = true), OutputType(typeof(void))]
    public class InvokeChangeDetectionCommand : StorageSyncClientCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the resource group.
        /// </summary>
        /// <value>The name of the resource group.</value>
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ChangeDetectionStringAndDirectoryParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = false,
           HelpMessage = HelpMessages.ResourceGroupNameParameter)]
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ChangeDetectionStringAndPathParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = false,
           HelpMessage = HelpMessages.ResourceGroupNameParameter)]
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ChangeDetectionFullShareStringParameterSet,
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
           ParameterSetName = StorageSyncParameterSets.ChangeDetectionStringAndDirectoryParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = false,
           HelpMessage = HelpMessages.StorageSyncServiceNameParameter)]
        [Parameter(
           Position = 1,
           ParameterSetName = StorageSyncParameterSets.ChangeDetectionStringAndPathParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = false,
           HelpMessage = HelpMessages.StorageSyncServiceNameParameter)]
        [Parameter(
           Position = 1,
           ParameterSetName = StorageSyncParameterSets.ChangeDetectionFullShareStringParameterSet,
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
           ParameterSetName = StorageSyncParameterSets.ChangeDetectionStringAndDirectoryParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = false,
           HelpMessage = HelpMessages.SyncGroupNameParameter)]
        [Parameter(
           Position = 2,
           ParameterSetName = StorageSyncParameterSets.ChangeDetectionStringAndPathParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = false,
           HelpMessage = HelpMessages.SyncGroupNameParameter)]
        [Parameter(
           Position = 2,
           ParameterSetName = StorageSyncParameterSets.ChangeDetectionFullShareStringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = false,
           HelpMessage = HelpMessages.SyncGroupNameParameter)]
        [ValidateNotNullOrEmpty]
        // TODO : Place ResourceNameCompleter for all non root resources. https://github.com/Azure/azure-powershell/issues/8620
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices/syncGroups", "ResourceGroupName", "StorageSyncServiceName")]
        public string SyncGroupName { get; set; }

        /// <summary>
        /// Gets or sets the CloudEndpointName.
        /// </summary>
        /// <value>The cloud endpoint name.</value>
        [Parameter(Mandatory = true,
            ParameterSetName = StorageSyncParameterSets.ChangeDetectionStringAndDirectoryParameterSet,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.CloudEndpointNameParameter)]
        [Parameter(Mandatory = true,
            ParameterSetName = StorageSyncParameterSets.ChangeDetectionStringAndPathParameterSet,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.CloudEndpointNameParameter)]
        [Parameter(Mandatory = true,
            ParameterSetName = StorageSyncParameterSets.ChangeDetectionFullShareStringParameterSet,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.CloudEndpointNameParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.CloudEndpointNameAlias)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier.
        /// </summary>
        /// <value>The parent resource identifier.</value>
        [Parameter(
          Position = 0,
          ParameterSetName = StorageSyncParameterSets.ChangeDetectionResourceIdAndDirectoryParameterSet,
          Mandatory = true,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = HelpMessages.CloudEndpointResourceIdParameter)]
        [Parameter(
          Position = 0,
          ParameterSetName = StorageSyncParameterSets.ChangeDetectionResourceIdAndPathParameterSet,
          Mandatory = true,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = HelpMessages.CloudEndpointResourceIdParameter)]
        [Parameter(
          Position = 0,
          ParameterSetName = StorageSyncParameterSets.ChangeDetectionFullShareResourceIdParameterSet,
          Mandatory = true,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = HelpMessages.CloudEndpointResourceIdParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.CloudEndpointIdAlias)]
        [ResourceIdCompleter(StorageSyncConstants.CloudEndpointType)]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the input object.
        /// </summary>
        /// <value>The input object.</value>
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ChangeDetectionObjectAndDirectoryParameterSet,
           Mandatory = true,
           ValueFromPipeline = true,
           HelpMessage = HelpMessages.CloudEndpointObjectParameter)]
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ChangeDetectionObjectAndPathParameterSet,
           Mandatory = true,
           ValueFromPipeline = true,
           HelpMessage = HelpMessages.CloudEndpointObjectParameter)]
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ChangeDetectionFullShareObjectParameterSet,
           Mandatory = true,
           ValueFromPipeline = true,
           HelpMessage = HelpMessages.CloudEndpointObjectParameter)]
        [Alias(StorageSyncAliases.CloudEndpointAlias)]
        public PSCloudEndpoint InputObject { get; set; }

        /// <summary>
        /// Gets or sets the directory path to detect changes.
        /// </summary>
        /// <value>path to detect changes</value>
        [Parameter(Mandatory = true,
                   ValueFromPipelineByPropertyName = false,
                   ParameterSetName = StorageSyncParameterSets.ChangeDetectionStringAndDirectoryParameterSet,
                   HelpMessage = HelpMessages.ChangeDetectionDirectoryPathParameter)]
        [Parameter(Mandatory = true,
                   ValueFromPipelineByPropertyName = false,
                   ParameterSetName = StorageSyncParameterSets.ChangeDetectionObjectAndDirectoryParameterSet,
                   HelpMessage = HelpMessages.ChangeDetectionDirectoryPathParameter)]
        [Parameter(Mandatory = true,
                   ValueFromPipelineByPropertyName = false,
                   ParameterSetName = StorageSyncParameterSets.ChangeDetectionResourceIdAndDirectoryParameterSet,
                   HelpMessage = HelpMessages.ChangeDetectionDirectoryPathParameter)]
        [AllowEmptyString]
        public string DirectoryPath { get; set; }

        /// <summary>
        /// Gets or sets the recursive mode
        /// </summary>
        /// <value></value>
        [Parameter(Mandatory = false,
                   ValueFromPipelineByPropertyName = false,
                   ParameterSetName = StorageSyncParameterSets.ChangeDetectionStringAndDirectoryParameterSet,
                   HelpMessage = HelpMessages.ChangeDetectionRecurseParameter)]
        [Parameter(Mandatory = false,
                   ValueFromPipelineByPropertyName = false,
                   ParameterSetName = StorageSyncParameterSets.ChangeDetectionObjectAndDirectoryParameterSet,
                   HelpMessage = HelpMessages.ChangeDetectionRecurseParameter)]
        [Parameter(Mandatory = false,
                   ValueFromPipelineByPropertyName = false,
                   ParameterSetName = StorageSyncParameterSets.ChangeDetectionResourceIdAndDirectoryParameterSet,
                   HelpMessage = HelpMessages.ChangeDetectionRecurseParameter)]
        public SwitchParameter Recursive { get; set; }


        /// <summary>
        /// Gets or sets the paths to individual files or folders to be included in change detection process.
        /// </summary>
        /// <value>paths to be included in change detection</value>
        [Parameter(Mandatory = true,
                   ValueFromPipelineByPropertyName = false,
                   ParameterSetName = StorageSyncParameterSets.ChangeDetectionStringAndPathParameterSet,
                   HelpMessage = HelpMessages.ChangeDetectionPathParameter)]
        [Parameter(Mandatory = true,
                   ValueFromPipelineByPropertyName = false,
                   ParameterSetName = StorageSyncParameterSets.ChangeDetectionObjectAndPathParameterSet,
                   HelpMessage = HelpMessages.ChangeDetectionPathParameter)]
        [Parameter(Mandatory = true,
                   ValueFromPipelineByPropertyName = false,
                   ParameterSetName = StorageSyncParameterSets.ChangeDetectionResourceIdAndPathParameterSet,
                   HelpMessage = HelpMessages.ChangeDetectionPathParameter)]
        [AllowEmptyCollection]
        public string[] Path { get; set; }

        /// <summary>
        /// Gets or sets the pass thru.
        /// </summary>
        /// <value>The pass thru.</value>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets as job.
        /// </summary>
        /// <value>As job.</value>
        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJobParameter)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Gets the target.
        /// </summary>
        /// <value>The target.</value>
        protected override string Target => Name;

        /// <summary>
        /// Gets the action message.
        /// </summary>
        /// <value>The action message.</value>
        protected override string ActionMessage => StorageSyncResources.InvokeChangeDetectionActionMessage;

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

                if (this.IsParameterBound(c => c.ResourceId))
                {
                    var resourceIdentifier = new ResourceIdentifier(ResourceId);
                    resourceName = resourceIdentifier.ResourceName;
                    resourceGroupName = resourceIdentifier.ResourceGroupName;
                    parentResourceName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.SyncGroupTypeName, 0);
                    storageSyncServiceName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 1);
                }
                else if (this.IsParameterBound(c => c.InputObject))
                {
                    resourceName = InputObject.CloudEndpointName;
                    resourceGroupName = InputObject.ResourceGroupName;
                    parentResourceName = InputObject.SyncGroupName;
                    storageSyncServiceName = InputObject.StorageSyncServiceName;
                }
                else
                {
                    resourceName = Name;
                    resourceGroupName = ResourceGroupName;
                    parentResourceName = SyncGroupName;
                    storageSyncServiceName = StorageSyncServiceName;
                }

                var triggerChangeDetectionParameters = new TriggerChangeDetectionParameters();
                if (this.IsParameterBound(c => c.DirectoryPath))
                {
                    if (this.DirectoryPath == null)
                    {
                        throw new PSArgumentException(nameof(this.DirectoryPath));
                    }

                    triggerChangeDetectionParameters.DirectoryPath = this.DirectoryPath;
                    triggerChangeDetectionParameters.ChangeDetectionMode = this.Recursive.IsPresent ? ChangeDetectionMode.Recursive : ChangeDetectionMode.Default;
                }
                else if (this.IsParameterBound(c => c.Path))
                {
                    if (this.Path == null || this.Path.Length == 0)
                    {
                        throw new PSArgumentException(nameof(this.Path));
                    }

                    triggerChangeDetectionParameters.Paths = this.Path.ToList();
                }

                string target = string.Join("/", resourceGroupName, storageSyncServiceName, parentResourceName, resourceName);

                if (ShouldProcess(target, ActionMessage))
                {
                    StorageSyncClientWrapper.StorageSyncManagementClient.CloudEndpoints.TriggerChangeDetection(
                        resourceGroupName: resourceGroupName,
                        storageSyncServiceName: storageSyncServiceName,
                        syncGroupName: parentResourceName,
                        cloudEndpointName: resourceName,
                        parameters: triggerChangeDetectionParameters);
                }
            });

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}