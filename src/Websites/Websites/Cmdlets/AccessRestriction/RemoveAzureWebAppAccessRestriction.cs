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


using Microsoft.Azure.Commands.WebApps.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you get a new Azure Websites using ARM APIs
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppAccessRestriction", SupportsShouldProcess = true)]
    [OutputType(typeof(PSAccessRestrictionSettings))]
    public class RemoveAzureWebAppAccessRestrictionCmdlet : WebAppBaseClientCmdLet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.", ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Web/sites", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Access Restriction rule name. E.g.: DeveloperWorkstation.")]        
        [ValidateNotNullOrEmpty]
        public string RuleName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Rule is aimed for Main site or Scm site.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter TargetScmSite { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Deployment Slot name.")]
        public string SlotName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(ResourceGroupName) && !string.IsNullOrWhiteSpace(Name))
            {
                if (ShouldProcess(Name, $"Removing Access Restriction Rule '{RuleName}' from Web App '{Name}'"))
                {
                    var webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, Name, SlotName));
                    SiteConfig siteConfig = webApp.SiteConfig;
                    var accessRestrictionList = TargetScmSite ? siteConfig.ScmIpSecurityRestrictions : siteConfig.IpSecurityRestrictions;
                    IpSecurityRestriction ipSecurityRestriction = null;
                    bool accessRestrictionExists = false;

                    foreach (var accessRestriction in accessRestrictionList)
                    {
                        if (accessRestriction.Name.ToLowerInvariant() == RuleName.ToLowerInvariant())
                        {
                            ipSecurityRestriction = accessRestriction;
                            accessRestrictionExists = true;
                            break;
                        }
                    }
                    if (accessRestrictionExists)
                    {
                        accessRestrictionList.Remove(ipSecurityRestriction);
                    }

                    // Update web app configuration
                    WebsitesClient.UpdateWebAppConfiguration(ResourceGroupName, webApp.Location, Name, SlotName, siteConfig);

                    // Refresh object to get the final state
                    webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, Name, SlotName));
                    var accessRestrictionSettings = new PSAccessRestrictionSettings(webApp.SiteConfig);
                    WriteObject(accessRestrictionSettings);
                }
            }
        }
    }
}
