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
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppAccessRestrictionRule", DefaultParameterSetName = IpAddressParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSAccessRestrictionConfig))]
    public class AddAzureWebAppAccessRestrictionRuleCmdlet : WebAppBaseClientCmdLet
    {        
        private const string IpAddressParameterSet = "IpAddressParameterSet";
        private const string SubnetNameParameterSet = "SubnetNameParameterSet";
        private const string SubnetIdParameterSet = "SubnetIdParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";
        
        [Parameter(ParameterSetName = IpAddressParameterSet, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = SubnetNameParameterSet, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.", ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Position = 1, Mandatory = true, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = SubnetNameParameterSet, Position = 1, Mandatory = true, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Position = 1, Mandatory = true, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Web/sites", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string WebAppName { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = true, HelpMessage = "Access Restriction rule name. E.g.: DeveloperWorkstation.")]
        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = true, HelpMessage = "Access Restriction rule name. E.g.: DeveloperWorkstation.")]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = true, HelpMessage = "Access Restriction rule name. E.g.: DeveloperWorkstation.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = false, HelpMessage = "Access Restriction description.")]
        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = false, HelpMessage = "Access Restriction description.")]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = false, HelpMessage = "Access Restriction description.")]
        public string Description { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = true, HelpMessage = "Access Restriction priority. E.g.: 500.")]
        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = true, HelpMessage = "Access Restriction priority. E.g.: 500.")]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = true, HelpMessage = "Access Restriction priority. E.g.: 500.")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(100, 65000)]
        public uint Priority { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = true, HelpMessage = "Allow or Deny rule.")]
        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = true, HelpMessage = "Allow or Deny rule.")]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = true, HelpMessage = "Allow or Deny rule.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Allow", "Deny")]
        public string Action { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = false, HelpMessage = "Deployment Slot name.")]
        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = false, HelpMessage = "Deployment Slot name.")]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = false, HelpMessage = "Deployment Slot name.")]
        [ValidateNotNullOrEmpty]
        public string SlotName { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = false, HelpMessage = "Rule is aimed for Main site or Scm site.")]
        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = false, HelpMessage = "Rule is aimed for Main site or Scm site.")]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = false, HelpMessage = "Rule is aimed for Main site or Scm site.")]
        [ValidateNotNullOrEmpty]        
        public SwitchParameter TargetScmSite { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = true, HelpMessage = "Ip Address v4 or v6 CIDR range. E.g.: 192.168.0.0/24")]
        [ValidateNotNullOrEmpty]
        public string IpAddress { get; set; }

        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = true, HelpMessage = "Name of Subnet.")]
        [ValidateNotNullOrEmpty]
        public string SubnetName { get; set; }

        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = true, HelpMessage = "Name of Virtual Network (must be in same resource group as Web App).")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = true, HelpMessage = "ResourceId of Subnet.")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = false, HelpMessage = "Specify if Service Endpoint registration at Subnet should be validated.")]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = false, HelpMessage = "Specify if Service Endpoint registration at Subnet should be validated.")]
        public SwitchParameter IgnoreMissingServiceEndpoint { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "Return the access restriction config object.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(ResourceGroupName) && !string.IsNullOrWhiteSpace(WebAppName))
            {
                var webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, SlotName));
                SiteConfig siteConfig = webApp.SiteConfig;
                var accessRestrictionList = TargetScmSite ? siteConfig.ScmIpSecurityRestrictions : siteConfig.IpSecurityRestrictions;
                IpSecurityRestriction ipSecurityRestriction = null;
                bool accessRestrictionExists = false;
                int intPriority = checked((int)Priority);
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
                                accessRestriction.Name = Name;
                                accessRestriction.Priority = intPriority;
                                accessRestriction.Description = Description;
                                break;
                            }
                        }
                        if (!accessRestrictionExists)
                        {
                            ipSecurityRestriction = new IpSecurityRestriction(IpAddress, null, null, null, null, Action, null, intPriority, Name, Description);
                            accessRestrictionList.Add(ipSecurityRestriction);
                        }
                        break;

                    case SubnetNameParameterSet:
                    case SubnetIdParameterSet:
                        var Subnet = ParameterSetName == SubnetNameParameterSet ? SubnetName : SubnetId;
                        //Fetch RG of given SubNet
                        var subNetResourceGroupName = CmdletHelpers.GetSubnetResourceGroupName(DefaultContext, Subnet, VirtualNetworkName);
                        //If unble to fetch SubNet rg from above step, use the input RG to get validation error from api call.
                        subNetResourceGroupName = !String.IsNullOrEmpty(subNetResourceGroupName) ? subNetResourceGroupName : ResourceGroupName;
                        var subnetResourceId = CmdletHelpers.ValidateSubnet(Subnet, VirtualNetworkName, subNetResourceGroupName, DefaultContext.Subscription.Id);
                        if (!IgnoreMissingServiceEndpoint)
                        {
                            CmdletHelpers.VerifySubnetDelegation(subnetResourceId);
                        }
                        foreach (var accessRestriction in accessRestrictionList)
                        {
                            if (accessRestriction.VnetSubnetResourceId != null &&
                                accessRestriction.VnetSubnetResourceId.ToLowerInvariant() == subnetResourceId.ToLowerInvariant() && 
                                accessRestriction.Action.ToLowerInvariant() == Action.ToLowerInvariant())
                            {
                                accessRestrictionExists = true;
                                accessRestriction.Name = Name;
                                accessRestriction.Priority = intPriority;
                                accessRestriction.Description = Description;
                                break;
                            }
                        }
                        if (!accessRestrictionExists)
                        {
                            ipSecurityRestriction = new IpSecurityRestriction(null, null, subnetResourceId, null, null, Action, null, intPriority, Name, Description);
                            accessRestrictionList.Add(ipSecurityRestriction);
                        }                   
                        break;
                }

                string updateAction = accessRestrictionExists ? "Updating" : "Adding";
                if (ShouldProcess(WebAppName, $"{updateAction} Access Restriction Rule '{Name}' for Web App '{WebAppName}'"))
                {
                    // Update web app configuration
                    WebsitesClient.UpdateWebAppConfiguration(ResourceGroupName, webApp.Location, WebAppName, SlotName, siteConfig);

                    if (PassThru)
                    {
                        // Refresh object to get the final state
                        webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, SlotName));
                        var accessRestrictionSettings = new PSAccessRestrictionConfig(ResourceGroupName, WebAppName, webApp.SiteConfig, SlotName);
                        WriteObject(accessRestrictionSettings);
                    }
                }
            }
        }
    }
}
