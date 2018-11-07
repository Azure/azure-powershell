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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.Azure.Management.StorageSync.Models;
using System.Collections;
using System.Management.Automation;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.StorageSyncService
{

    /// <summary>
    /// Creates a new StorageSyncService in a specific location.
    /// </summary>
    [Cmdlet(VerbsCommon.New, StorageSyncNouns.NounAzureRmStorageSyncService, DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet), OutputType(typeof(PSStorageSyncService))]
    public class NewStorageSyncServiceCommand : StorageSyncClientCmdletBase
    {
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.ResourceGroupNameParameter)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1,
            ParameterSetName = StorageSyncParameterSets.StringParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.StorageSyncServiceNameParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.StorageSyncServiceNameAlias)]
        public string Name { get; set; }

        [Parameter(
           Position = 2,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.StorageSyncServiceLocationParameter)]
        [LocationCompleter(StorageSyncConstants.StorageSyncServiceType)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
             Position = 3,
             ParameterSetName = StorageSyncParameterSets.StringParameterSet,
             Mandatory = false,
             HelpMessage = HelpMessages.StorageSyncServiceTagsParameter)]
        [ValidateNotNull]
        [Alias(StorageSyncAliases.TagsAlias)]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {

                CheckNameAvailabilityResult checkNameAvailabilityResult = StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.CheckNameAvailability(Location.Replace(" ",string.Empty), Name);

                if (!checkNameAvailabilityResult.NameAvailable.Value)
                {
                    throw new System.ArgumentException(checkNameAvailabilityResult.Message, nameof(this.Name));
                }

                StorageSyncServiceCreateParameters createParameters = new StorageSyncServiceCreateParameters()
                {
                    Location = Location,
                    Tags = TagsConversionHelper.CreateTagDictionary(Tag ?? new Hashtable(), validate: true),
                };

                StorageSyncModels.StorageSyncService storageSyncService = this.StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.Create(ResourceGroupName, Name, createParameters);

                WriteObject(storageSyncService);
            });
        }
    }
}
