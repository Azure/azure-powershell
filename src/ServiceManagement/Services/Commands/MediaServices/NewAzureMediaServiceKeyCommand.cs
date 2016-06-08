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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.MediaServices;
using Microsoft.WindowsAzure.Commands.Utilities.MediaServices.Services.Entities;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Management.MediaServices.Models;
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.MediaServices
{
    public enum KeyType
    {
        Primary,
        Secondary
    }

    /// <summary>
    ///     Resets an Azure Media Services key.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureMediaServicesKey", SupportsShouldProcess = true), OutputType(typeof(string))]
    public class NewAzureMediaServiceKeyCommand : AzureMediaServicesHttpClientCommandBase
    {
        /// <summary>
        /// The media services account name.
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The media services account name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The media services key type Primary|Secondary.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The media services key type <Primary|Secondary>.")]
        [ValidateNotNullOrEmpty]
        public MediaServicesKeyType KeyType { get; set; }

        [Parameter(Position = 2, HelpMessage = "Do not confirm regeneration of the key.")]
        public SwitchParameter Force { get; set; }

        public IMediaServicesClient MediaServicesClient { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(Force.IsPresent,
                          string.Format(Resources.RegenerateKeyWarning),
                          Resources.RegenerateKeyWhatIfMessage,
                          string.Empty,
                          () =>
                          {
                              MediaServicesClient = MediaServicesClient ?? new MediaServicesClient(Profile, Profile.Context.Subscription, WriteDebug);

                              
                              AzureOperationResponse result = null;
                              CatchAggregatedExceptionFlattenAndRethrow(() => { result = MediaServicesClient.RegenerateMediaServicesAccountAsync(Name, KeyType).Result; });
                            
                              MediaServiceAccountDetails account = null;
                              CatchAggregatedExceptionFlattenAndRethrow(() => { account = new MediaServiceAccountDetails(MediaServicesClient.GetMediaServiceAsync(Name).Result); });
                              string newKey = KeyType == MediaServicesKeyType.Primary ? account.AccountKeys.Primary : account.AccountKeys.Secondary;

                              WriteObject(newKey);
                          });
        }
    }
}