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
using Microsoft.Azure.Management.StorageSync.Models;
using System.Management.Automation;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Invoke, StorageSyncNouns.NounAzureRmStorageSyncFileRecall, DefaultParameterSetName = StorageSyncParameterSets.ObjectParameterSet), OutputType(typeof(bool))]
    public class InvokeStorageSyncFileRecallCommand : StorageSyncClientCmdletBase
    {
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
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
        [Alias(StorageSyncAliases.ParentNameAlias)]
        public string StorageSyncServiceName { get; set; }

        [Parameter(
           Position = 2,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = false,
           HelpMessage = HelpMessages.SyncGroupNameParameter)]
        [ValidateNotNullOrEmpty]
        public string SyncGroupName { get; set; }

        [Parameter(Position = 3,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.ServerEndpointNameParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.ServerEndpointNameAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ResourceIdParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.ServerEndpointResourceIdParameter)]
        [ResourceIdCompleter(StorageSyncConstants.ServerEndpointType)]
        public string ResourceId { get; set; }

        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ObjectParameterSet,
           Mandatory = true,
           ValueFromPipeline = true,
           HelpMessage = HelpMessages.SyncGroupObjectParameter)]
        [Alias(StorageSyncAliases.RegisteredServerAlias)]
        public PSServerEndpoint InputObject{ get; set; }

        [Parameter(
        Mandatory = false,
        ValueFromPipelineByPropertyName = false,
        HelpMessage = HelpMessages.PatternParameter)]
        public string Pattern { get; set; }

        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = false,
          HelpMessage = HelpMessages.RecallPathParameter)]
        public string RecallPath { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

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
                    resourceName = InputObject.ServerEndpointName;
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

                var recallActionParameters = new RecallActionParameters()
                {
                    Pattern = Pattern,
                    RecallPath = RecallPath
                };

                StorageSyncClientWrapper.StorageSyncManagementClient.ServerEndpoints.RecallAction(
                    resourceGroupName,
                    storageSyncServiceName,
                    parentResourceName,
                    resourceName,
                    recallActionParameters);
                
            });

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}