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
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Commands.WebApps.Validations;
using Microsoft.Azure.Management.WebSites.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.TrafficRouting
{
    /// <summary>
    /// this commandlet will let you Add new Azure App Service Traffic Routing using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzurePrefix + "WebAppTrafficRouting", DefaultParameterSetName = RoutingParameterSet, SupportsShouldProcess = true), OutputType(typeof(RampUpRule))]
    public class AddAzureWebAppTrafficRoutingRuleCmdlet : WebAppBaseClientCmdLet
    {
        private const string RoutingParameterSet = "RoutingParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = RoutingParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RoutingParameterSet)]
        [ValidateNotNullOrEmpty]
        public string WebAppName { get; set; }

        [Parameter(ParameterSetName = RoutingParameterSet, Mandatory = true,
        HelpMessage = "Web App RoutingRule. Example: -RoutingRule @{ActionHostName=$slot.DefaultHostName ; ReroutePercentage=$ReroutePercentage ; Name=$slotName}")]
        [ValidateNotNullOrEmpty]
        [ValidateStringDictionary]
        public Hashtable RoutingRule { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(ResourceGroupName) && !string.IsNullOrWhiteSpace(WebAppName))
            {
                var webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, null));
                SiteConfig siteConfig = webApp.SiteConfig;
                if (RoutingRule != null)
                {
                    var routingRule = CmdletHelpers.ConvertToStringDictionary(RoutingRule);
                    RampUpRule rampUpRule = new RampUpRule();
                    foreach (var item in routingRule)
                    {
                        CmdletHelpers.SetObjectProperty(rampUpRule, item.Key, item.Value);
                    }
                    //Check for Rule existance with the given name.
                    var givenRampUpRuleObj = siteConfig.Experiments.RampUpRules.FirstOrDefault(item => item.Name == rampUpRule.Name);
                    if (givenRampUpRuleObj == null)
                    {
                        if (this.ShouldProcess(this.WebAppName, string.Format("Creating a new Routing Rule for slot '{0}' in Web Application - {1}.", rampUpRule.Name, this.WebAppName)))
                        {
                            //Add the given rule to the existing config
                            siteConfig.Experiments.RampUpRules.Add(rampUpRule);
                            // Update web app configuration
                            WebsitesClient.UpdateWebAppConfiguration(ResourceGroupName, webApp.Location, WebAppName, null, siteConfig, null, null, null);
                            //var app = WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, null);
                            //WriteObject(app.SiteConfig.Experiments.RampUpRules.FirstOrDefault(rule => rule.Name == rampUpRule.Name));
                            WriteObject(rampUpRule);
                        }
                    }
                    else
                    {
                        throw new ValidationMetadataException(string.Format(Properties.Resources.AddRoutingRuleErrorMessage, rampUpRule.Name, WebAppName));
                    }

                }
            }
        }
    }
}
