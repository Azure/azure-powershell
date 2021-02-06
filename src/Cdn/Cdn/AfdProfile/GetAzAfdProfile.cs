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

using Microsoft.Azure.Commands.Cdn.AfdModels.AfdProfile;
using Microsoft.Azure.Commands.Cdn.AfdHelpers;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Cdn;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdProfile
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AfdProfile"), OutputType(typeof(PSAfdProfile))]
    public class GetAzAfdProfile : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.ResourceGroupName)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdProfileName)]
        public string AfdProfileName { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (this.ResourceGroupName == null && this.AfdProfileName == null)
                {
                    // not all profiles are delivered by the payload
                    // limitation somewhere in the RP?
                    List<PSAfdProfile> afdProfilesList = CdnManagementClient.Profiles.List()
                                                         .Select(afdProfile => afdProfile.ToPSAfdProfile())
                                                         .Where(afdProfile => (afdProfile.Sku == AfdSku.StandardAzureFrontDoor || afdProfile.Sku == AfdSku.PremiumAzureFrontDoor))
                                                         .ToList();

                    WriteObject(afdProfilesList);
                }
                else if (AfdUtilities.IsValuePresent(this.ResourceGroupName) && this.AfdProfileName == null)
                {
                    // works
                    List<PSAfdProfile> afdProfilesList = CdnManagementClient.Profiles.ListByResourceGroup(ResourceGroupName)
                                                         .Select(afdProfile => afdProfile.ToPSAfdProfile())
                                                         .Where(afdProfile => (afdProfile.Sku == AfdSku.StandardAzureFrontDoor || afdProfile.Sku == AfdSku.PremiumAzureFrontDoor))
                                                         .ToList();

                    WriteObject(afdProfilesList);
                }
                else if (this.ResourceGroupName == null && AfdUtilities.IsValuePresent(this.AfdProfileName))
                {
                    // not all profiles are delivered by the payload
                    // limitation somewhere in the RP?
                    List<PSAfdProfile> afdProfileList = CdnManagementClient.Profiles.List()
                                                        .Select(afdProfile => afdProfile.ToPSAfdProfile())
                                                        .Where(afdProfile => (afdProfile.Sku == AfdSku.StandardAzureFrontDoor || afdProfile.Sku == AfdSku.PremiumAzureFrontDoor))
                                                        .ToList();

                    WriteObject(afdProfileList);
                }
                else
                {
                    // works
                    Microsoft.Azure.Management.Cdn.Models.Profile afdProfile = CdnManagementClient.Profiles.Get(ResourceGroupName, AfdProfileName);
                    WriteObject(afdProfile.ToPSAfdProfile());
                }
            } catch (Microsoft.Azure.Management.Cdn.Models.AfdErrorResponseException errorResponseException)
            {
                throw new PSArgumentException(errorResponseException.Response.Content);
            }
        }
    }
}
