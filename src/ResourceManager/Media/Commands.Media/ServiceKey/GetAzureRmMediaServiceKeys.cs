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
using Microsoft.Azure.Commands.Media.Models;
using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;

namespace Microsoft.Azure.Commands.Media.ServiceKey
{
    /// <summary>
    /// List key information for accessing the REST endpoint associated with the media service.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, MediaServiceKeysNounStr), OutputType(typeof(PSServiceKeys))]
    public class GetAzureRmMediaServiceKeys : AzureMediaServiceCmdletBase
    {
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

        public override void ExecuteCmdlet()
        {
            try
            {
                var serviceKeys = MediaServicesManagementClient.MediaService.ListKeys(ResourceGroupName, AccountName);
                WriteObject(serviceKeys.ToPSServiceKeys(), true);
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
