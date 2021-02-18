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
    /// this commandlet will let you Remove the given Azure App Service Traffic Routing using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzurePrefix + "WebAppTrafficRouting", DefaultParameterSetName = RoutingParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureWebAppTrafficRoutingRuleCmdlet : WebAppBaseClientCmdLet
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

        [Parameter(Mandatory = false, HelpMessage = "Return the Routing Rule object.")]
        public SwitchParameter PassThru { get; set; }

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
                    if (this.ShouldProcess(this.RuleName, string.Format("Deleting Routing Rule for slot - '{0}' from Web Application - {1}", this.RuleName, this.WebAppName)))
                    {
                        //Remove the rule
                        siteConfig.Experiments.RampUpRules.Remove(givenRampUpRuleObj);
                        // Update web app configuration
                        WebsitesClient.UpdateWebAppConfiguration(ResourceGroupName, webApp.Location, WebAppName, null, siteConfig, null, null, null);
                        if (PassThru.IsPresent)
                        {                            
                            WriteObject(true);
                        }
                    }
                }
                else
                {
                    throw new ValidationMetadataException(string.Format(Properties.Resources.UpdateAndGetRoutingRuleErrorMessage, RuleName, WebAppName));
                }
            }
        }
    }
}
