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
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Media.Common;
using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Rest.Models;

namespace Microsoft.Azure.Commands.Media.ServiceKey
{
    /// <summary>
    /// Synchronizes storage account keys for a storage account associated with the Media Service.
    /// </summary>
    [Cmdlet(VerbsData.Sync, MediaServiceStorageKeysNounStr), OutputType(typeof(bool))]
    public class SyncAzureRmMediaServiceStorageKeys : AzureMediaServiceCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The media service account name.")]
        [ValidateNotNullOrEmpty]
        [ValidateLength(MediaServiceAccountNameMinLength, MediaServiceAccountNameMaxLength)]
        [ValidatePattern(MediaServiceAccountNamePattern, Options = RegexOptions.None)]
        public string MediaServiceAccountName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The storage account name.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        public override void ExecuteCmdlet()
        {
            SetApiVersion();

            try
            {
                AzureMediaServicesClient.MediaservicesSyncStorageKeys(
                    SubscriptionId,
                    ResourceGroupName,
                    MediaServiceAccountName,
                    new SyncStorageKeysInput(GetStorageAccountId(StorageAccountName)),
                    ApiVersion);

                WriteObject(true);
            }
            catch (ApiErrorException exception)
            {
                if (exception.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    throw new ArgumentException(string.Format("MediaServiceAccount {0} or StorageAccount {1} under subscprition {2} and resourceGroup {3} doesn't exist",
                        MediaServiceAccountName,
                        StorageAccountName,
                        SubscrptionName,
                        ResourceGroupName));
                }
            }
        }
    }
}
