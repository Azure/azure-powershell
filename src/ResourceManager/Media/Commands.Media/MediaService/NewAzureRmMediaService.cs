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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Media.Common;
using Microsoft.Azure.Commands.Media.Models;
using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using RestMediaService = Microsoft.Azure.Management.Media.Models.MediaService;

namespace Microsoft.Azure.Commands.Media.MediaService
{
    /// <summary>
    /// Create a media service.
    /// </summary>
    [Cmdlet(VerbsCommon.New, MediaServiceNounStr, SupportsShouldProcess = true), OutputType(typeof(PSMediaService))]
    public class NewAzureRmMediaService : AzureMediaServiceCmdletBase
    {
        protected const string PrimaryStorageAccountParamSet = "StorageAccountIdParamSet";
        protected const string StorageAccountsParamSet = "StorageAccountsParamSet";
        private const string NewMediaServiceWhatIfMessage = "New a MediaService";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = PrimaryStorageAccountParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = StorageAccountsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]

        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = PrimaryStorageAccountParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The media service account name.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = StorageAccountsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The media service account name.")]
        [ValidateNotNullOrEmpty]
        [ValidateLength(MediaServiceAccountNameMinLength, MediaServiceAccountNameMaxLength)]
        [ValidatePattern(MediaServiceAccountNamePattern)]
        [Alias("Name", "ResourceName")]
        public string AccountName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = PrimaryStorageAccountParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location.")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = StorageAccountsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ParameterSetName = PrimaryStorageAccountParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The primary storage account assosiated with the media account.")]
        [Alias("Id")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountId { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ParameterSetName = StorageAccountsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage accounts assosiated with the media account.")]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount[] StorageAccounts { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "The tags associated with the media service account.")]
        [ValidateNotNull]
        public Hashtable Tags { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(AccountName, NewMediaServiceWhatIfMessage))
            {
                try
                {
                    var mediaService = MediaServicesManagementClient.MediaService.Get(ResourceGroupName, AccountName);
                    if (mediaService != null)
                    {
                        throw new ArgumentException(string.Format(Properties.Resource.InvalidMediaServiceAccount,
                            AccountName,
                            SubscrptionName,
                            ResourceGroupName));
                    }
                }
                catch (ApiErrorException exception)
                {
                    if (exception.Response != null && exception.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                    {
                        var restMediaService = new RestMediaService(
                            Location,
                            Tags.ToDictionaryTags(),
                            null,
                            null,
                            MediaServiceType);

                        switch (ParameterSetName)
                        {
                            case PrimaryStorageAccountParamSet:
                                restMediaService.StorageAccounts = new List<StorageAccount>
                            {
                                new StorageAccount
                                {
                                    Id = StorageAccountId,
                                    IsPrimary = true
                                }
                            };
                                break;

                            case StorageAccountsParamSet:
                                if (StorageAccounts.Count(x => x.IsPrimary.HasValue && x.IsPrimary.Value) != 1)
                                {
                                    throw new ArgumentException(Properties.Resource.OnlyOnePrimaryStorageAccountAllowed);
                                }

                                restMediaService.StorageAccounts = StorageAccounts.Select(x => x.ToStorageAccount()).ToList();
                                break;

                            default:
                                throw new ArgumentException("Bad ParameterSet Name");
                        }

                        var mediaServiceCreated = MediaServicesManagementClient.MediaService.Create(ResourceGroupName, AccountName, restMediaService);
                        WriteObject(mediaServiceCreated.ToPSMediaService(), true);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
    }
}
