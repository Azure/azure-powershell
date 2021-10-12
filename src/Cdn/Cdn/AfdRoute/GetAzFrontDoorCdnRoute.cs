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

namespace Microsoft.Azure.Commands.Cdn.AfdRoute
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnRoute", DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSAfdRoute))]
    public class GetAzFrontDoorCdnRoute : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = HelpMessageConstants.AfdEndpointObject, ParameterSetName = ObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAfdEndpoint Endpoint { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdEndpointName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRouteName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string RouteName { get; set; }

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
            if (this.MyInvocation.BoundParameters.ContainsKey("RouteName"))
            {
                PSAfdRoute psAfdRoute = this.CdnManagementClient.Routes.Get(this.ResourceGroupName, this.ProfileName, this.EndpointName, this.RouteName).ToPSAfdRoute();

                WriteObject(psAfdRoute);
            }
            else
            {
                List<PSAfdRoute> psAfdRouteList = this.CdnManagementClient.Routes.ListByEndpoint(this.ResourceGroupName, this.ProfileName, this.EndpointName)
                                              .Select(afdRoute => afdRoute.ToPSAfdRoute())
                                              .ToList();

                WriteObject(psAfdRouteList);
            }
        }

        private void ObjectParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdEndpointResourceId = new ResourceIdentifier(this.Endpoint.Id);

            this.EndpointName = parsedAfdEndpointResourceId.ResourceName;
            this.ProfileName = parsedAfdEndpointResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdEndpointResourceId.ResourceGroupName;

            List<PSAfdRoute> psAfdRouteList = this.CdnManagementClient.Routes.ListByEndpoint(this.ResourceGroupName, this.ProfileName, this.EndpointName)
                                              .Select(afdRoute => afdRoute.ToPSAfdRoute())
                                              .ToList();

            WriteObject(psAfdRouteList);
        }

        private void ResourceIdParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdRouteResourceId = new ResourceIdentifier(this.ResourceId);

            this.RouteName = parsedAfdRouteResourceId.ResourceName;
            this.EndpointName = parsedAfdRouteResourceId.GetResourceName("afdendpoints");
            this.ProfileName = parsedAfdRouteResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdRouteResourceId.ResourceGroupName;

            PSAfdRoute psAfdRoute = this.CdnManagementClient.Routes.Get(this.ResourceGroupName, this.ProfileName, this.EndpointName, this.RouteName).ToPSAfdRoute();

            WriteObject(psAfdRoute);
        }
    }
}
