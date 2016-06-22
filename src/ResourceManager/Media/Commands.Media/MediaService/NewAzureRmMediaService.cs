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

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Media.Common;
using Microsoft.Azure.Commands.Media.Models;
using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Rest.Models;
using RestMediaService = Microsoft.Azure.Management.Media.Rest.Models.MediaService;

namespace Microsoft.Azure.Commands.Media.MediaService
{
    /// <summary>
    /// Create a new media service.
    /// </summary>
    [Cmdlet(VerbsCommon.New, MediaServiceNounStr), OutputType(typeof(PSMediaService))]
    public class NewAzureRmMediaService : AzureMediaServiceCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The media service account name.")]
        [ValidateNotNullOrEmpty]
        [ValidateLength(MediaServiceAccountNameMinLength, MediaServiceAccountNameMaxLength)]
        [ValidatePattern(MediaServiceAccountNamePattern)]
        public string MediaServiceAccountName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The tags associated with the media service account.")]
        [ValidateNotNull]
        public Hashtable Tags { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The storage account name.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        public override void ExecuteCmdlet()
        {
            SetApiVersion();

            var restMediaService = new RestMediaService(
                Location,
                Tags.ToDictionaryTags(),
                null,
                null,
                MediaServiceType,
                new MediaServiceProperties
                {
                    StorageAccounts = new List<StorageAccount>
                    {
                        new StorageAccount
                        {
                            Id = GetStorageAccountId(StorageAccountName),
                            IsPrimary = true
                        }
                    }
                });

            var mediaService = AzureMediaServicesClient.PutMediaservices(SubscriptionId, ResourceGroupName, MediaServiceAccountName, restMediaService, ApiVersion);
            WriteObject(mediaService.ToPSMediaService(), true);
        }
    }
}
