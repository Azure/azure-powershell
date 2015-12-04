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


using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.MediaServices;
using Microsoft.WindowsAzure.Commands.Utilities.MediaServices.Services.Entities;

namespace Microsoft.WindowsAzure.Commands.MediaServices
{
    /// <summary>
    ///     Gets an Azure Media Services account.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureMediaServicesAccount"), OutputType(typeof(MediaServiceAccountDetails), typeof(IEnumerable<MediaServiceAccount>))]
    public class GetAzureMediaServiceCommand : AzureMediaServicesHttpClientCommandBase
    {
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The media service account name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the media services client.
        /// </summary>
        /// <value>
        ///     The media services client.
        /// </value>
        public IMediaServicesClient MediaServicesClient { get; set; }

        protected virtual void WriteMediaAccounts(IEnumerable<MediaServiceAccount> mediaServiceAccounts)
        {
            WriteObject(mediaServiceAccounts, true);
        }

        /// <summary>
        ///     Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            MediaServicesClient = MediaServicesClient ?? new MediaServicesClient(Profile, Profile.Context.Subscription, WriteDebug);

            if (!string.IsNullOrEmpty(Name))
            {
                MediaServiceAccountDetails account = null;
                CatchAggregatedExceptionFlattenAndRethrow(() => { account = new MediaServiceAccountDetails(MediaServicesClient.GetMediaServiceAsync(Name).Result); });
                WriteObject(account, false);
            }
            else
            {
                var accounts = new List<MediaServiceAccount>();
                accounts.AddRange(MediaServicesClient.GetMediaServiceAccountsAsync().Result.Accounts.Select(c=>new MediaServiceAccount(c)));
                // Output results
                WriteMediaAccounts(accounts);
            }
        }

       
    }
}