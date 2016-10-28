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
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Media.Common;
using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;

namespace Microsoft.Azure.Commands.Media.MediaService
{
    /// <summary>
    /// Remove a media service.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, MediaServiceNounStr, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRmMediaService : AzureMediaServiceCmdletBase
    {
        private const string RemoveMediaServiceWarning = "Are you sure you want to remove MediaService {0} ?";
        private const string RemoveMediaServiceWhatIfMessage = "Remove MediaService";

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

        [Parameter(Mandatory = false,
           HelpMessage = "Force to remove media service without confirm.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(AccountName, RemoveMediaServiceWhatIfMessage))
            {
                if (Force || ShouldContinue(string.Format(RemoveMediaServiceWarning, AccountName), ""))
                {
                    try
                    {
                        MediaServicesManagementClient.MediaService.Delete(ResourceGroupName, AccountName);
                        WriteObject(true);
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
}
