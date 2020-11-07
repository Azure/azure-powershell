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
using Microsoft.Azure.Commands.WebApps.Utilities;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you get a new Azure Websites using ARM APIs
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppAccessRestrictionRule", SupportsShouldProcess = true)]
    [OutputType(typeof(PSAccessRestrictionConfig))]
    public class RemoveAzureWebAppAccessRestrictionRuleCmdlet : WebAppBaseClientCmdLet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.", ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Web/sites", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string WebAppName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Access Restriction rule name. E.g.: DeveloperWorkstation.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Allow or Deny rule.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Allow", "Deny")]
        public string Action { get; set; } = "Allow";

        [Parameter(Mandatory = false, HelpMessage = "Rule is aimed for Main site or Scm site.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter TargetScmSite { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Deployment Slot name.")]
        public string SlotName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Ip Address v4 or v6 CIDR range. E.g.: 192.168.0.0/24")]
        [ValidateNotNullOrEmpty]
        public string IpAddress { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of Subnet.")]
        [ValidateNotNullOrEmpty]
        public string SubnetName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of Virtual Network (must be in same resource group as Web App).")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "ResourceId of Subnet.")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return the access restriction config object.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(ResourceGroupName) && !string.IsNullOrWhiteSpace(WebAppName))
            {
                if (ShouldProcess(WebAppName, $"Removing Access Restriction Rule from Web App '{WebAppName}'"))
                {
                    var webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, SlotName));
                    SiteConfig siteConfig = webApp.SiteConfig;
                    var accessRestrictionList = TargetScmSite ? siteConfig.ScmIpSecurityRestrictions : siteConfig.IpSecurityRestrictions;
                    IpSecurityRestriction ipSecurityRestriction = null;
                    bool accessRestrictionExists = false;

                    foreach (var accessRestriction in accessRestrictionList)
                    {
                        if (!string.IsNullOrWhiteSpace(Name))
                        {
                            if (!string.IsNullOrWhiteSpace(accessRestriction.Name) &&  accessRestriction.Name.ToLowerInvariant() == Name.ToLowerInvariant() && accessRestriction.Action.ToLowerInvariant() == Action.ToLowerInvariant())
                            {
                                ipSecurityRestriction = accessRestriction;
                                accessRestrictionExists = true;
                                break;
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(IpAddress))
                        {
                            if (!string.IsNullOrWhiteSpace(accessRestriction.IpAddress) && accessRestriction.IpAddress.ToLowerInvariant() == IpAddress.ToLowerInvariant() && accessRestriction.Action.ToLowerInvariant() == Action.ToLowerInvariant())
                            {
                                if (!string.IsNullOrWhiteSpace(Name))                                
                                    if (!string.IsNullOrWhiteSpace(accessRestriction.Name) && accessRestriction.Name.ToLowerInvariant() == Name.ToLowerInvariant() && accessRestriction.Action.ToLowerInvariant() == Action.ToLowerInvariant())                                    
                                        continue;                                    
                                
                                ipSecurityRestriction = accessRestriction;
                                accessRestrictionExists = true;
                                break;
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(SubnetId) || (!string.IsNullOrWhiteSpace(SubnetName) && !string.IsNullOrWhiteSpace(VirtualNetworkName)))
                        {
                            var subnet = !string.IsNullOrWhiteSpace(SubnetId) ? SubnetId : SubnetName;
                            var subnetResourceId = CmdletHelpers.ValidateSubnet(subnet, VirtualNetworkName, ResourceGroupName, DefaultContext.Subscription.Id);
                            if (!string.IsNullOrWhiteSpace(accessRestriction.VnetSubnetResourceId) && accessRestriction.VnetSubnetResourceId.ToLowerInvariant() == subnetResourceId.ToLowerInvariant() && accessRestriction.Action.ToLowerInvariant() == Action.ToLowerInvariant())
                            {
                                if (!string.IsNullOrWhiteSpace(Name))
                                    if (!string.IsNullOrWhiteSpace(accessRestriction.Name) && accessRestriction.Name.ToLowerInvariant() == Name.ToLowerInvariant() && accessRestriction.Action.ToLowerInvariant() == Action.ToLowerInvariant())
                                        continue;

                                ipSecurityRestriction = accessRestriction;
                                accessRestrictionExists = true;
                                break;
                            }
                        }

                    }
                    if (accessRestrictionExists)
                    {
                        accessRestrictionList.Remove(ipSecurityRestriction);
                    }

                    // Update web app configuration
                    WebsitesClient.UpdateWebAppConfiguration(ResourceGroupName, webApp.Location, WebAppName, SlotName, siteConfig);

                    if (PassThru)
                    {
                        // Refresh object to get the final state
                        webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, SlotName));
                        var accessRestrictionConfig = new PSAccessRestrictionConfig(ResourceGroupName, WebAppName, webApp.SiteConfig, SlotName);
                        WriteObject(accessRestrictionConfig);
                    }
                }
            }
        }
    }
}
