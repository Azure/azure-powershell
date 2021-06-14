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

namespace Microsoft.Azure.Commands.Cdn.AfdOrigin
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnOrigin", DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSAfdOrigin))]
    public  class GetAzFrontDoorCdnOrigin : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = HelpMessageConstants.AfdOriginGroupObject, ParameterSetName = ObjectParameterSet)]
        public PSAfdOriginGroup OriginGroup { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdOriginGroupName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OriginGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OriginName { get; set; }

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

        public void FieldsParameterSetCmdlet()
        {
            if(AfdUtilities.IsValuePresent(this.OriginName))
            {
                // all fields are present (mandatory + optional)

                PSAfdOrigin psAfdOrigin = this.CdnManagementClient.AFDOrigins.Get(this.ResourceGroupName, this.ProfileName, this.OriginGroupName, this.OriginName).ToPSAfdOrigin();

                // add origin group name from the parameter input since its not provided by the SDK
                psAfdOrigin.OriginGroupName = this.OriginGroupName;

                WriteObject(psAfdOrigin);
            }
            else
            {
                // only the mandatory fields are present 

                List<PSAfdOrigin> psAfdOrigins = this.CdnManagementClient.AFDOrigins.ListByOriginGroup(this.ResourceGroupName, this.ProfileName, this.OriginGroupName)
                                                 .Select(afdOrigin => afdOrigin.ToPSAfdOrigin())
                                                 .ToList();

                // add the origin group name for each of the origins
                foreach (PSAfdOrigin psAfdOrigin in psAfdOrigins)
                {
                    psAfdOrigin.OriginGroupName = this.OriginGroupName;
                }

                // sdk will not give an error if the origin group is invalid / does not exist
                if (psAfdOrigins.Count == 0)
                {
                    WriteObject($"No origins were found in the origin group {this.OriginGroupName}. Please ensure the origin group name is correct and has origins.");
                }

                WriteObject(psAfdOrigins);
            }
        }

        private void ObjectParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdOriginGroupResourceId = new ResourceIdentifier(this.OriginGroup.Id);

            this.OriginGroupName = parsedAfdOriginGroupResourceId.ResourceName;
            this.ProfileName = parsedAfdOriginGroupResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdOriginGroupResourceId.ResourceGroupName;

            List<PSAfdOrigin> psAfdOrigins = CdnManagementClient.AFDOrigins.ListByOriginGroup(this.ResourceGroupName, this.ProfileName, this.OriginGroupName)
                                             .Select(afdOrigin => afdOrigin.ToPSAfdOrigin())
                                             .ToList();

            // add the origin group name for each of the origins
            foreach (PSAfdOrigin psAfdOrigin in psAfdOrigins)
            {
                psAfdOrigin.OriginGroupName = this.OriginGroupName;
            }

            WriteObject(psAfdOrigins);
        }

        private void ResourceIdParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdOriginId = new ResourceIdentifier(this.ResourceId);

            this.OriginName = parsedAfdOriginId.ResourceName;
            this.OriginGroupName = parsedAfdOriginId.GetResourceName("origingroups");
            this.ProfileName = parsedAfdOriginId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdOriginId.ResourceGroupName;

            PSAfdOrigin psAfdOrigin = CdnManagementClient.AFDOrigins.Get(this.ResourceGroupName, this.ProfileName, this.OriginGroupName, this.OriginName).ToPSAfdOrigin();

            // add origin group name from the parameter input since its not provided by the SDK
            psAfdOrigin.OriginGroupName = this.OriginGroupName;

            WriteObject(psAfdOrigin);                         
        }
    }
}
