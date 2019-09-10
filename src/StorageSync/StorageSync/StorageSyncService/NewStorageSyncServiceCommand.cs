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
using Microsoft.Azure.Commands.StorageSync.Properties;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.Azure.Management.StorageSync.Models;
using System.Collections;
using System.Management.Automation;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.StorageSync.StorageSyncService
{

    /// <summary>
    /// Creates a new StorageSyncService in a specific location.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsCommon.New, StorageSyncNouns.NounAzureRmStorageSyncService,
        DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSStorageSyncService))]
    public class NewStorageSyncServiceCommand : StorageSyncClientCmdletBase
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Parameter(Position = 1,
            ParameterSetName = StorageSyncParameterSets.StringParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.StorageSyncServiceNameParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.StorageSyncServiceNameAlias)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        [Parameter(
           Position = 2,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.StorageSyncServiceLocationParameter)]
        [LocationCompleter(StorageSyncConstants.StorageSyncServiceType)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>The tag.</value>
        [Parameter(
             ParameterSetName = StorageSyncParameterSets.StringParameterSet,
             Mandatory = false,
             HelpMessage = HelpMessages.StorageSyncServiceTagsParameter)]
        [ValidateNotNull]
        [Alias(StorageSyncAliases.TagsAlias)]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        protected override string Target => Name;

        /// <summary>
        /// Gets or sets the action message.
        /// </summary>
        /// <value>The action message.</value>
        protected override string ActionMessage => $"{StorageSyncResources.NewStorageSyncServiceActionMessage} {Name}";

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {

            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {

                CheckNameAvailabilityResult checkNameAvailabilityResult = StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.CheckNameAvailability(Location.Replace(" ", string.Empty), Name);

                if (!checkNameAvailabilityResult.NameAvailable.Value)
                {
                    throw new PSArgumentException(checkNameAvailabilityResult.Message, nameof(Name));
                }

                var createParameters = new StorageSyncServiceCreateParameters()
                {
                    Location = Location,
                    Tags = TagsConversionHelper.CreateTagDictionary(Tag ?? new Hashtable(), validate: true),
                };

                Target = string.Join("/", ResourceGroupName, Name);
                if (ShouldProcess(Target, ActionMessage))
                {
                    StorageSyncModels.StorageSyncService storageSyncService = StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.Create(ResourceGroupName, Name, createParameters);

                    WriteObject(storageSyncService);
                }
            });
        }
    }
}