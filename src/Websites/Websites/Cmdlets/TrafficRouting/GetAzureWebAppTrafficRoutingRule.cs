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


using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Management.WebSites.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.TrafficRouting
{
    /// <summary>
    /// this commandlet will let you Get the given Azure App Service Traffic Routing using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzurePrefix + "WebAppTrafficRouting", DefaultParameterSetName = RoutingParameterSet, SupportsShouldProcess = true), OutputType(typeof(RampUpRule))]
    public class GetAzureWebAppTrafficRoutingRule : WebAppBaseClientCmdLet
    {
        private const string RoutingParameterSet = "RoutingParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = RoutingParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RoutingParameterSet)]
        [ValidateNotNullOrEmpty]
        public string WebAppName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RoutingParameterSet)]
        [ValidateNotNullOrEmpty]
        public string RuleName { get; set; }
        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(ResourceGroupName) && !string.IsNullOrWhiteSpace(WebAppName))
            {
                var webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, null));
                SiteConfig siteConfig = webApp.SiteConfig;

                //Check for Rule existance with the given name.
                var givenRampUpRuleObj = siteConfig.Experiments.RampUpRules.FirstOrDefault(item => item.Name == RuleName);
                if (givenRampUpRuleObj != null)
                {
                    WriteObject(givenRampUpRuleObj);
                }
                else
                {
                    throw new ValidationMetadataException(string.Format(Properties.Resources.UpdateAndGetRoutingRuleErrorMessage, RuleName, WebAppName));
                }
            }
        }
    }
}
