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
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Models.Profile;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;

namespace Microsoft.Azure.Commands.Cdn.Profile
{
    [Cmdlet(VerbsCommon.Get, "AzureRmCdnProfileSsoUrl", DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSSsoUri))]
    public class GetAzureRmCdnProfileSsoUrl : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the profile.")]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The resource group to which the profile belongs.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The Azure CDN profile object.")]
        [ValidateNotNullOrEmpty]
        public PSProfile CdnProfile { get; set; }


        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = CdnProfile.ResourceGroupName;
                ProfileName = CdnProfile.Name;
            }

            var sso = CdnManagementClient.Profiles.GenerateSsoUri(ProfileName, ResourceGroupName);
            
            WriteVerbose(Resources.Success);
            WriteObject(new PSSsoUri {SsoUriValue = sso.SsoUriValue });
        }
    }
}
