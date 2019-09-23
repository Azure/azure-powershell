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
using System;
using Microsoft.Azure.Commands.WebApps.Utilities;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you get a new Azure Websites using ARM APIs
    /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppAccessRestriction", DefaultParameterSetName = IpAddressParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSAccessRestrictionSettings))]
    public class AddAzureWebAppAccessRestrictionCmdlet : WebAppBaseClientCmdLet
    {        
        private const string IpAddressParameterSet = "IpAddressParameterSet";
        private const string SubnetParameterSet = "SubnetParameterSet";
        
        [Parameter(ParameterSetName = IpAddressParameterSet, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = SubnetParameterSet, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.", ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Position = 1, Mandatory = true, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = SubnetParameterSet, Position = 1, Mandatory = true, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Web/sites", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = true, HelpMessage = "Access Restriction rule name. E.g.: DeveloperWorkstation.")]
        [Parameter(ParameterSetName = SubnetParameterSet, Mandatory = true, HelpMessage = "Access Restriction rule name. E.g.: DeveloperWorkstation.")]
        [ValidateNotNullOrEmpty]
        public string RuleName { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = false, HelpMessage = "Access Restriction description.")]
        [Parameter(ParameterSetName = SubnetParameterSet, Mandatory = false, HelpMessage = "Access Restriction description.")]
        public string Description { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = true, HelpMessage = "Access Restriction priority. E.g.: 500.")]
        [Parameter(ParameterSetName = SubnetParameterSet, Mandatory = true, HelpMessage = "Access Restriction priority. E.g.: 500.")]        
        [ValidateNotNullOrEmpty]
        public int Priority { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = true, HelpMessage = "Allow or Deny rule.")]
        [Parameter(ParameterSetName = SubnetParameterSet, Mandatory = true, HelpMessage = "Allow or Deny rule.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Allow", "Deny")]
        public string Action { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = false, HelpMessage = "Deployment Slot name.")]
        [Parameter(ParameterSetName = SubnetParameterSet, Mandatory = false, HelpMessage = "Deployment Slot name.")]
        [ValidateNotNullOrEmpty]
        public string SlotName { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = false, HelpMessage = "Rule is aimed for Main site or Scm site.")]
        [Parameter(ParameterSetName = SubnetParameterSet, Mandatory = false, HelpMessage = "Rule is aimed for Main site or Scm site.")]
        [ValidateNotNullOrEmpty]        
        public SwitchParameter TargetScmSite { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = true, HelpMessage = "Ip Address v4 or v6 CIDR range. E.g.: 192.168.0.0/24")]
        [ValidateNotNullOrEmpty]
        public string IpAddress { get; set; }

        [Parameter(ParameterSetName = SubnetParameterSet, Mandatory = true, HelpMessage = "Name of Subnet (requires Virtual Network Name) or ResourceId of Subnet.")]
        [ValidateNotNullOrEmpty]
        public string Subnet { get; set; }

        [Parameter(ParameterSetName = SubnetParameterSet, Mandatory = false, HelpMessage = "Name of Virtual Network.")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(ParameterSetName = SubnetParameterSet, Mandatory = false, HelpMessage = "Specify if Service Endpoint registration at Subnet should be validated.")]
        public SwitchParameter IgnoreMissingServiceEndpoint { get; set; }


        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(ResourceGroupName) && !string.IsNullOrWhiteSpace(Name))
            {
                var webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, Name, SlotName));
                SiteConfig siteConfig = webApp.SiteConfig;
                var accessRestrictionList = TargetScmSite ? siteConfig.ScmIpSecurityRestrictions : siteConfig.IpSecurityRestrictions;
                IpSecurityRestriction ipSecurityRestriction = null;
                bool accessRestrictionExists = false;
                switch (ParameterSetName)
                {
                    case IpAddressParameterSet:                        
                        foreach (var accessRestriction in accessRestrictionList)
                        {
                            if (accessRestriction.IpAddress != null && 
                                accessRestriction.IpAddress == IpAddress && 
                                accessRestriction.Action.ToLowerInvariant() == Action.ToLowerInvariant())
                            {
                                accessRestrictionExists = true;
                                accessRestriction.Name = RuleName;
                                accessRestriction.Priority = Priority;
                                accessRestriction.Description = Description;
                                break;
                            }
                        }
                        if (!accessRestrictionExists)
                        {
                            ipSecurityRestriction = new IpSecurityRestriction(IpAddress, null, null, null, null, Action, null, Priority, RuleName, Description);
                            accessRestrictionList.Add(ipSecurityRestriction);
                        }
                        break;

                    case SubnetParameterSet:
                        var subnetResourceId = CmdletHelpers.ValidateSubnet(Subnet, VirtualNetworkName, ResourceGroupName, DefaultContext.Subscription.Id);
                        if (!IgnoreMissingServiceEndpoint)
                        {
                            CmdletHelpers.VerifySubnetDelegation(DefaultContext, subnetResourceId);
                        }
                        foreach (var accessRestriction in accessRestrictionList)
                        {
                            if (accessRestriction.VnetSubnetResourceId != null &&
                                accessRestriction.VnetSubnetResourceId.ToLowerInvariant() == subnetResourceId.ToLowerInvariant() && 
                                accessRestriction.Action.ToLowerInvariant() == Action.ToLowerInvariant())
                            {
                                accessRestrictionExists = true;
                                accessRestriction.Name = RuleName;
                                accessRestriction.Priority = Priority;
                                accessRestriction.Description = Description;
                                break;
                            }
                        }
                        if (!accessRestrictionExists)
                        {
                            ipSecurityRestriction = new IpSecurityRestriction(null, null, subnetResourceId, null, null, Action, null, Priority, RuleName, Description);
                            accessRestrictionList.Add(ipSecurityRestriction);
                        }                   
                        break;
                }

                string updateAction = accessRestrictionExists ? "Updating" : "Adding";
                if (ShouldProcess(Name, $"{updateAction} Access Restriction Rule '{RuleName}' for Web App '{Name}'"))
                {
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
