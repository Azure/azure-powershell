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

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you get a new Azure Websites using ARM APIs
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppAccessRestriction", SupportsShouldProcess = true)]
    [OutputType(typeof(PSAccessRestrictionSettings))]
    public class SetAzureWebAppAccessRestrictionCmdlet : WebAppBaseClientCmdLet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.", ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Web/sites", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Scm site inherits rules set on Main site.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ScmSiteUseMainSiteRestrictionSet { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Deployment Slot name.")]
        public string SlotName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (!string.IsNullOrWhiteSpace(ResourceGroupName) && !string.IsNullOrWhiteSpace(Name))
            {
                string updateAction = ScmSiteUseMainSiteRestrictionSet ? "" : "not ";
                if (ShouldProcess(Name, $"Update Scm Site of WebApp '{Name}' to {updateAction}use Main Site Access Restriction Set"))
                {
                    var webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, Name, SlotName));
                    SiteConfig siteConfig = webApp.SiteConfig;

                    if (siteConfig.ScmIpSecurityRestrictionsUseMain != ScmSiteUseMainSiteRestrictionSet)
                    {
                        siteConfig.ScmIpSecurityRestrictionsUseMain = ScmSiteUseMainSiteRestrictionSet;

                        // Update web app configuration
                        WebsitesClient.UpdateWebAppConfiguration(ResourceGroupName, webApp.Location, Name, SlotName, siteConfig);
                    }

                    var accessRestrictionSettings = new PSAccessRestrictionSettings(webApp.SiteConfig);
                    WriteObject(accessRestrictionSettings);
                }
            }
        }
    }
}
