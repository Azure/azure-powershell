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
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.Profile;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;

namespace Microsoft.Azure.Commands.Cdn.Profile
{
    /// <summary>
    /// Defines the New-AzureRmCdnProfile cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmCdnProfile", SupportsShouldProcess = true), OutputType(typeof(PSProfile))]
    public class SetAzureRmCdnProfile : AzureCdnCmdletBase
    {
        /// <summary>
        /// Gets or sets the profile to update.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Azure CDN profile object.")]
        [ValidateNotNull]
        public PSProfile CdnProfile { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(MyInvocation.InvocationName,
                CdnProfile.Name,
                SetProfile);
        }

        private void SetProfile()
        {
            var profile = CdnManagementClient.Profiles.Update(
                CdnProfile.Name,
                CdnProfile.ResourceGroupName,
                CdnProfile.Tags.ToDictionaryTags());

            WriteVerbose(Resources.Success);
            WriteObject(profile.ToPsProfile());
        }
    }
}
