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

using System;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.MediaServices;
using Microsoft.WindowsAzure.Commands.Utilities.MediaServices.Services.Entities;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Management.MediaServices.Models;
using Microsoft.WindowsAzure.Management.Storage.Models;

namespace Microsoft.WindowsAzure.Commands.MediaServices
{
    /// <summary>
    ///     Creates new Azure Media Services account.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureMediaServicesAccount"), OutputType(typeof(AccountCreationResult))]
    public class NewAzureMediaServiceCommand : AzureMediaServicesHttpClientCommandBase
    {
        public IMediaServicesClient MediaServicesClient { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The media service account name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The media service location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Storage account name")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        public override void ExecuteCmdlet()
        {
            MediaServicesClient = MediaServicesClient ?? new MediaServicesClient(Profile, Profile.Context.Subscription, WriteDebug);

            StorageAccountGetKeysResponse storageKeysResponse = null;
            Uri storageEndPoint = null;
            string storageAccountKey = null;

            CatchAggregatedExceptionFlattenAndRethrow(() => { storageKeysResponse = MediaServicesClient.GetStorageServiceKeysAsync(StorageAccountName).Result; });
            storageAccountKey = storageKeysResponse.PrimaryKey;

            StorageAccountGetResponse storageGetResponse = null; 
            CatchAggregatedExceptionFlattenAndRethrow(() => { storageGetResponse = MediaServicesClient.GetStorageServicePropertiesAsync(StorageAccountName).Result; });

            if (storageGetResponse.StorageAccount.Properties != null && storageGetResponse.StorageAccount.Properties.Endpoints.Count > 0)
            {
                storageEndPoint = storageGetResponse.StorageAccount.Properties.Endpoints[0];
            }
            else
            {
                throw new Exception(string.Format(Resources.EndPointNotFoundForBlobStorage, Name));
            }

            AccountCreationResult result = null;
            var request = new MediaServicesAccountCreateParameters()
            {
                AccountName = Name,
                BlobStorageEndpointUri = storageEndPoint,
                Region = Location,
                StorageAccountKey = storageAccountKey,
                StorageAccountName = StorageAccountName
            };
            CatchAggregatedExceptionFlattenAndRethrow(() => { result = new AccountCreationResult(MediaServicesClient.CreateNewAzureMediaServiceAsync(request).Result); });
            WriteObject(result, false);
        }
    }
}