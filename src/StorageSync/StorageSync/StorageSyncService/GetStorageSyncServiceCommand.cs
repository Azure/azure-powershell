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
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.StorageSync;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.StorageSyncService
{

    /// <summary>
    /// Get StorageSyncServices
    /// </summary>
    [Cmdlet(VerbsCommon.Get, StorageSyncNouns.NounAzureRmStorageSyncService, DefaultParameterSetName = StorageSyncParameterSets.ParentStringParameterSet), OutputType(typeof(PSStorageSyncService))]
    public class GetStorageSyncServiceCommand : StorageSyncClientCmdletBase
    {
        [Parameter(
          Position = 0,
          Mandatory = false,
           ParameterSetName = StorageSyncParameterSets.ParentStringParameterSet,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = HelpMessages.ResourceGroupNameParameter)]
        [Parameter(
           Position = 0,
           Mandatory = true,
            ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.ResourceGroupNameParameter)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1,
            Mandatory = false,
            ParameterSetName = StorageSyncParameterSets.StringParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.StorageSyncServiceNameParameter)]
        [ValidateNotNullOrEmpty]
        [StorageSyncServiceCompleter]
        [Alias(StorageSyncAliases.StorageSyncServiceNameAlias)]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                    if (string.IsNullOrEmpty(ResourceGroupName))
                    {
                        WriteObject(StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.ListBySubscription());
                    }
                    else if (string.IsNullOrEmpty(Name))
                    {
                        WriteObject(StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.ListByResourceGroup(ResourceGroupName));
                    }
                    else
                    {
                        WriteObject(StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.Get(ResourceGroupName, Name));
                    }
            });
        }
    }
}
