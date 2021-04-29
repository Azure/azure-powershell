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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdEndpoint
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnEndpoint", DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSAfdEndpoint))]
    public class GetAzFrontDoorCdnEndpoint : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdEndpointName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = HelpMessageConstants.AfdProfileObject, ParameterSetName = ObjectParameterSet)]
        [ValidateNotNull]
        public PSAfdProfile Profile { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName {get; set;}

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
            catch (Microsoft.Azure.Management.Cdn.Models.AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
        }

        private void FieldsParameterSetCmdlet()
        {
            if (AfdUtilities.IsValuePresent(this.EndpointName))
            {
                // all fields are present (mandatory + optional)

                PSAfdEndpoint psAfdEndpoint = CdnManagementClient.AFDEndpoints.Get(this.ResourceGroupName, this.ProfileName, this.EndpointName).ToPSAfdEndpoint();

                WriteObject(psAfdEndpoint);
            } 
            else
            {
                // only the mandatory fields are present 

                List<PSAfdEndpoint> psAfdEndpoints = CdnManagementClient.AFDEndpoints.ListByProfile(this.ResourceGroupName, this.ProfileName)
                                                   .Select(afdEndpoint => afdEndpoint.ToPSAfdEndpoint())
                                                   .ToList();

                WriteObject(psAfdEndpoints);
            }
        }

        private void ObjectParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdProfileResourceId = new ResourceIdentifier(this.Profile.Id);

            this.ProfileName = parsedAfdProfileResourceId.ResourceName;
            this.ResourceGroupName = parsedAfdProfileResourceId.ResourceGroupName;

            List<PSAfdEndpoint> psAfdEndpoints = CdnManagementClient.AFDEndpoints.ListByProfile(this.ResourceGroupName, this.ProfileName)
                                               .Select(afdEndpoint => afdEndpoint.ToPSAfdEndpoint())
                                               .ToList();

            WriteObject(psAfdEndpoints);
        }

        private void ResourceIdParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdEndpointResourceId = new ResourceIdentifier(this.ResourceId);

            this.EndpointName = parsedAfdEndpointResourceId.ResourceName;
            this.ProfileName = parsedAfdEndpointResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdEndpointResourceId.ResourceGroupName;

            PSAfdEndpoint psAfdEndpoint = CdnManagementClient.AFDEndpoints.Get(this.ResourceGroupName, this.ProfileName, this.EndpointName).ToPSAfdEndpoint();

            WriteObject(psAfdEndpoint);
        }
    }
}
