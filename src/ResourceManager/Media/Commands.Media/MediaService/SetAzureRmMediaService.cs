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

using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Media.Common;
using Microsoft.Azure.Commands.Media.Models;
using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using RestMediaService = Microsoft.Azure.Management.Media.Models.MediaService;

namespace Microsoft.Azure.Commands.Media.MediaService
{
    /// <summary>
    /// Update a media service.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, MediaServiceNounStr, SupportsShouldProcess = true), OutputType(typeof(PSMediaService))]
    public class SetAzureRmMediaService : AzureMediaServiceCmdletBase
    {
        private const string SetMediaServiceWhatIfMessage = "Set MediaService ";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The media service account name.")]
        [ValidateNotNullOrEmpty]
        [ValidateLength(MediaServiceAccountNameMinLength, MediaServiceAccountNameMaxLength)]
        [ValidatePattern(MediaServiceAccountNamePattern, Options = RegexOptions.None)]
        [Alias("Name", "ResourceName")]
        public string AccountName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The tags associated with the media account.")]
        [ValidateNotNull]
        public Hashtable Tags { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage accounts assosiated with the media account.")]
        [ValidateNotNull]
        public PSStorageAccount[] StorageAccounts { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(AccountName, SetMediaServiceWhatIfMessage))
            {
                var mediaServiceParams = new RestMediaService();

                if (Tags != null)
                {
                    mediaServiceParams.Tags = Tags.ToDictionaryTags();
                }

                if (StorageAccounts != null)
                {
                    // check storage accounts parameter
                    var primaryStorageAccounts = StorageAccounts.Where(x => x.IsPrimary.HasValue && x.IsPrimary.Value).ToArray();
                    if (primaryStorageAccounts.Count() != 1)
                    {
                        throw new ArgumentException(Properties.Resource.OnlyOnePrimaryStorageAccountAllowed);
                    }

                    var mediaService = MediaServicesManagementClient.MediaService.Get(ResourceGroupName, AccountName);
                    if (mediaService == null)
                    {
                        throw new ArgumentException(string.Format(Properties.Resource.InvalidMediaServiceAccount,
                            AccountName,
                            SubscrptionName,
                            ResourceGroupName));
                    }

                    var primaryStorageAccount = mediaService.StorageAccounts.FirstOrDefault(x => (x.IsPrimary.HasValue && x.IsPrimary.Value));
                    // there must be a primary storage account associated with the media service account
                    if (primaryStorageAccount == null)
                    {
                        throw new Exception(string.Format(
                            Properties.Resource.InvalidMediaServiceAccount,
                            AccountName,
                            SubscrptionName,
                            ResourceGroupName));
                    }

                    if (!string.Equals(primaryStorageAccount.Id, primaryStorageAccounts[0].Id, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new ArgumentException("Primary storage account cann't be changed");
                    }

                    mediaServiceParams.StorageAccounts = StorageAccounts.Select(x => x.ToStorageAccount()).ToList();
                }

                try
                {
                    var mediaServiceUpdated = MediaServicesManagementClient.MediaService.Update(ResourceGroupName,
                                AccountName, mediaServiceParams);
                    WriteObject(mediaServiceUpdated.ToPSMediaService(), true);
                }
                catch (ApiErrorException exception)
                {
                    if (exception.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                    {
                        throw new ArgumentException(string.Format(Properties.Resource.InvalidMediaServiceAccount,
                            AccountName,
                            SubscrptionName,
                            ResourceGroupName));
                    }
                    throw;
                }
            }
        }
    }
}
