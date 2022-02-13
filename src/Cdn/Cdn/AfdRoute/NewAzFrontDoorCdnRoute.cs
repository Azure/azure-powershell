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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdRoute
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnRoute", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSAfdRoute))]
    public class NewAzFrontDoorCdnRoute : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdCustomDomainIds, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public List<string> CustomDomainId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdEndpointName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdOriginGroupId, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OriginGroupId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRouteName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string RouteName { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(AfdResourceProcessMessage.AfdRouteCreateMessage, this.RouteName, this.CreateAfdRoute);
        }

        private void CreateAfdRoute()
        {
            try
            {
                List<ResourceReference> afdCustomDomainIdList = new List<ResourceReference>();

                foreach(string afdCustomDomain in this.CustomDomainId)
                {
                    afdCustomDomainIdList.Add(new ResourceReference(afdCustomDomain));
                }
                
                Route afdRoute = new Route
                {
                    OriginGroup = new ResourceReference(this.OriginGroupId),
                    CustomDomains = afdCustomDomainIdList
                };
                    
                PSAfdRoute psAfdRoute = this.CdnManagementClient.Routes.Create(this.ResourceGroupName, this.ProfileName, this.EndpointName, this.RouteName, afdRoute).ToPSAfdRoute();

                WriteObject(psAfdRoute);
            }
            catch (AfdErrorResponseException errorResponse)
            {
                 throw new PSArgumentException(errorResponse.Response.Content);
            }
        }
    }
}
