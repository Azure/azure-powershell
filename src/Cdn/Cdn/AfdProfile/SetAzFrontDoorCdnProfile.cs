// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Cdn.AfdHelpers;
using Microsoft.Azure.Commands.Cdn.AfdModels;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdProfile
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnProfile", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSAfdProfile))]

    public class SetAzFrontDoorCdnProfile : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = HelpMessageConstants.AfdProfileObject, ParameterSetName = ObjectParameterSet)]
        [ValidateNotNull]
        public PSAfdProfile Profile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.TagsDescription, ParameterSetName = FieldsParameterSet)]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            // when using FieldsParameterSet, this.ProfileName and this.ResourceGroupName are provided
            // Hence no need for a FieldsParamterSet case
            switch (ParameterSetName)
            {
                case ObjectParameterSet:
                    ObjectParameterSetCmdlet();
                    break;
            }

            ConfirmAction(AfdResourceProcessMessage.AfdProfileUpdateMessage, this.ProfileName, this.UpdateAfdProfile);
        }

        private void UpdateAfdProfile()
        {
            PSAfdProfile profile = CdnManagementClient.Profiles.Get(this.ResourceGroupName, this.ProfileName).ToPSAfdProfile();

            if (!AfdUtilities.IsAfdProfile(profile))
            {
                throw new PSArgumentException($"You are attempting to update a {profile.Sku} profile. Please use Set-AzCdnProfile instead.");
            }

            Dictionary<string, string> afdProfileTags = TagsConversionHelper.CreateTagDictionary(this.Tag, true);

            PSAfdProfile psAfdProfile = this.CdnManagementClient.Profiles.Update(this.ResourceGroupName, this.ProfileName, afdProfileTags).ToPSAfdProfile();

            WriteObject(psAfdProfile);
        }

        private void ObjectParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdProfileResourceId = new ResourceIdentifier(this.Profile.Id);

            this.ProfileName = parsedAfdProfileResourceId.ResourceName;
            this.ResourceGroupName = parsedAfdProfileResourceId.ResourceGroupName;
            this.Tag = this.Profile.Tags;
        }
    }
}
