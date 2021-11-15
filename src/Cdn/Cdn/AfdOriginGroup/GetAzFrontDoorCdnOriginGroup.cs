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
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdOriginGroup
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnOriginGroup", DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSAfdOriginGroup))]
    public class GetAzFrontDoorCdnOriginGroup : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginGroupName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OriginGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = HelpMessageConstants.AfdProfileObject, ParameterSetName = ObjectParameterSet)]
        public PSAfdProfile Profile { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceId, ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case FieldsParameterSet:
                        this.FieldsParameterSetCmdlet();
                        break;
                    case ObjectParameterSet:
                        this.ObjectParameterSetCmdlet();
                        break;
                    case ResourceIdParameterSet:
                        this.ResourceIdParameterSetCmdlet();
                        break;
                }
            }
            catch (AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
        }

        private void FieldsParameterSetCmdlet()
        {
            if (AfdUtilities.IsValuePresent(this.OriginGroupName))
            {
                // all fields are present (mandatory + optional)

                PSAfdOriginGroup psAfdOriginGroup = this.CdnManagementClient.AFDOriginGroups.Get(this.ResourceGroupName, this.ProfileName, this.OriginGroupName).ToPSAfdOriginGroup();

                WriteObject(psAfdOriginGroup);
            }
            else
            {
                // only the mandatory fields are present 

                List<PSAfdOriginGroup> pSAfdOriginGroups = this.CdnManagementClient.AFDOriginGroups.ListByProfile(this.ResourceGroupName, this.ProfileName)
                                                           .Select(afdOriginGroup => afdOriginGroup.ToPSAfdOriginGroup())
                                                           .ToList();

                WriteObject(pSAfdOriginGroups);
            }
        }

        private void ObjectParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdProfileResourceId = new ResourceIdentifier(this.Profile.Id);

            this.ProfileName = parsedAfdProfileResourceId.ResourceName;
            this.ResourceGroupName = parsedAfdProfileResourceId.ResourceGroupName;

            List<PSAfdOriginGroup> psAfdOriginGroups = this.CdnManagementClient.AFDOriginGroups.ListByProfile(this.ResourceGroupName, this.ProfileName)
                                                       .Select(afdOriginGroup => afdOriginGroup.ToPSAfdOriginGroup())
                                                       .ToList();

            WriteObject(psAfdOriginGroups);
        }

        private void ResourceIdParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdOriginGroupResourceId = new ResourceIdentifier(this.ResourceId);

            this.OriginGroupName = parsedAfdOriginGroupResourceId.ResourceName;
            this.ProfileName = parsedAfdOriginGroupResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdOriginGroupResourceId.ResourceGroupName;

            PSAfdOriginGroup psAfdOriginGroup = this.CdnManagementClient.AFDOriginGroups.Get(this.ResourceGroupName, this.ProfileName, this.OriginGroupName).ToPSAfdOriginGroup();

            WriteObject(psAfdOriginGroup);
        }
    }
}
