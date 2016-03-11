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
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Models.Profile;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;

namespace Microsoft.Azure.Commands.Cdn.Profile
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmCdnProfile", ConfirmImpact = ConfirmImpact.High, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRmCdnProfile : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the profile.")]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The resource group to which the profile belongs.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The profile.")]
        [ValidateNotNullOrEmpty]
        public PSProfile CdnProfile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Return object if specified.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = CdnProfile.ResourceGroupName;
                ProfileName = CdnProfile.Name;
            }

            try
            {
                CdnManagementClient.Profiles.GetWithHttpMessagesAsync(ProfileName, ResourceGroupName).Wait();
            }
            catch (AggregateException exception)
            {
                var errorResponseException = exception.InnerException as ErrorResponseException;
                if (errorResponseException == null)
                {
                    throw;
                }

                if (errorResponseException.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    throw new PSArgumentException(string.Format(
                        Resources.Error_DeleteNonExistingProfile, 
                        ProfileName,
                        ResourceGroupName));
                }
            }

            if (!ShouldProcess(string.Format(Resources.Confirm_RemoveProfile, ProfileName)))
            {
                return;
            }

            CdnManagementClient.Profiles.DeleteIfExists(ProfileName, ResourceGroupName);

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
