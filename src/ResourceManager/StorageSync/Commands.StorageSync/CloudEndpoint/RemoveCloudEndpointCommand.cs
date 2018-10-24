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
using Microsoft.Azure.Commands.StorageSync.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.StorageSync;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.CloudEndpoint
{
    [Cmdlet(VerbsCommon.Remove, StorageSyncNouns.NounAzureRmStorageSyncCloudEndpoint, DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet)]
    public class RemoveCloudEndpointCommand : StorageSyncClientCmdletBase
    {
        [Parameter(Mandatory = true,
                   ParameterSetName = StorageSyncParameterSets.InputObjectParameterSet,
                   Position = 0,
                   ValueFromPipeline = true,
                   HelpMessage = HelpMessages.CloudEndpointInputObjectParameter)]
        [ValidateNotNullOrEmpty]
        public PSCloudEndpoint InputObject { get; set; }

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = StorageSyncParameterSets.ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.CloudEndpointResourceIdParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter(StorageSyncConstants.CloudEndpointType)]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
             ParameterSetName = StorageSyncParameterSets.StringParameterSet,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.ResourceGroupNameParameter)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
             Position = 1,
             ParameterSetName = StorageSyncParameterSets.StringParameterSet,
             Mandatory = true,
             ValueFromPipelineByPropertyName = false,
             HelpMessage = HelpMessages.StorageSyncServiceNameParameter)]
        [StorageSyncServiceCompleter]
        [ValidateNotNullOrEmpty]
        public string StorageSyncServiceName { get; set; }

        [Parameter(
            Position = 2,
            ParameterSetName = StorageSyncParameterSets.StringParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.SyncGroupNameParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.ParentNameAlias)]
        public string SyncGroupName { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName = StorageSyncParameterSets.StringParameterSet,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.CloudEndpointNameParameter)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = false,
           HelpMessage = HelpMessages.CloudEndpointForceParameter)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJobParameter)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                var resourceName = default(string);
                var resourceGroupName = default(string);
                var storageSyncServiceName = default(string);
                var parentResourceName = default(string);

                if (!string.IsNullOrEmpty(ResourceId))
                {
                    var resourceIdentifier = new ResourceIdentifier(ResourceId);
                    resourceName = resourceIdentifier.ResourceName;
                    resourceGroupName = resourceIdentifier.ResourceGroupName;
                    parentResourceName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.SyncGroupTypeName, 0);
                    storageSyncServiceName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 1);
                }
                else if (InputObject != null)
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

                if (ShouldProcess(resourceName, "Remove Cloud Endpoint"))
                {
                    if (Force || ShouldContinue(string.Format("Remove Cloud Endpoint '{0}' and all content in it", resourceName), String.Empty))
                    {
                        StorageSyncClientWrapper.StorageSyncManagementClient.CloudEndpoints.Delete(resourceGroupName, storageSyncServiceName, parentResourceName, resourceName);
                    }
                }
            });
        }
    }
}
