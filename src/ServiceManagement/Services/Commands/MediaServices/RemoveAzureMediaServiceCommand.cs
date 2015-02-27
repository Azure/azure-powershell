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
using System.Net;
using Microsoft.WindowsAzure.Commands.Utilities.MediaServices;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.MediaServices
{
    /// <summary>
    ///     Removes an Azure Media Services account.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureMediaServicesAccount", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureMediaServiceCommand : AzureMediaServicesHttpClientCommandBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The media services account name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, HelpMessage = "Do not confirm deletion of account.")]
        public SwitchParameter Force { get; set; }

        public IMediaServicesClient MediaServicesClient { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(Force.IsPresent,
                          string.Format(Resources.RemoveMediaAccountWarning),
                          Resources.RemoveMediaAccountWhatIfMessage,
                          string.Empty,
                          () =>
                          {
                              MediaServicesClient = MediaServicesClient ?? new MediaServicesClient(Profile, Profile.Context.Subscription, WriteDebug);

                              AzureOperationResponse result = null;

                              CatchAggregatedExceptionFlattenAndRethrow(() => { result = MediaServicesClient.DeleteAzureMediaServiceAccountAsync(Name).Result; });

                              WriteObject(result.StatusCode == HttpStatusCode.NoContent);
                          });
        }
    }
}