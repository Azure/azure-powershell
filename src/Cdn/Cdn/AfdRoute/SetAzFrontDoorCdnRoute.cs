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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnRoute", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSAfdRoute))]
    public class SetAzFrontDoorCdnRoute : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdCustomDomainIds, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public List<string> CustomDomainId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRouteHttpsRedirect, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string HttpsRedirect { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdEndpointName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRouteForwardingProtocol, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ForwardingProtocol { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginGroupId, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OriginGroupId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRouteQueryStringCachingBehavior, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string QueryStringCachingBehavior { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRouteOriginPath, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OriginPath { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = HelpMessageConstants.AfdRouteObject, ParameterSetName = ObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAfdRoute Route { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRouteName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string RouteName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleSetIds, ParameterSetName = FieldsParameterSet)]
        public List<string> RuleSetId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRouteSupportedProtocols, ParameterSetName = FieldsParameterSet)]
        public List<string> SupportedProtocol { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(AfdResourceProcessMessage.AfdRouteUpdateMessage, this.RouteName, this.UpdateAfdRoute);
        }

        private void UpdateAfdRoute()
        {
            try
            {
                PSAfdRoute currentPsAfdRoute = this.CdnManagementClient.Routes.Get(this.ResourceGroupName, this.ProfileName, this.EndpointName, this.RouteName).ToPSAfdRoute();

                RouteUpdateParameters afdRouteUpdateParameters = new RouteUpdateParameters();

                if (ParameterSetName == FieldsParameterSet)
                {
                    afdRouteUpdateParameters = this.CreateAfdRouteUpdateByFields(currentPsAfdRoute);
                }

                PSAfdRoute updatedPsAfdRoute = this.CdnManagementClient.Routes.Update(this.ResourceGroupName, this.ProfileName, this.EndpointName, this.RouteName, afdRouteUpdateParameters).ToPSAfdRoute();

                WriteObject(updatedPsAfdRoute);
            }
            catch (AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
        }

        private RouteUpdateParameters CreateAfdRouteUpdateByFields(PSAfdRoute currentPsAfdRoute)
        {
            bool isCustomDomainId = this.MyInvocation.BoundParameters.ContainsKey("CustomDomainId");
            bool isSupportedProtocols = this.MyInvocation.BoundParameters.ContainsKey("SupportedProtocol");
            bool isHttpsRedirect = this.MyInvocation.BoundParameters.ContainsKey("HttpsRedirect");
            bool isOriginGroupId = this.MyInvocation.BoundParameters.ContainsKey("OriginGroupId");
            bool isOriginPath = this.MyInvocation.BoundParameters.ContainsKey("OriginPath");
            bool isForwardingProtocol = this.MyInvocation.BoundParameters.ContainsKey("ForwardingProtocol");
            bool isQueryStringCachingBehavior = this.MyInvocation.BoundParameters.ContainsKey("QueryStringCachingBehavior");
            bool isRuleSetIds = this.MyInvocation.BoundParameters.ContainsKey("RuleSetId");

            RouteUpdateParameters afdRouteUpdateParameters = new RouteUpdateParameters
            {
                CustomDomains = currentPsAfdRoute.CustomDomainIds,
                SupportedProtocols = currentPsAfdRoute.SupportedProtocols,
                HttpsRedirect = currentPsAfdRoute.HttpsRedirect,
                OriginGroup = new ResourceReference(currentPsAfdRoute.OriginGroupId),
                OriginPath = currentPsAfdRoute.OriginPath,
                ForwardingProtocol = currentPsAfdRoute.ForwardingProtocol,
                RuleSets = currentPsAfdRoute.RuleSetIds,
                QueryStringCachingBehavior = AfdUtilities.CreateQueryStringCachingBehavior(currentPsAfdRoute.QueryStringCachingBehavior)
            };

            if (isCustomDomainId)
            {
                foreach (string customDomainId in this.CustomDomainId)
                {
                    afdRouteUpdateParameters.CustomDomains.Add(new ResourceReference(customDomainId));
                }
            }

            if (isSupportedProtocols)
            {
                afdRouteUpdateParameters.SupportedProtocols = this.SupportedProtocol;
            }

            if (isHttpsRedirect)
            {
                afdRouteUpdateParameters.HttpsRedirect = AfdUtilities.CreateHttpsRedirect(this.HttpsRedirect);
            }

            if (isOriginGroupId)
            {
                afdRouteUpdateParameters.OriginGroup = new ResourceReference(this.OriginGroupId);
            }

            if (isOriginPath)
            {
                afdRouteUpdateParameters.OriginPath = this.OriginPath;
            }

            if (isForwardingProtocol)
            {
                afdRouteUpdateParameters.ForwardingProtocol = AfdUtilities.CreateForwardingProtocol(this.ForwardingProtocol);
            }

            if (isQueryStringCachingBehavior)
            {
                afdRouteUpdateParameters.QueryStringCachingBehavior = AfdUtilities.CreateQueryStringCachingBehavior(this.QueryStringCachingBehavior);
            }

            if (isRuleSetIds)
            {
                foreach (string ruleSetId in this.RuleSetId)
                {
                    afdRouteUpdateParameters.RuleSets.Add(new ResourceReference(ruleSetId));
                }
            }

            return afdRouteUpdateParameters;
        }
    }
}
