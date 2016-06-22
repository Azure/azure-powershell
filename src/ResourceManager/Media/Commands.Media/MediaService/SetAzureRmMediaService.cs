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
using System.Management.Automation;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Media.Common;
using Microsoft.Azure.Commands.Media.Models;
using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Rest.Models;
using RestMediaService = Microsoft.Azure.Management.Media.Rest.Models.MediaService;

namespace Microsoft.Azure.Commands.Media.MediaService
{
    /// <summary>
    /// Update a media service.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, MediaServiceNounStr), OutputType(typeof(PSMediaService))]
    public class SetAzureRmMediaService : AzureMediaServiceCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The media service account name.")]
        [ValidateNotNullOrEmpty]
        [ValidateLength(MediaServiceAccountNameMinLength, MediaServiceAccountNameMaxLength)]
        [ValidatePattern(MediaServiceAccountNamePattern, Options = RegexOptions.None)]
        public string MediaServiceAccountName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The tags associated with the media account.")]
        [ValidateNotNull]
        public Hashtable Tags { get; set; }

        public override void ExecuteCmdlet()
        {
            SetApiVersion();

            var mediaServiceParams = new RestMediaService
            {
                Tags = Tags.ToDictionaryTags()
            };

            try
            {
                var mediaService = AzureMediaServicesClient.PatchMediaservices(SubscriptionId, ResourceGroupName,
                    MediaServiceAccountName, mediaServiceParams, ApiVersion);
                WriteObject(mediaService, true);
            }
            catch (ApiErrorException exception)
            {
                if (exception.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    throw new ArgumentException(string.Format(
                        "MediaServiceAccount {0} under subscprition {1} and resourceGroup {2} doesn't exist",
                        MediaServiceAccountName,
                        SubscrptionName,
                        ResourceGroupName));
                }
            }
        }
    }
}
