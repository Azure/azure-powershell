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

namespace Microsoft.Azure.Commands.StorageSync.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Unregister, StorageSyncNouns.NounAzureRmStorageSyncServer, DefaultParameterSetName = StorageSyncParameterSets.ObjectParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class UnregisterServerCommand : StorageSyncClientCmdletBase
    {
        [Parameter(Mandatory = true,
                   ParameterSetName = StorageSyncParameterSets.InputObjectParameterSet,
                   Position = 0,
                   ValueFromPipeline = true,
                   HelpMessage = HelpMessages.RegisteredServerInputObjectParameter)]
        [ValidateNotNullOrEmpty]
        public PSRegisteredServer InputObject { get; set; }

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = StorageSyncParameterSets.ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.RegisteredServerResourceIdParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter(StorageSyncConstants.RegisteredServerType)]
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
        [Alias(StorageSyncAliases.ParentNameAlias)]
        public string StorageSyncServiceName { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = StorageSyncParameterSets.StringParameterSet,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.RegisteredServerNameParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.RegisteredServerNameAlias)]
        public Guid ServerId { get; set; }

        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.RegisteredServerForceParameter)]
        public SwitchParameter Force { get; set; }

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
                var parentResourceName = default(string);

                if (!string.IsNullOrEmpty(ResourceId))
                {
                    var resourceIdentifier = new ResourceIdentifier(ResourceId);

                    if (!string.Equals(StorageSyncConstants.RegisteredServerType, resourceIdentifier.ResourceType, System.StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException($"Invalid Argument {nameof(ResourceId)}", nameof(ResourceId));
                    }
                    resourceName = resourceIdentifier.ResourceName;
                    resourceGroupName = resourceIdentifier.ResourceGroupName;
                    parentResourceName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName);
                }
                else if (InputObject != null)
                {
                    resourceName = InputObject.ServerId;
                    resourceGroupName = InputObject.ResourceGroupName;
                    parentResourceName = InputObject.StorageSyncServiceName;
                }
                else
                {
                    resourceName = ServerId.ToString();
                    resourceGroupName = ResourceGroupName;
                    parentResourceName = StorageSyncServiceName;
                }

                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    throw new PSArgumentException($"Invalid Argument {nameof(ResourceGroupName)}", nameof(ResourceGroupName));
                }
                else if (string.IsNullOrEmpty(parentResourceName))
                {
                    throw new PSArgumentException($"Invalid Argument {nameof(StorageSyncServiceName)}", nameof(StorageSyncServiceName));
                }
                else if (string.IsNullOrEmpty(resourceName))
                {
                    throw new PSArgumentException($"Invalid Argument {nameof(ServerId)}", nameof(ServerId));
                }

                if (ShouldProcess(resourceName, "Remove Sync Group"))
                {
                    if (Force || ShouldContinue(string.Format("Remove Sync Group '{0}' and all content in it", resourceName), ""))
                    {
                        StorageSyncClientWrapper.StorageSyncManagementClient.RegisteredServers.Delete(resourceGroupName, parentResourceName, resourceName);
                    }
                }
            });

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
