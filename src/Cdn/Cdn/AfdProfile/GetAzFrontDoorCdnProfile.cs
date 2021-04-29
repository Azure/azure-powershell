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

using Microsoft.Azure.Commands.Cdn.AfdModels;
using Microsoft.Azure.Commands.Cdn.AfdHelpers;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdProfile
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnProfile", DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSAfdProfile))]
    public class GetAzFrontDoorCdnProfile : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceId, ParameterSetName = ResourceIdParameterSet)]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case FieldsParameterSet:
                        this.FieldsParameterSetCmdlet();
                        break;
                    case ResourceIdParameterSet:
                        this.ResourceIdParameterSetCmdlet();
                        break;
                }
            } 
            catch (Microsoft.Azure.Management.Cdn.Models.AfdErrorResponseException errorResponseException)
            {
                throw new PSArgumentException(errorResponseException.Response.Content);
            }
        }

        private void FieldsParameterSetCmdlet()
        {
            if (AfdUtilities.IsValuePresent(this.ResourceGroupName) && AfdUtilities.IsValuePresent(this.ProfileName))
            {
                PSAfdProfile psAfdProfile = CdnManagementClient.Profiles.Get(this.ResourceGroupName, this.ProfileName).ToPSAfdProfile();
                WriteObject(psAfdProfile);
            }
            else if (AfdUtilities.IsValuePresent(this.ResourceGroupName) && this.ProfileName == null)
            {
                List<PSAfdProfile> psAfdProfiles = CdnManagementClient.Profiles.ListByResourceGroup(this.ResourceGroupName)
                                                   .Where(afdProfile => (afdProfile.Sku.Name == AfdSkuConstants.PremiumAzureFrontDoor || afdProfile.Sku.Name == AfdSkuConstants.StandardAzureFrontDoor))
                                                   .Select(afdProfile => afdProfile.ToPSAfdProfile())
                                                   .ToList();
                WriteObject(psAfdProfiles);
            }
            else if (this.ResourceGroupName == null && AfdUtilities.IsValuePresent(this.ProfileName))
            {
                // not all profiles are delivered by the payload, limitation somewhere in the RP?

                List<PSAfdProfile> psAfdProfiles = CdnManagementClient.Profiles.List()
                                            .Where(afdProfile => afdProfile.Name == this.ProfileName)
                                            .Select(afdProfile => afdProfile.ToPSAfdProfile())
                                            .ToList();

                PSAfdProfile psAfdProfile = psAfdProfiles.Count > 0 ? psAfdProfiles.First() : null;
                 
                WriteObject(psAfdProfile);
            }
            else
            {
                // both resource group and profile name are null
                // show all profiles in the subscription
                // not all profiles are delivered by the payload, limitation somewhere in the RP?
               
                List<PSAfdProfile> psAfdProfiles = CdnManagementClient.Profiles.List()
                                                   .Where(afdProfile => (afdProfile.Sku.Name == AfdSkuConstants.PremiumAzureFrontDoor || afdProfile.Sku.Name == AfdSkuConstants.StandardAzureFrontDoor))
                                                   .Select(afdProfile => afdProfile.ToPSAfdProfile())
                                                   .ToList();

                WriteObject(psAfdProfiles);
            }
        }

        private void ResourceIdParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdProfileResourceId = new ResourceIdentifier(this.ResourceId);

            this.ProfileName = parsedAfdProfileResourceId.ResourceName;
            this.ResourceGroupName = parsedAfdProfileResourceId.ResourceGroupName;

            PSAfdProfile psAfdProfile = CdnManagementClient.Profiles.Get(this.ResourceGroupName, this.ProfileName).ToPSAfdProfile();

            WriteObject(psAfdProfile);
        }
    }
}
