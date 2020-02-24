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
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzurePrefix + "WebAppTrafficRouting", DefaultParameterSetName = AddRoutingParameterSet, SupportsShouldProcess = true), OutputType(typeof(RampUpRule))]
    public class AddAzureWebAppTrafficRoutingRuleCmdlet : WebAppBaseClientCmdLet
    {
        private const string AddRoutingParameterSet = "AddRoutingParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = AddRoutingParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AddRoutingParameterSet)]
        [ValidateNotNullOrEmpty]
        public string WebAppName { get; set; }

        [Parameter(ParameterSetName = AddRoutingParameterSet, Mandatory = true,
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
                        CmdletHelpers.SetGenericObjectProperty(rampUpRule, item.Key, item.Value);
                    }
                    //Check for Rule existance with the given name.
                    var existingRampUpRules = siteConfig.Experiments.RampUpRules.FirstOrDefault(item => item.Name == rampUpRule.Name);
                    if (existingRampUpRules == null)
                    {
                        siteConfig.Experiments.RampUpRules.Add(rampUpRule);
                        // Update web app configuration
                        WebsitesClient.UpdateWebAppConfiguration(ResourceGroupName, webApp.Location, WebAppName, null, siteConfig, null, null, null);
                        var app = WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, null);
                        WriteObject(app.SiteConfig.Experiments.RampUpRules.FirstOrDefault(rule => rule.Name == rampUpRule.Name));
                    }
                    else
                    {
                        throw new ValidationMetadataException(string.Format("A Routing Rule with name '{0}' in WebApp '{1}' already exists." +
                            "Please use Update-AzWebAppTrafficRouting to update an existing Routing Rule.", "", ""));
                    }

                }
            }
        }
    }
}
